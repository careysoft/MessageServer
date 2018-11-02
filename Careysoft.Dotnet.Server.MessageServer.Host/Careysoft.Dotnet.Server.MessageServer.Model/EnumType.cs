using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Model
{
    public enum EnumMessageInfo { 
        Log,
        Error
    }

    public enum EnumCommand { 
        AuthQuestion, //请求验证
        AuthUser, //开始验证
        AuthAccept, //接受
        Status, //状态心跳 默认回复
        MessagePoint, //点对点发送
        MessageGroup  //组播发送
    }

    public enum EnumClientType
    {
        WeChat,
        Normal,
        None
    }

    public enum EnumMessageType { 
        Point,
        Group
    }

    public enum EnumMessageContentType { 
        Text
    }
}
