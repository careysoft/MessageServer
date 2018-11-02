namespace Careysoft.Dotnet.Server.MessageServer.Client
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_sendText = new DevExpress.XtraEditors.SimpleButton();
            this.btn_connect = new DevExpress.XtraEditors.SimpleButton();
            this.txt_memo = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_memo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_sendText
            // 
            this.btn_sendText.Enabled = false;
            this.btn_sendText.Location = new System.Drawing.Point(166, 234);
            this.btn_sendText.Name = "btn_sendText";
            this.btn_sendText.Size = new System.Drawing.Size(125, 33);
            this.btn_sendText.TabIndex = 0;
            this.btn_sendText.Text = "SendText";
            this.btn_sendText.Click += new System.EventHandler(this.btn_sendText_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(21, 234);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(125, 33);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Connect";
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_memo
            // 
            this.txt_memo.EditValue = "Hello world!";
            this.txt_memo.Location = new System.Drawing.Point(21, 23);
            this.txt_memo.Name = "txt_memo";
            this.txt_memo.Size = new System.Drawing.Size(474, 199);
            this.txt_memo.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 279);
            this.Controls.Add(this.txt_memo);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_sendText);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.txt_memo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_sendText;
        private DevExpress.XtraEditors.SimpleButton btn_connect;
        private DevExpress.XtraEditors.MemoEdit txt_memo;
    }
}