using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Careysoft.Dotnet.Server.MessageServer.Client
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        private MessageSocketClient ms = null;
        public FormMain()
        {
            InitializeComponent();
            ms = new MessageSocketClient("127.0.0.1", "10015");
            ms.EventClientOpened += new EventHandler(ms_EventClientOpened);
            ms.EventClientClosed += new EventHandler(ms_EventClientClosed);
        }

        void ms_EventClientClosed(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    btn_connect.Enabled = true;
                    btn_sendText.Enabled = false;
                });
            }
        }

        void ms_EventClientOpened(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    btn_connect.Enabled = false;
                    btn_sendText.Enabled = true;
                });
            }
        }

        private void btn_sendText_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_memo.Text.Trim())) {
                XtraMessageBox.Show("请输入要发送的内容");
                txt_memo.Focus();
                return;
            }
            ms.SendWeiXinMessage("blackeye", txt_memo.Text);
        }

        protected override void OnClosed(EventArgs e)
        {
            ms.Close();
            base.OnClosed(e);
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            ms.Connect();
        }
    }
}