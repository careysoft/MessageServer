namespace Careysoft.Dotnet.Server.MessageServer.Svc
{
    partial class InstallerMessageServer
    {
        private System.ServiceProcess.ServiceProcessInstaller WorkProcessInstaller;

        private System.ServiceProcess.ServiceInstaller WorkServiceInstaller;
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.WorkProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.WorkServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            ////   
            //// WorkListProcessInstaller  
            ////   
            this.WorkProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.WorkProcessInstaller.Password = null;
            this.WorkProcessInstaller.Username = null;
            ////   
            //// WorkListServiceInstaller  
            ////   
            this.WorkServiceInstaller.Description = "消息服务";//ConfigurationManager.AppSettings["Description"];
            this.WorkServiceInstaller.DisplayName = "消息服务";//ConfigurationManager.AppSettings["DisplayName"];
            this.WorkServiceInstaller.ServiceName = "MessageSvc";//ConfigurationManager.AppSettings["InstallServiceName"];
            this.WorkServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            ////   
            //// ProjectInstaller  
            ////   
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {  
            this.WorkProcessInstaller,  
            this.WorkServiceInstaller});
            components = new System.ComponentModel.Container();
        }

        #endregion
    }
}