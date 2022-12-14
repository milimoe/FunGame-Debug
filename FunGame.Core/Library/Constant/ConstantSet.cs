using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milimoe.FunGame.Core.Library.Constant
{
    public class InterfaceSet
    {
        public class Type
        {
            public const string IClient = "IClientImpl";
            public const string IServer = "IServerImpl";
        }

        public class Method
        {
            public const string RemoteServerIP = "RemoteServerIP";
            public const string DBConnection = "DBConnection";
            public const string GetServerSettings = "GetServerSettings";
        }
    }

    public class SocketSet
    {
        public const int MaxRetryTimes = 20;
        public const int MaxConnection_1C2G = 10;
        public const int MaxConnection_General = 20;
        public const int MaxConnection_4C4G = 40;

        public const string Unknown = "Unknown";
        public const string Connect = "Connect";
        public const string GetNotice = "GetNotice";
        public const string Login = "Login";
        public const string CheckLogin = "CheckLogin";
        public const string Logout = "Logout";
        public const string Disconnect = "Disconnect";
        public const string HeartBeat = "HeartBeat";
    }

    public class ReflectionSet
    {
        public const string FUNGAME_IMPL = "FunGame.Implement";
        public static string EXEFolderPath { get; } = Environment.CurrentDirectory.ToString() + "\\"; // 程序目录
        public static string PluginFolderPath { get; } = Environment.CurrentDirectory.ToString() + "\\plugins\\"; // 插件目录
    }
}
