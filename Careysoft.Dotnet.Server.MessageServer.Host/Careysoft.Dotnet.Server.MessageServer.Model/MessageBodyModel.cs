using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Model
{
    public class MessageHeaderModel {
        private string m_TargetCode;
        public string TargetCode {
            get { return m_TargetCode; }
            set { m_TargetCode = value; }
        }

        private Model.EnumClientType m_TagetType;
        public Model.EnumClientType TagetType {
            get { return m_TagetType; }
            set { m_TagetType = value; }
        }

        private string m_SourceCode;
        public string SourceCode
        {
            get { return m_SourceCode; }
            set { m_SourceCode = value; }
        }

        private Model.EnumMessageType m_MessageType;
        public Model.EnumMessageType MessageType
        {
            get { return m_MessageType; }
            set { m_MessageType = value; }
        }

    }

    public class MessageBodyModel
    {
        private Model.MessageHeaderModel m_Header = new MessageHeaderModel();
        public Model.MessageHeaderModel Header {
            get { return m_Header; }
            set { m_Header = value; }
        }

        private Model.EnumMessageContentType m_MessageContentType;
        public Model.EnumMessageContentType MessageContentType {
            get { return m_MessageContentType; }
            set { m_MessageContentType = value; }
        }

        private string m_MessageContent;
        public string MessageContent {
            get { return m_MessageContent; }
            set { m_MessageContent = value; }
        }
    }
}
