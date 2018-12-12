using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using ASCOM.DriverAccess;
using ASCOM.DeviceInterface;
using XMLConfig;
using TimeSync;

namespace DDMAgent
{
    public partial class frmMain : Form
    {
        /* 成员变量 */
        string[] TELESCOPE_STATE_STR =
        {
            "Error",
            "Freeze",
            "Homing",
            "Homed",
            "Parking",
            "Parked",
            "Slewing",
            "Tracking"
        };

        public class InformationTelescope
        {
            public TELESCOPE_STATE old;      //< 原工作状态
            public TELESCOPE_STATE state;    //< 工作状态
            public int ec;            //< 错误代码
            public double ra;         //< 指向赤经, 量纲: 角度
            public double dc;         //< 指向赤纬, 量纲: 角度
            public double azi;        //< 指向方位, 量纲: 角度
            public double ele;  	  //< 指向高度, 量纲: 角度
            public double ora, odc;   //< 目标坐标, 量纲: 角度. 赤道系, 当前历元
            public double ora00, odc00;//< 目标坐标, 量纲: 角度. 赤道系, J2000
        };

        // 参数
        public string gid_;    //< 组标志
        public string uid_;    //< 单元标志
        public string ip_server_;  //< 服务器IP地址
        public UInt16 port_server_;    //< 服务器端口
        public string ip_ntp_;     //< NTP服务器IP地址
        public bool clock_sync_;   //< 指向前同步时钟
        public bool modified_;      //< 参数修改标志

        // 接口
        AstroArith ats_ = null;
        Parameter param_ = null;
        Telescope telescope_ = null;
        Focuser focuser_ = null;
        NTPClient ntp_ = null;
        Socket sock_ = null;
        byte[] bufrcv_ = null;
        AsciiProtocol ascproto_ = null;

        // 控制量
        bool remote_cmd_;   // 远程控制指令
        InformationTelescope nftele_;   //< 望远镜工作状态
        double obj_range_; // 开始指向时, 当前位置与目标位置的大圆距离, 量纲: 弧度

        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            btnFindHome.Enabled = false;
            btnPark.Enabled = false;
            btnHomeSync.Enabled = false;
            btnSlew.Enabled = false;
            btnAbort.Enabled = false;
            btnFocusPlus.Enabled = false;
            btnFocusMinus.Enabled = false;
            chkAbsFocus.Enabled = false;

            param_ = new Parameter(Environment.CurrentDirectory + "\\DDMAgent.xml");
            gid_ = param_.GetValue("ID", "Group", "002");
            uid_ = param_.GetValue("ID", "Unit", "001");
            ip_server_ = param_.GetValue("Server", "IP", "172.28.1.11");
            port_server_ = Convert.ToUInt16(param_.GetValue("Server", "Port", "4011"));
            ip_ntp_ = param_.GetValue("NTP", "IP", "172.28.1.9");
            clock_sync_ = Convert.ToBoolean(param_.GetValue("NTP", "ClockSync", "true"));
            modified_ = false;

            ats_ = new AstroArith();
            ascproto_ = new AsciiProtocol();

            remote_cmd_ = false;
            nftele_ = new InformationTelescope();
        }

        private void btnConfigSystem_Click(object sender, EventArgs e)
        {
            // 配置观测系统参数
            frmSystem form = new frmSystem(this);
            form.StartPosition = FormStartPosition.CenterParent;
            form.Show();
        }

        private void btnSelectTelescope_Click(object sender, EventArgs e)
        {
            // 选择支持ASCOM的望远镜
            try
            {
                string progID1 = param_.GetValue("Instrument", "Telescope", "");
                string progID2 = Telescope.Choose("AstrooptikServer.Telescope");
                if (progID2 == null || progID2 == "")
                {
                    MessageBox.Show("Could not find \'AstrooptikServer.Telescope\'");
                }
                else if (progID1 != progID2)
                    param_.SetValue("Instrument", "Telescope", progID2);
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelectFocuser_Click(object sender, EventArgs e)
        {
            // 选择支持ASCOM的调焦器
            try
            {
                string progID1 = param_.GetValue("Instrument", "Focuser", "");
                string progID2 = Focuser.Choose("ACCServer.Focuser");
                if (progID2 == null || progID2 == "")
                {
                    MessageBox.Show("Could not find \'ACCServer.Focuser\'");
                }
                else if (progID1 != progID2)
                    param_.SetValue("Instrument", "Focuser", progID2);
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLinkServer_Click(object sender, EventArgs e)
        {
            // 连接网络服务器
            if (telescope_ == null || telescope_.Connected == false)
            {
                MessageBox.Show("Link Telescope first!");
                return;
            }
            // 尝试连接网络服务器
            sock_ = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sock_.Connect(ip_server_, port_server_);

                btnLinkServer.Enabled = false;
                btnConfigSystem.Enabled = false;
                lblNetwork.Text = "Connected";

                bufrcv_ = new byte[1024];
                AsyncSendString(ascproto_.CompactRegister(gid_, uid_));
                AsyncReceive();

                tmrNet.Enabled = true;
            }
            catch (Exception ex)
            {
                txtLog.AppendLine("Failed: " + ex.Message);
            }
        }

        private void btnLinkTelescope_Click(object sender, EventArgs e)
        {
            // 连接望远镜
            try
            {
                string progID = param_.GetValue("Instrument", "Telescope", "");
                if (progID == null || progID == "")
                    MessageBox.Show("Choose Telescope first!");
                else
                    telescope_ = new Telescope(progID);
                if (telescope_ != null)
                    telescope_.Connected = true;

                if (telescope_ != null && telescope_.Connected == true)
                {// 连接成功
                    ats_.SetGeoSite(telescope_.SiteLongitude * AstroArith.GtoR, telescope_.SiteLatitude * AstroArith.GtoR, telescope_.SiteElevation);
                    telescope_.SlewSettleTime = 4;
                    nftele_.old = TELESCOPE_STATE.TELESCOPE_ERROR;
                    nftele_.state = TELESCOPE_STATE.TELESCOPE_FREEZE;
                    nftele_.ora = telescope_.RightAscension * 15.0;
                    nftele_.odc = telescope_.Declination;
                    nftele_.ora00 = nftele_.ora;
                    nftele_.odc00 = nftele_.odc;
                    btnSelectTelescope.Enabled = false;
                    btnLinkTelescope.Enabled = false;
                    btnFindHome.Enabled = true;
                    btnPark.Enabled = true;
                    btnSlew.Enabled = true;
                    btnHomeSync.Enabled = true;
                    btnAbort.Enabled = true;

                    tmrMain.Enabled = true;
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLinkFocuser_Click(object sender, EventArgs e)
        {
            // 连接调焦器
            try
            {
                string progID = param_.GetValue("Instrument", "Focuser", "");
                if (progID == null || progID == "")
                    MessageBox.Show("Choose Focuser first!");
                else
                    focuser_ = new Focuser(progID);
                if (focuser_ != null)
                    focuser_.Connected = true;

                if (focuser_ != null && focuser_.Connected == true)
                {// 连接成功
                    btnSelectFocuser.Enabled = false;
                    btnLinkFocuser.Enabled = false;
                    btnFocusPlus.Enabled = true;
                    btnFocusMinus.Enabled = true;
                    if (focuser_.Absolute == true)
                        chkAbsFocus.Enabled = true;
                    txtInFocus.Text = string.Format("{0:0}", focuser_.StepSize);
                    lblFocus.Text = Convert.ToString(focuser_.Position);
                    lblFocusTarget.Text = Convert.ToString(focuser_.Position);

                    tmrFocus.Enabled = true;
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNTP_Click(object sender, EventArgs e)
        {
            // NTP基本操作
            ntp_ = new NTPClient(ip_ntp_);
            tmrNTP.Enabled = true;
            btnNTP.Enabled = false;
        }

        private void btnSlew_Click(object sender, EventArgs e)
        {
            ProcSlewto();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            // 停止指向过程
            telescope_.AbortSlew();
        }

        private void btnFindHome_Click(object sender, EventArgs e)
        {
            // 望远镜搜索零点
            telescope_.FindHome();
            nftele_.state = TELESCOPE_STATE.TELESCOPE_HOMING;
        }

        private void btnPark_Click(object sender, EventArgs e)
        {
            // 望远镜复位
            nftele_.state = TELESCOPE_STATE.TELESCOPE_PARKING;
            telescope_.Park();
        }

        private void btnHomeSync_Click(object sender, EventArgs e)
        {
            // 望远镜同步零点
            telescope_.SyncToTarget();
        }

        private void btnFocusPlus_Click(object sender, EventArgs e)
        {
            // 正向调焦
            string value = txtInFocus.Text; // 容错: 须判断数据格式是整数
            if (value == "")
                return;

            int position = Convert.ToInt32(value);
            if (chkAbsFocus.Checked == true) // 需要绝对定位, 不论加\减, 都是相同操作
            {
                lblFocusTarget.Text = Convert.ToString(position);
                if (focuser_.Absolute == false) // 不支持绝对定位
                    position = position - focuser_.Position;
            }
            else // 需要相对定位, 与加\减符号有关
            {
                if (focuser_.Absolute == true) // 不支持相对定位
                    position = focuser_.Position + position;
                lblFocusTarget.Text = Convert.ToString(position);
            }
            focuser_.Move(position);
        }

        private void btnFocusMinus_Click(object sender, EventArgs e)
        {
            // 反向调焦
            string value = txtInFocus.Text;
            if (value == "")
                return;

            int position = Convert.ToInt32(value);
            if (chkAbsFocus.Checked == true) // 需要绝对定位, 不论加\减, 都是相同操作
            {
                lblFocusTarget.Text = Convert.ToString(position);
                if (focuser_.Absolute == false) // 不支持绝对定位
                    position = position - focuser_.Position;
            }
            else // 需要相对定位, 与加\减符号有关
            {
                if (focuser_.Absolute == true) // 不支持相对定位
                    position = focuser_.Position - position;
                lblFocusTarget.Text = Convert.ToString(position);
            }
            focuser_.Move(position);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrNet.Enabled = false;
            tmrMain.Enabled = false;
            tmrFocus.Enabled = false;
            tmrNTP.Enabled = false;

            if (telescope_!=null)
            {
                if (telescope_.Connected)
                    telescope_.Connected = false;
                telescope_.Dispose();
            }
            if (focuser_ != null)
            {
                if (focuser_.Connected)
                    focuser_.Connected = false;
                focuser_.Dispose();
            }

            // 关闭窗口前释放资源/保存参数
            if(modified_)
            {
                param_.SetValue("ID", "Group", gid_);
                param_.SetValue("ID", "Unit", uid_);
                param_.SetValue("Server", "IP", ip_server_);
                param_.SetValue("Server", "Port", Convert.ToString(port_server_));
                param_.SetValue("NTP", "IP", ip_ntp_);
                param_.SetValue("NTP", "ClockSync", Convert.ToString(clock_sync_));
            }
        }

        private void tmrNTP_Tick(object sender, EventArgs e)
        {
            // NTP, 定时计算本地时钟偏差
            try
            {
                ntp_.Connect(false);
            }
            catch (SocketException ex)
            {
                txtLog.AppendLine(ex.Message);
                tmrNTP.Enabled = false;
                btnNTP.Enabled = true;
                ntp_ = null;
            }
        }

        private void tmrNet_Tick(object sender, EventArgs e)
        {
            // 定时向服务器发送望远镜状态信息
            ascii_proto_telescope info = new ascii_proto_telescope();
            info.state = Convert.ToInt32(nftele_.state);
            info.ec = nftele_.ec;
            info.ra = nftele_.ra;
            info.dc = nftele_.dc;
            info.azi = nftele_.azi;
            info.ele = nftele_.ele;
            AsyncSendString(ascproto_.CompactTelescope(info));
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            try
            {
                // 通过ASCOM定时检查望远镜状态信息
                double st, ra;
                int hh = 0;
                int dd = 0;
                int mm = 0;
                double ss = 0.0;
                string sign = "";

                st = telescope_.SiderealTime;
                ra = telescope_.RightAscension;
                nftele_.ra = ra * 15.0; // 转换为角度
                nftele_.dc = telescope_.Declination;
                nftele_.azi = telescope_.Azimuth;
                nftele_.ele = telescope_.Altitude;

                ats_.HH2HMS(st, ref hh, ref mm, ref ss);
                lblST.Text = string.Format("{0:00}:{1:00}:{2:00.00}", hh, mm, ss);

                ats_.HH2HMS(ra, ref hh, ref mm, ref ss);
                lblRA.Text= string.Format("{0:00}:{1:00}:{2:00.00}", hh, mm, ss);
                ats_.DD2DMS(nftele_.dc, ref dd, ref mm, ref ss, ref sign);
                lblDEC.Text = sign + string.Format("{0:00}:{1:00}:{2:00.0}", dd, mm, ss);

                lblAzi.Text = string.Format("{0:0.0000}", nftele_.azi);
                lblEle.Text = string.Format("{0:0.0000}", nftele_.ele);

                if (telescope_.AtHome)
                {
                    nftele_.state = TELESCOPE_STATE.TELESCOPE_HOMED;
                }
                else if (telescope_.AtPark)
                    nftele_.state = TELESCOPE_STATE.TELESCOPE_PARKED;
                //                    else if (nftele_.state == TELESCOPE_STATE.TELESCOPE_SLEWING)
                else if (telescope_.Slewing)
                {
                    if (nftele_.state == TELESCOPE_STATE.TELESCOPE_SLEWING)
                    {
                        double r = ats_.SphereAngle(nftele_.ora00, nftele_.odc00, nftele_.ra, nftele_.dc);
                        if (r < 5E-6)
                        {
                            nftele_.state = TELESCOPE_STATE.TELESCOPE_TRACKING;
                            procSlew.Value = procSlew.Maximum;
                        }
                        else
                        {
                            int value = Convert.ToInt32((1.0 - r / obj_range_) * procSlew.Maximum);
                            if (value > procSlew.Value)
                                procSlew.Value = value;
                        }
                    }
                    else
                    {
                        nftele_.ora00 = telescope_.TargetRightAscension * 15.0;
                        nftele_.odc00 = telescope_.TargetDeclination;
                        obj_range_ = ats_.SphereAngle(nftele_.ora00, nftele_.odc00, nftele_.ra, nftele_.dc);
                        procSlew.Value = procSlew.Minimum;
                        nftele_.state = TELESCOPE_STATE.TELESCOPE_SLEWING;
                    }
                }
                else if (nftele_.state == TELESCOPE_STATE.TELESCOPE_PARKING)
                {
                    //...该状态不能正常显示
                }
                else if (telescope_.Tracking && nftele_.state != TELESCOPE_STATE.TELESCOPE_TRACKING)
                {
                    nftele_.state = TELESCOPE_STATE.TELESCOPE_TRACKING;
                    if (procSlew.Value < procSlew.Maximum)
                        procSlew.Value = procSlew.Maximum;
                }

                if (nftele_.old != nftele_.state)
                { 
                    nftele_.old = nftele_.state;
                    lblState.Text = TELESCOPE_STATE_STR[Convert.ToInt16(nftele_.state) ];
                }
            }
            catch (COMException ex)
            {
                txtLog.AppendLine(ex.Message);
            }
        }

        private void tmrFocus_Tick(object sender, EventArgs e)
        {
            // 通过ASCOM定时检查调焦器工作状态
            lblFocus.Text = Convert.ToString(focuser_.Position);
        }

        /*!
         * @breif 检查目标位置是否超出水平保护范围
         * @param ha  时角, 量纲: 角度
         * @param dec 赤纬, 量纲: 角度
         * @return
         * 水平保护标志
         * @note
         * 水平限位: 10度
         */
        private bool SafePosition(double ha, double dec)
        {
            double azi = 0.0;
            double ele = 0.0;
            ats_.Eq2AltAzi(ha * AstroArith.GtoR, dec * AstroArith.GtoR, ref azi, ref ele);
            return (ele * AstroArith.RtoG > 10.0);
        }

        private void FillTarget(double ra, double dec, double epoch)
        {
            int hh = 0;
            int dd = 0;
            int mm = 0;
            double ss = 0.0;
            string sign = "";

            ats_.HH2HMS(ra / 15.0, ref hh, ref mm, ref ss);
            txtInRA.Text = string.Format("{0:00}:{1:00}:{2:00.00}", hh, mm, ss);
            ats_.DD2DMS(dec, ref dd, ref mm, ref ss, ref sign);
            txtInDEC.Text = sign + string.Format("{0:00}:{1:00}:{2:00.0}", dd, mm, ss);

            if (Math.Abs(epoch) < 1E-6)
                cmbInEpoch.Text = "Real";
            else if (Math.Abs(epoch - 2000.0) < 1E-6)
                cmbInEpoch.Text = "J2000";
            else
                cmbInEpoch.Text = string.Format("{0:0.00}", epoch);
        }

        /*!
         * 向服务器发送字符串
         **/
        private void AsyncSendString(string output)
        {
            if (sock_ == null || output == string.Empty) return;

            byte[] data = Encoding.Default.GetBytes(output);
            try
            {
                sock_.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult=>
                {
                    sock_.EndSend(asyncResult);
                },null);
            }
            catch(Exception ex)
            {
                txtLog.AppendLine(ex.Message);
            }
        }

        private void ProcessFromServer(string rcvd)
        {
            ascii_proto_base proto = ascproto_.Resolve(rcvd);
            if (proto != null)
            {
                if (proto.type == "slewto")
                {
                    ascii_proto_slewto proto1 = (ascii_proto_slewto)proto;
                    FillTarget(proto1.ra, proto1.dc, proto1.epoch);
                    remote_cmd_ = true;
                    ProcSlewto();
                }
                else if (proto.type == "guide")
                {
                    ascii_proto_guide proto1 = (ascii_proto_guide)proto;
                    FillTarget(nftele_.ora00 + proto1.ra, nftele_.odc00 + proto1.dc, 2000.0);
                    remote_cmd_ = true;
                    ProcSlewto();
                }
                else if (proto.type == "abort_slew")
                {
                    telescope_.AbortSlew();
                }
                else if (proto.type == "park")
                {
                    nftele_.state = TELESCOPE_STATE.TELESCOPE_PARKING;
                    telescope_.Park();
                }
            }
            else
            {// 错误协议
                OnCloseNetwork("received wrong protocol");
            }
        }

        private void OnCloseNetwork(string msg)
        {
            txtLog.AppendLine(msg);
            lblNetwork.Text = "DisConnect";
            tmrNet.Enabled = false;
            btnLinkServer.Enabled = true;
            sock_.Close();
            sock_ = null;
        }

        private void AsyncReceive()
        {
            try
            {
                sock_.BeginReceive(bufrcv_, 0, bufrcv_.Length, SocketFlags.None, asyncResult =>
                {
                    int len = sock_.EndReceive(asyncResult);
                    if (len > 0)
                    {
                        ProcessFromServer(Encoding.Default.GetString(bufrcv_));
                        // 继续异步接收信息
                        AsyncReceive();
                    }
                    else
                    {
                        OnCloseNetwork("remote peer closed connection");
                    }
                }, null);
            }
            catch (Exception ex)
            {
                OnCloseNetwork(ex.Message);
            }
        }

        // 处理指向
        private void ProcSlewto()
        {
            // 检查输入坐标正确性
            string strEpoch = cmbInEpoch.Text;
            double ra = 0.0;
            double dec = 0.0;
            double tmsid = 0.0; // 恒星时

            if (false == ats_.StringHour2Double(txtInRA.Text, ref ra))
            {
                txtLog.AppendLine("Invalid R.A. style");
                //...设置错误字
                return;
            }
            if (false == ats_.StringDegree2Double(txtInDEC.Text, ref dec))
            {
                txtLog.AppendLine("Invalid DEC. style");
                //...设置错误字
                return;
            }
            // DDMAgent=>Autoslew：当前历元
            DateTime now = DateTime.UtcNow;
            double ra_a = 0.0;
            double de_a = 0.0;
            char[] epLead = { 'B', 'J' }; // 常见历元的引导字符, 例: B1950, J2000
            double jc1 = Convert.ToDouble(strEpoch.Trim(epLead));
            double jc2 = ats_.GetEpoch(now.Year, now.Month, now.Day,
                now.Hour + (now.Minute + (now.Second + now.Millisecond * 0.001) / 60.0) / 60.0);
            jc1 = ats_.Epoch2JC(jc1);    // 转换为儒略世纪
            jc2 = ats_.Epoch2JC(jc2);
            if (strEpoch != "" && string.Compare(strEpoch, "Real", StringComparison.CurrentCultureIgnoreCase) != 0)
            {// J2000=>Real
                nftele_.ora00 = ra * 15.0;
                nftele_.odc00 = dec;
                ats_.Epoch2Actual(jc1, ra * 15 * AstroArith.GtoR, dec * AstroArith.GtoR,
                    jc2, ref ra_a, ref de_a);
                ra = ra_a * AstroArith.RtoG / 15;
                dec = de_a * AstroArith.RtoG;
                nftele_.ora = ra * 15.0;
                nftele_.odc = dec;
            }
            else
            {// Real=>J2000
                nftele_.ora = ra * 15.0;
                nftele_.odc = dec;
                ats_.Epoch2Actual(jc2, ra * 15 * AstroArith.GtoR, dec * AstroArith.GtoR,
                    jc1, ref ra_a, ref de_a);
                nftele_.ora00 = ra_a * AstroArith.RtoG;
                nftele_.odc00 = de_a * AstroArith.RtoG;
            }

            tmsid = telescope_.SiderealTime; // 恒星时, 量纲: 小时
            if (SafePosition((tmsid - ra) * 15.0, dec) == false)
            {// 超出安全限位, 界面显示及通知远程用户
                txtLog.AppendLine("Out of Limit");
                //...设置错误字
            }
            else
            {// 在安全范围内
                if (telescope_.AtPark == true)
                    telescope_.Unpark();
                if (telescope_.Tracking == false)
                    telescope_.Tracking = true;

                obj_range_ = ats_.SphereAngle(nftele_.ora00, nftele_.odc00, telescope_.RightAscension * 15.0, telescope_.Declination);

                if (obj_range_ < 1E-6) // 1E-6弧度≈0.2角秒
                {
                    nftele_.state = TELESCOPE_STATE.TELESCOPE_TRACKING;
                }
                else
                {
                    // 指向前同步时钟
                    if (ntp_ != null && ntp_.validCorrect == true && ntp_.clockCorrect.TotalMilliseconds > 50)
                    {
                        DateTime now1 = DateTime.Now + ntp_.clockCorrect;
                        ntp_.SetTime(ref now1);
                    }
                    // 执行指向操作
                    nftele_.state = TELESCOPE_STATE.TELESCOPE_SLEWING;
                    telescope_.TargetRightAscension = ra;
                    telescope_.TargetDeclination = dec;
                    telescope_.SlewToTargetAsync();

                    procSlew.Value = procSlew.Minimum;
                }
                lblState.Text = TELESCOPE_STATE_STR[(int)nftele_.state];
            }
        }
    }
}
