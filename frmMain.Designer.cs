namespace DDMAgent
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnSelectTelescope = new System.Windows.Forms.Button();
            this.btnSelectFocuser = new System.Windows.Forms.Button();
            this.btnLinkServer = new System.Windows.Forms.Button();
            this.btnLinkTelescope = new System.Windows.Forms.Button();
            this.btnLinkFocuser = new System.Windows.Forms.Button();
            this.btnConfigSystem = new System.Windows.Forms.Button();
            this.btnNTP = new System.Windows.Forms.Button();
            this.procSlew = new System.Windows.Forms.ProgressBar();
            this.btnFindHome = new System.Windows.Forms.Button();
            this.btnPark = new System.Windows.Forms.Button();
            this.btnHomeSync = new System.Windows.Forms.Button();
            this.btnSlew = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInRA = new System.Windows.Forms.TextBox();
            this.txtInDEC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbInEpoch = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblST = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRA = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDEC = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEle = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAzi = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFocus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFocusMinus = new System.Windows.Forms.Button();
            this.btnFocusPlus = new System.Windows.Forms.Button();
            this.chkAbsFocus = new System.Windows.Forms.CheckBox();
            this.txtInFocus = new System.Windows.Forms.TextBox();
            this.lblNetwork = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tmrNTP = new System.Windows.Forms.Timer(this.components);
            this.tmrNet = new System.Windows.Forms.Timer(this.components);
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.tmrFocus = new System.Windows.Forms.Timer(this.components);
            this.lblFocusTarget = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectTelescope
            // 
            this.btnSelectTelescope.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectTelescope.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSelectTelescope.Location = new System.Drawing.Point(136, 12);
            this.btnSelectTelescope.Name = "btnSelectTelescope";
            this.btnSelectTelescope.Size = new System.Drawing.Size(100, 45);
            this.btnSelectTelescope.TabIndex = 2;
            this.btnSelectTelescope.Text = "Select Telescope";
            this.btnSelectTelescope.UseVisualStyleBackColor = true;
            this.btnSelectTelescope.Click += new System.EventHandler(this.btnSelectTelescope_Click);
            // 
            // btnSelectFocuser
            // 
            this.btnSelectFocuser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectFocuser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSelectFocuser.Location = new System.Drawing.Point(242, 12);
            this.btnSelectFocuser.Name = "btnSelectFocuser";
            this.btnSelectFocuser.Size = new System.Drawing.Size(100, 45);
            this.btnSelectFocuser.TabIndex = 3;
            this.btnSelectFocuser.Text = "Select Focuser";
            this.btnSelectFocuser.UseVisualStyleBackColor = true;
            this.btnSelectFocuser.Click += new System.EventHandler(this.btnSelectFocuser_Click);
            // 
            // btnLinkServer
            // 
            this.btnLinkServer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLinkServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLinkServer.Location = new System.Drawing.Point(428, 12);
            this.btnLinkServer.Name = "btnLinkServer";
            this.btnLinkServer.Size = new System.Drawing.Size(100, 45);
            this.btnLinkServer.TabIndex = 4;
            this.btnLinkServer.Text = "Link Server";
            this.btnLinkServer.UseVisualStyleBackColor = true;
            this.btnLinkServer.Click += new System.EventHandler(this.btnLinkServer_Click);
            // 
            // btnLinkTelescope
            // 
            this.btnLinkTelescope.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLinkTelescope.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLinkTelescope.Location = new System.Drawing.Point(534, 12);
            this.btnLinkTelescope.Name = "btnLinkTelescope";
            this.btnLinkTelescope.Size = new System.Drawing.Size(100, 45);
            this.btnLinkTelescope.TabIndex = 5;
            this.btnLinkTelescope.Text = "Link Telescope";
            this.btnLinkTelescope.UseVisualStyleBackColor = true;
            this.btnLinkTelescope.Click += new System.EventHandler(this.btnLinkTelescope_Click);
            // 
            // btnLinkFocuser
            // 
            this.btnLinkFocuser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLinkFocuser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLinkFocuser.Location = new System.Drawing.Point(640, 12);
            this.btnLinkFocuser.Name = "btnLinkFocuser";
            this.btnLinkFocuser.Size = new System.Drawing.Size(100, 45);
            this.btnLinkFocuser.TabIndex = 6;
            this.btnLinkFocuser.Text = "Link Focuser";
            this.btnLinkFocuser.UseVisualStyleBackColor = true;
            this.btnLinkFocuser.Click += new System.EventHandler(this.btnLinkFocuser_Click);
            // 
            // btnConfigSystem
            // 
            this.btnConfigSystem.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfigSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnConfigSystem.Location = new System.Drawing.Point(30, 12);
            this.btnConfigSystem.Name = "btnConfigSystem";
            this.btnConfigSystem.Size = new System.Drawing.Size(100, 45);
            this.btnConfigSystem.TabIndex = 1;
            this.btnConfigSystem.Text = "Config System";
            this.btnConfigSystem.UseVisualStyleBackColor = true;
            this.btnConfigSystem.Click += new System.EventHandler(this.btnConfigSystem_Click);
            // 
            // btnNTP
            // 
            this.btnNTP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNTP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNTP.Location = new System.Drawing.Point(428, 74);
            this.btnNTP.Name = "btnNTP";
            this.btnNTP.Size = new System.Drawing.Size(100, 45);
            this.btnNTP.TabIndex = 7;
            this.btnNTP.Text = "Link NTP";
            this.btnNTP.UseVisualStyleBackColor = true;
            this.btnNTP.Click += new System.EventHandler(this.btnNTP_Click);
            // 
            // procSlew
            // 
            this.procSlew.Location = new System.Drawing.Point(30, 142);
            this.procSlew.Name = "procSlew";
            this.procSlew.Size = new System.Drawing.Size(710, 36);
            this.procSlew.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.procSlew.TabIndex = 8;
            // 
            // btnFindHome
            // 
            this.btnFindHome.BackColor = System.Drawing.Color.Black;
            this.btnFindHome.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFindHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnFindHome.Location = new System.Drawing.Point(640, 409);
            this.btnFindHome.Name = "btnFindHome";
            this.btnFindHome.Size = new System.Drawing.Size(100, 45);
            this.btnFindHome.TabIndex = 9;
            this.btnFindHome.Text = "Find Home";
            this.btnFindHome.UseVisualStyleBackColor = false;
            this.btnFindHome.Visible = false;
            this.btnFindHome.Click += new System.EventHandler(this.btnFindHome_Click);
            // 
            // btnPark
            // 
            this.btnPark.BackColor = System.Drawing.Color.Black;
            this.btnPark.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPark.Location = new System.Drawing.Point(640, 483);
            this.btnPark.Name = "btnPark";
            this.btnPark.Size = new System.Drawing.Size(100, 45);
            this.btnPark.TabIndex = 10;
            this.btnPark.Text = "Park";
            this.btnPark.UseVisualStyleBackColor = false;
            this.btnPark.Click += new System.EventHandler(this.btnPark_Click);
            // 
            // btnHomeSync
            // 
            this.btnHomeSync.BackColor = System.Drawing.Color.Black;
            this.btnHomeSync.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHomeSync.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnHomeSync.Location = new System.Drawing.Point(640, 557);
            this.btnHomeSync.Name = "btnHomeSync";
            this.btnHomeSync.Size = new System.Drawing.Size(100, 45);
            this.btnHomeSync.TabIndex = 11;
            this.btnHomeSync.Text = "Home Sync";
            this.btnHomeSync.UseVisualStyleBackColor = false;
            this.btnHomeSync.Visible = false;
            this.btnHomeSync.Click += new System.EventHandler(this.btnHomeSync_Click);
            // 
            // btnSlew
            // 
            this.btnSlew.BackColor = System.Drawing.Color.Black;
            this.btnSlew.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSlew.ForeColor = System.Drawing.Color.Yellow;
            this.btnSlew.Location = new System.Drawing.Point(33, 343);
            this.btnSlew.Name = "btnSlew";
            this.btnSlew.Size = new System.Drawing.Size(120, 45);
            this.btnSlew.TabIndex = 12;
            this.btnSlew.Text = "Slew";
            this.btnSlew.UseVisualStyleBackColor = false;
            this.btnSlew.Click += new System.EventHandler(this.btnSlew_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.Black;
            this.btnAbort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAbort.ForeColor = System.Drawing.Color.Red;
            this.btnAbort.Location = new System.Drawing.Point(193, 343);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(120, 45);
            this.btnAbort.TabIndex = 13;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(30, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 30);
            this.label1.TabIndex = 14;
            this.label1.Text = "R.A.:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInRA
            // 
            this.txtInRA.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInRA.ForeColor = System.Drawing.Color.Black;
            this.txtInRA.Location = new System.Drawing.Point(118, 210);
            this.txtInRA.Name = "txtInRA";
            this.txtInRA.Size = new System.Drawing.Size(110, 26);
            this.txtInRA.TabIndex = 15;
            this.txtInRA.Text = "00:00:00.00";
            this.txtInRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInDEC
            // 
            this.txtInDEC.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInDEC.ForeColor = System.Drawing.Color.Black;
            this.txtInDEC.Location = new System.Drawing.Point(118, 250);
            this.txtInDEC.Name = "txtInDEC";
            this.txtInDEC.Size = new System.Drawing.Size(110, 26);
            this.txtInDEC.TabIndex = 17;
            this.txtInDEC.Text = "+00:00:00.0";
            this.txtInDEC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(30, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 30);
            this.label2.TabIndex = 16;
            this.label2.Text = "DEC.:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(30, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 30);
            this.label3.TabIndex = 18;
            this.label3.Text = "Epoch.:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbInEpoch
            // 
            this.cmbInEpoch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbInEpoch.ForeColor = System.Drawing.Color.Black;
            this.cmbInEpoch.FormattingEnabled = true;
            this.cmbInEpoch.Items.AddRange(new object[] {
            "J2000",
            "Real"});
            this.cmbInEpoch.Location = new System.Drawing.Point(118, 290);
            this.cmbInEpoch.Name = "cmbInEpoch";
            this.cmbInEpoch.Size = new System.Drawing.Size(110, 24);
            this.cmbInEpoch.TabIndex = 19;
            this.cmbInEpoch.Text = "2000";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(263, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 30);
            this.label4.TabIndex = 20;
            this.label4.Text = "S.T.:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblST
            // 
            this.lblST.BackColor = System.Drawing.Color.Black;
            this.lblST.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblST.ForeColor = System.Drawing.Color.Lime;
            this.lblST.Location = new System.Drawing.Point(348, 210);
            this.lblST.Name = "lblST";
            this.lblST.Size = new System.Drawing.Size(120, 30);
            this.lblST.TabIndex = 21;
            this.lblST.Text = "00:00:00.00";
            this.lblST.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.Black;
            this.lblState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblState.Location = new System.Drawing.Point(583, 210);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(120, 30);
            this.lblState.TabIndex = 23;
            this.lblState.Text = "Error";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(498, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 30);
            this.label6.TabIndex = 22;
            this.label6.Text = "Stat:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRA
            // 
            this.lblRA.BackColor = System.Drawing.Color.Black;
            this.lblRA.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRA.ForeColor = System.Drawing.Color.Lime;
            this.lblRA.Location = new System.Drawing.Point(348, 250);
            this.lblRA.Name = "lblRA";
            this.lblRA.Size = new System.Drawing.Size(120, 30);
            this.lblRA.TabIndex = 25;
            this.lblRA.Text = "00:00:00.00";
            this.lblRA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(263, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 30);
            this.label7.TabIndex = 24;
            this.label7.Text = "R.A.:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDEC
            // 
            this.lblDEC.BackColor = System.Drawing.Color.Black;
            this.lblDEC.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDEC.ForeColor = System.Drawing.Color.Lime;
            this.lblDEC.Location = new System.Drawing.Point(583, 250);
            this.lblDEC.Name = "lblDEC";
            this.lblDEC.Size = new System.Drawing.Size(120, 30);
            this.lblDEC.TabIndex = 27;
            this.lblDEC.Text = "+00:00:00.0";
            this.lblDEC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(498, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 30);
            this.label8.TabIndex = 26;
            this.label8.Text = "DEC.:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEle
            // 
            this.lblEle.BackColor = System.Drawing.Color.Black;
            this.lblEle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEle.ForeColor = System.Drawing.Color.Lime;
            this.lblEle.Location = new System.Drawing.Point(583, 290);
            this.lblEle.Name = "lblEle";
            this.lblEle.Size = new System.Drawing.Size(120, 30);
            this.lblEle.TabIndex = 31;
            this.lblEle.Text = "00.0000";
            this.lblEle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(498, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 30);
            this.label9.TabIndex = 30;
            this.label9.Text = "Ele.:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAzi
            // 
            this.lblAzi.BackColor = System.Drawing.Color.Black;
            this.lblAzi.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAzi.ForeColor = System.Drawing.Color.Lime;
            this.lblAzi.Location = new System.Drawing.Point(348, 290);
            this.lblAzi.Name = "lblAzi";
            this.lblAzi.Size = new System.Drawing.Size(120, 30);
            this.lblAzi.TabIndex = 29;
            this.lblAzi.Text = "000.0000";
            this.lblAzi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(263, 290);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 30);
            this.label11.TabIndex = 28;
            this.label11.Text = "AZI.:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFocusTarget);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblFocus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnFocusMinus);
            this.groupBox1.Controls.Add(this.btnFocusPlus);
            this.groupBox1.Controls.Add(this.chkAbsFocus);
            this.groupBox1.Controls.Add(this.txtInFocus);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(30, 443);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 222);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Focuser";
            // 
            // lblFocus
            // 
            this.lblFocus.BackColor = System.Drawing.Color.Black;
            this.lblFocus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFocus.ForeColor = System.Drawing.Color.Lime;
            this.lblFocus.Location = new System.Drawing.Point(133, 140);
            this.lblFocus.Name = "lblFocus";
            this.lblFocus.Size = new System.Drawing.Size(100, 30);
            this.lblFocus.TabIndex = 30;
            this.lblFocus.Text = "0.0";
            this.lblFocus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(14, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 30);
            this.label5.TabIndex = 22;
            this.label5.Text = "Position:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFocusMinus
            // 
            this.btnFocusMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFocusMinus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFocusMinus.ForeColor = System.Drawing.Color.Red;
            this.btnFocusMinus.Location = new System.Drawing.Point(169, 93);
            this.btnFocusMinus.Name = "btnFocusMinus";
            this.btnFocusMinus.Size = new System.Drawing.Size(100, 30);
            this.btnFocusMinus.TabIndex = 21;
            this.btnFocusMinus.Text = "--";
            this.btnFocusMinus.UseVisualStyleBackColor = false;
            this.btnFocusMinus.Click += new System.EventHandler(this.btnFocusMinus_Click);
            // 
            // btnFocusPlus
            // 
            this.btnFocusPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFocusPlus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFocusPlus.ForeColor = System.Drawing.Color.Red;
            this.btnFocusPlus.Location = new System.Drawing.Point(14, 93);
            this.btnFocusPlus.Name = "btnFocusPlus";
            this.btnFocusPlus.Size = new System.Drawing.Size(100, 30);
            this.btnFocusPlus.TabIndex = 20;
            this.btnFocusPlus.Text = "++";
            this.btnFocusPlus.UseVisualStyleBackColor = false;
            this.btnFocusPlus.Click += new System.EventHandler(this.btnFocusPlus_Click);
            // 
            // chkAbsFocus
            // 
            this.chkAbsFocus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkAbsFocus.Location = new System.Drawing.Point(169, 40);
            this.chkAbsFocus.Name = "chkAbsFocus";
            this.chkAbsFocus.Size = new System.Drawing.Size(100, 30);
            this.chkAbsFocus.TabIndex = 19;
            this.chkAbsFocus.Text = "Absolute";
            this.chkAbsFocus.UseVisualStyleBackColor = true;
            // 
            // txtInFocus
            // 
            this.txtInFocus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInFocus.ForeColor = System.Drawing.Color.Black;
            this.txtInFocus.Location = new System.Drawing.Point(34, 40);
            this.txtInFocus.Name = "txtInFocus";
            this.txtInFocus.Size = new System.Drawing.Size(80, 26);
            this.txtInFocus.TabIndex = 18;
            this.txtInFocus.Text = "0";
            this.txtInFocus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNetwork
            // 
            this.lblNetwork.BackColor = System.Drawing.Color.Black;
            this.lblNetwork.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNetwork.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblNetwork.Location = new System.Drawing.Point(583, 330);
            this.lblNetwork.Name = "lblNetwork";
            this.lblNetwork.Size = new System.Drawing.Size(120, 30);
            this.lblNetwork.TabIndex = 34;
            this.lblNetwork.Text = "DisConnect";
            this.lblNetwork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(498, 330);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 30);
            this.label12.TabIndex = 33;
            this.label12.Text = "Network:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.Location = new System.Drawing.Point(320, 409);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(310, 256);
            this.txtLog.TabIndex = 35;
            // 
            // tmrNTP
            // 
            this.tmrNTP.Interval = 60000;
            this.tmrNTP.Tick += new System.EventHandler(this.tmrNTP_Tick);
            // 
            // tmrNet
            // 
            this.tmrNet.Interval = 1000;
            this.tmrNet.Tick += new System.EventHandler(this.tmrNet_Tick);
            // 
            // tmrMain
            // 
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // tmrFocus
            // 
            this.tmrFocus.Interval = 500;
            this.tmrFocus.Tick += new System.EventHandler(this.tmrFocus_Tick);
            // 
            // lblFocusTarget
            // 
            this.lblFocusTarget.BackColor = System.Drawing.Color.Black;
            this.lblFocusTarget.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFocusTarget.ForeColor = System.Drawing.Color.Lime;
            this.lblFocusTarget.Location = new System.Drawing.Point(133, 180);
            this.lblFocusTarget.Name = "lblFocusTarget";
            this.lblFocusTarget.Size = new System.Drawing.Size(100, 30);
            this.lblFocusTarget.TabIndex = 32;
            this.lblFocusTarget.Text = "0.0";
            this.lblFocusTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(14, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 30);
            this.label13.TabIndex = 31;
            this.label13.Text = "Target:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 688);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblNetwork);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEle);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblAzi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblDEC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblRA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblST);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbInEpoch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInDEC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInRA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSlew);
            this.Controls.Add(this.btnHomeSync);
            this.Controls.Add(this.btnPark);
            this.Controls.Add(this.btnFindHome);
            this.Controls.Add(this.procSlew);
            this.Controls.Add(this.btnNTP);
            this.Controls.Add(this.btnConfigSystem);
            this.Controls.Add(this.btnLinkFocuser);
            this.Controls.Add(this.btnLinkTelescope);
            this.Controls.Add(this.btnLinkServer);
            this.Controls.Add(this.btnSelectFocuser);
            this.Controls.Add(this.btnSelectTelescope);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "DDMAgent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConfigSystem;
        private System.Windows.Forms.Button btnSelectTelescope;
        private System.Windows.Forms.Button btnSelectFocuser;
        private System.Windows.Forms.Button btnLinkServer;
        private System.Windows.Forms.Button btnLinkTelescope;
        private System.Windows.Forms.Button btnLinkFocuser;
        private System.Windows.Forms.Button btnNTP;
        private System.Windows.Forms.ProgressBar procSlew;
        private System.Windows.Forms.Button btnFindHome;
        private System.Windows.Forms.Button btnPark;
        private System.Windows.Forms.Button btnHomeSync;
        private System.Windows.Forms.Button btnSlew;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInRA;
        private System.Windows.Forms.TextBox txtInDEC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbInEpoch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblST;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDEC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAzi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFocus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFocusMinus;
        private System.Windows.Forms.Button btnFocusPlus;
        private System.Windows.Forms.CheckBox chkAbsFocus;
        private System.Windows.Forms.TextBox txtInFocus;
        private System.Windows.Forms.Label lblNetwork;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Timer tmrNTP;
        private System.Windows.Forms.Timer tmrNet;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Timer tmrFocus;
        private System.Windows.Forms.Label lblFocusTarget;
        private System.Windows.Forms.Label label13;
    }
}

