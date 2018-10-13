using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Model
{
    public class MsgRequestModel
    {
        public MsgRequestModel(string message)
        {
            if (String.IsNullOrEmpty(message))
            {
                return;
            }
            string[] strArray = message.Split(' ');
            m_Command = strArray[0];
            if (strArray.Length > 1)
            {
                m_Info = message.Substring(message.IndexOf(" ") + 1);
            }
        }

        private string m_Command;
        public string Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }

        private string m_Info;
        public string Info
        {
            get { return m_Info; }
            set { m_Info = value; }
        }
    }
}
