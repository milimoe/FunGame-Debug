using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Milimoe.FunGame.Core.Interface.Base;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using Milimoe.FunGame.Core.Library.Constant;

namespace Milimoe.FunGame.Core.Service
{
    internal class SocketManager
    {
        /// <summary>
        /// 客户端专用Socket
        /// </summary>
        internal static Socket? Socket { get; private set; } = null;

        /// <summary>
        /// 服务器端专用Socket
        /// </summary>
        internal static Socket? ServerSocket { get; private set; } = null;

        /// <summary>
        /// 创建服务器监听Socket
        /// </summary>
        /// <param name="Port">监听端口号</param>
        /// <param name="MaxConnection">最大连接数量</param>
        /// <returns>服务器端专用Socket</returns>
        internal static Socket? StartListening(int Port = 22222, int MaxConnection = 0)
        {
            if (MaxConnection <= 0) MaxConnection = SocketSet.MaxConnection_General;
            try
            {
                ServerSocket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ServerEndPoint = new(IPAddress.Any, Port);
                ServerSocket.Bind(ServerEndPoint);
                ServerSocket.Listen(MaxConnection);
                return ServerSocket;
            }
            catch
            {
                ServerSocket?.Close();
            }
            return null;
        }

        /// <summary>
        /// 创建一个监听到客户端Socket
        /// </summary>
        /// <returns>客户端IP地址[0]和客户端Socket[1]</returns>
        internal static object[] Accept()
        {
            if (ServerSocket is null) return Array.Empty<object>();
            Socket Client;
            string ClientIP;
            try
            {
                Client = ServerSocket.Accept();
                IPEndPoint? ClientIPEndPoint = (IPEndPoint?)Client.RemoteEndPoint;
                ClientIP = (ClientIPEndPoint != null) ? ClientIPEndPoint.ToString() : "Unknown";
                return new object[] { ClientIP, Client };
            }
            catch
            {
                ServerSocket?.Close();
            }
            return Array.Empty<object>();
        }

        /// <summary>
        /// 创建客户端Socket
        /// </summary>
        /// <param name="IP">服务器IP地址</param>
        /// <param name="Port">服务器监听端口</param>
        /// <returns>客户端专用Socket</returns>
        internal static Socket? Connect(string IP, int Port = 22222)
        {
            Socket? ClientSocket;
            EndPoint ServerEndPoint;
            try
            {
                ClientSocket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServerEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
                if (ServerEndPoint != null)
                {
                    while (true)
                    {
                        if (!ClientSocket.Connected)
                        {
                            ClientSocket.Connect(ServerEndPoint);
                            if (ClientSocket.Connected)
                            {
                                Socket = ClientSocket;
                                return Socket;
                            }
                        }
                    }
                }
            }
            catch
            {
                Socket?.Close();
            }
            return null;
        }
        
        /// <summary>
        /// 用于服务器端向客户端Socket发送信息
        /// </summary>
        /// <param name="ClientSocket">客户端Socket</param>
        /// <param name="type">通信类型</param>
        /// <param name="objs">参数</param>
        /// <returns>通信结果</returns>
        internal static SocketResult Send(Socket ClientSocket, SocketMessageType type, string token, object[] objs)
        {
            if (ClientSocket != null && objs != null && objs.Length > 0)
            {
                if (ClientSocket.Send(General.DEFAULT_ENCODING.GetBytes(Library.Common.Network.JsonObject.GetString(type, token, objs))) > 0)
                {
                    return SocketResult.Success;
                }
                else return SocketResult.Fail;
            }
            return SocketResult.NotSent;
        }

        /// <summary>
        /// 用于客户端向服务器Socket发送信息
        /// </summary>
        /// <param name="type">通信类型</param>
        /// <param name="objs">参数</param>
        /// <returns>通信结果</returns>
        internal static SocketResult Send(SocketMessageType type, string token, object[] objs)
        {
            if (objs is null || objs.Length <= 0)
            {
                objs = new object[] { "" };
            }
            if (Socket != null)
            {
                if (Socket.Send(General.DEFAULT_ENCODING.GetBytes(Library.Common.Network.JsonObject.GetString(type, token, objs))) > 0)
                {
                    return SocketResult.Success;
                }
                else return SocketResult.Fail;
            }
            return SocketResult.NotSent;
        }

        /// <summary>
        /// 用于客户端接收服务器信息
        /// </summary>
        /// <returns>通信类型[0]和参数[1]</returns>
        internal static object[] Receive()
        {
            object[] result = Array.Empty<object>();
            if (Socket != null)
            {
                // 从服务器接收消息
                byte[] buffer = new byte[2048];
                int length = Socket.Receive(buffer);
                if (length > 0)
                {
                    string msg = General.DEFAULT_ENCODING.GetString(buffer, 0, length);
                    Library.Common.Network.JsonObject? json = Library.Common.Network.JsonObject.GetObject(msg);
                    if (json != null)
                    {
                        result = new object[] { json.MessageType, json.Parameters };
                    }
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// 用于服务器接收客户端信息
        /// </summary>
        /// <param name="ClientSocket">客户端Socket</param>
        /// <returns>通信类型[0]和参数[1]</returns>
        internal static object[] Receive(Socket ClientSocket)
        {
            object[] result = Array.Empty<object>();
            if (ClientSocket != null)
            {
                // 从客户端接收消息
                byte[] buffer = new byte[2048];
                int length = ClientSocket.Receive(buffer);
                if (length > 0)
                {
                    string msg = General.DEFAULT_ENCODING.GetString(buffer, 0, length);
                    Library.Common.Network.JsonObject? json = Library.Common.Network.JsonObject.GetObject(msg);
                    if (json != null)
                    {
                        result = new object[] { json.MessageType, json.Parameters };
                    }
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// 将通信类型的枚举转换为字符串
        /// </summary>
        /// <param name="type">通信类型</param>
        /// <returns>等效字符串</returns>
        internal static string GetTypeString(SocketMessageType type)
        {
            return type switch
            {
                SocketMessageType.Connect => SocketSet.Connect,
                SocketMessageType.GetNotice => SocketSet.GetNotice,
                SocketMessageType.Login => SocketSet.Login,
                SocketMessageType.CheckLogin => SocketSet.CheckLogin,
                SocketMessageType.Logout => SocketSet.Logout,
                SocketMessageType.Disconnect => SocketSet.Disconnect,
                SocketMessageType.HeartBeat => SocketSet.HeartBeat,
                _ => SocketSet.Unknown,
            };
        }
    }
}
