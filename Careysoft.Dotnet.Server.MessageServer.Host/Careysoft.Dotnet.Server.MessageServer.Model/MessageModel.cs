using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Model
{
    [Serializable]
    public class MessageModel
    {
        public MessageModel(EnumCommand command, string body) {
            m_Command = command;
            m_Body = body;
        }

        public MessageModel(string message)
        {
            if (String.IsNullOrEmpty(message))
            {
                return;
            }
            string[] strArray = message.Split(' ');
            m_Command = (EnumCommand)Enum.Parse(typeof(EnumCommand), strArray[0]);
            if (strArray.Length > 1)
            {
                m_Body = message.Substring(message.IndexOf(" ") + 1);
            }
        }

        private EnumCommand m_Command;
        public EnumCommand Command
        {
            get { return m_Command; }
            set { m_Command = value; }
        }

        private string m_Body;
        public string Body
        {
            get { return m_Body; }
            set { m_Body = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", m_Command, m_Body);
        }
    }
}
