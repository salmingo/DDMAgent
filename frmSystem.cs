using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDMAgent
{
    public partial class frmSystem : Form
    {
        private frmMain myParent;

        public frmSystem(frmMain parent)
        {
            InitializeComponent();
            myParent = parent;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // 保存参数
            myParent.gid_ = txtIDGroup.Text;
            myParent.uid_ = txtIDUnit.Text;
            myParent.ip_server_ = txtServerIP.Text;
            myParent.port_server_ = Convert.ToUInt16(txtServerPort.Text);
            myParent.ip_ntp_ = txtNTPIP.Text;
            myParent.clock_sync_ = chkClockSync.Checked;
            myParent.modified_ = true;
            Close();
        }

        private void frmSystem_Load(object sender, EventArgs e)
        {
            // 加载参数
            txtIDGroup.Text = myParent.gid_;
            txtIDUnit.Text = myParent.uid_;
            txtServerIP.Text = myParent.ip_server_;
            txtServerPort.Text = Convert.ToString(myParent.port_server_);
            txtNTPIP.Text = myParent.ip_ntp_;
            chkClockSync.Checked = myParent.clock_sync_;
        }
    }
}
