/*!
 * 定义通信协议及封装接口
 **/
using System;

namespace DDMAgent
{
    //////////////////////////////////////////////////////////////////////////////
    public enum TELESCOPE_STATE
    {
        TELESCOPE_ERROR,        //< 错误
        TELESCOPE_FREEZE,       //< 静止
        TELESCOPE_HOMING,       //< 找零
        TELESCOPE_HOMED,        //< 找到零点
        TELESCOPE_PARKING,      //< 复位
        TELESCOPE_PARKED,       //< 已复位
        TELESCOPE_SLEWING,      //< 指向
        TELESCOPE_TRACKING      //< 跟踪
    }

public class ascii_proto_base
{
    public string type;
    public string gid;
    public string uid;
    public string utc;
}

public class ascii_proto_reg : ascii_proto_base {// 注册设备/用户
	public int result; //< 注册结果. 0: 成功; != 0: 失败, 及错误字
    public int ostype; //< 观测系统类型. 通知相机观测系统类型, 区别创建目录及文件名和文件头

    public ascii_proto_reg()
    {
        type = "register";
        result = -1;
        ostype = -1;
    }
};

public class ascii_proto_find_home : ascii_proto_base{// 搜索零点
    public ascii_proto_find_home()
    {
        type = "find_home";
    }
};

public class ascii_proto_home_sync : ascii_proto_base {// 同步零点
    public double ra;      //< 赤经, 量纲: 角度
    public double dc;      //< 赤纬, 量纲: 角度
    public double epoch;	//< 历元

    public ascii_proto_home_sync()
    {
        type = "home_sync";
        ra = dc = 1E30;
        epoch = 2000.0;
    }
};

public class ascii_proto_slewto : ascii_proto_base {// 指向
    public double ra;       //< 赤经, 量纲: 角度
    public double dc;       //< 赤纬, 量纲: 角度
    public double epoch;    //< 历元

    public ascii_proto_slewto()
    {
        type = "slewto";
        ra = dc = 1E30;
        epoch = 2000.0;
    }
};

public class ascii_proto_park : ascii_proto_base {// 复位

    public ascii_proto_park()
    {
        type = "park";
    }
};

public class ascii_proto_guide : ascii_proto_base {// 导星
	public double ra;      //< 赤经偏差, 量纲: 角度
    public double dc;      //< 赤纬偏差, 量纲: 角度

    public ascii_proto_guide()
    {
        type = "guide";
        ra = dc = 1E30;
    }
};

public class ascii_proto_abort_slew : ascii_proto_base {// 中止指向
    public ascii_proto_abort_slew()
    {
        type = "abort_slew";
    }
};

public class ascii_proto_telescope : ascii_proto_base {// 望远镜信息
    public int state;      //< 工作状态
    public int ec;         //< 错误代码
    public double ra;      //< 指向赤经, 量纲: 角度
    public double dc;      //< 指向赤纬, 量纲: 角度
    public double azi;     //< 指向方位, 量纲: 角度
    public double ele;  	//< 指向高度, 量纲: 角度

    public ascii_proto_telescope()
    {
        type = "telescope";
        state = 0;
        ec = 0;
        ra = dc = 1E30;
        azi = ele = 1E30;
    }
};

public class ascii_proto_focus : ascii_proto_base {// 焦点位置
    public int state;  //< 调焦器工作状态. 0: 未知; 1: 静止; 2: 调焦
    public int value;	//< 焦点位置, 量纲: 微米

    public ascii_proto_focus()
    {
        type = "focus";
        state = 0;
        value = 0;
    }
};

public class ascii_proto_mcover : ascii_proto_base {// 开关镜盖
	public int value;  //< 复用字
                //< 用户/数据库=>服务器: 指令
                //< 服务器=>用户/数据库: 状态

    public ascii_proto_mcover()
    {
        type = "mcover";
        value = 0;
    }
};
//////////////////////////////////////////////////////////////////////////////
    public class AsciiProtocol
    {
        public bool ValidRA(double ra)
        {
            return (ra >= 0.0 && ra < 360.0);
        }

        public bool ValidDEC(double dec)
        {
            return (dec > -90.0 && dec < 90.0);
        }

        public string CompactRegister(string gid, string uid)
        {
            string output = "register ";
            output += "group_id=" + gid + ",";
            output += "unit_id=" + uid;
            output += "\n";

            return output;
        }

        public string CompactTelescope(ascii_proto_telescope info)
        {
            string output = "telescope ";
            output += "state=" + Convert.ToString(info.state) + ",";
            output += "ec=" + Convert.ToString(info.ec) + ",";
            output += "ra=" + Convert.ToString(info.ra) + ",";
            output += "dec=" + Convert.ToString(info.dc) + ",";
            output += "azi=" + Convert.ToString(info.azi) + ",";
            output += "ele=" + Convert.ToString(info.ele);
            output += "\n";

            return output;
        }

        public ascii_proto_base Resolve(string rcvd)
        {
            string[] split = rcvd.Split(new char[] {' ','=', ',', '\n', '\t'});
            int n = split.Length, i;
            string type = split[0];
            ascii_proto_base proto = null;
            // 解析通信协议
            if (type == "park")
            {
                proto = new ascii_proto_park();
            }
            else if (type == "abort_slew")
            {
                proto = new ascii_proto_abort_slew();
            }
            else if (type == "guide")
            {
                ascii_proto_guide proto1 = new ascii_proto_guide();

                for (i = 1; i < n; ++i)
                {
                    if (split[i] == "ra" && (i + 1) < n)
                        proto1.ra = Convert.ToDouble(split[i + 1]);
                    else if (split[i] == "dec" && (i + 1) < n)
                        proto1.dc = Convert.ToDouble(split[i + 1]);
                }

                proto = proto1;
            }
            else if (type == "slewto")
            {
                ascii_proto_slewto proto1 = new ascii_proto_slewto();
                for (i = 1; i < n; ++i)
                {
                    if (split[i] == "ra" && (i + 1) < n)
                        proto1.ra = Convert.ToDouble(split[i + 1]);
                    else if (split[i] == "dec" && (i + 1) < n)
                        proto1.dc = Convert.ToDouble(split[i + 1]);
                }

                proto = proto1;
            }

            return proto;
        }
    }
};
