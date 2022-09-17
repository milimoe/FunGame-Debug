using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace FunGame.Core.Api.Model.Enum
{
    /**
     * �����ſ��ʵ����ص�State Type Result Method
     * ���FunGame.Core.Api�ӿں�ʵ��ʱ����Ҫ������ͬ����ӣ�InterfaceType��InterfaceMethod
     */

    #region State

    public enum StartMatch_State
    {
        Matching,
        Success,
        Enable,
        Cancel
    }

    public enum CreateRoom_State
    {
        Creating,
        Success
    }

    public enum RoomState
    {
        Created,
        Gaming,
        Close,
        Complete
    }

    public enum OnlineState
    {
        Offline,
        Online,
        Matching,
        InRoom,
        Gaming
    }

    public enum ClientState
    {
        Online,
        WaitConnect,
        WaitLogin
    }

    #endregion

    #region Type

    public enum RoomType
    {
        Mix,
        Team,
        MixHasPass,
        TeamHasPass
    }

    public enum MessageButtonType
    {
        OK,
        OKCancel,
        YesNo,
        RetryCancel
    }

    public enum InterfaceType
    {
        ClientConnectInterface,
        ServerInterface
    }

    public enum LightType
    {
        Green,
        Yellow,
        Red
    }

    public enum SocketMessageType
    {
        Unknown,
        GetNotice,
        Login,
        CheckLogin,
        Logout,
        HeartBeat
    }

    #endregion

    #region Result

    public enum MessageResult
    {
        OK,
        Cancel,
        Yes,
        No,
        Retry
    }

    #endregion

    #region Method

    public enum WebHelperMethod
    {
        CreateSocket,
        CloseSocket,
        StartWebHelper,
        Login,
        Logout
    }

    public enum InterfaceMethod
    {
        RemoteServerIP,
        DBConnection,
        GetServerSettings
    }

    #endregion

    
    public class EnumHelper
    {
        #region ���߷���

        /// <summary>
        /// ��ȡʵ��������
        /// </summary>
        /// <param name="Interface">�ӿڴ���</param>
        /// <returns></returns>
        public static string GetImplementClassName(int Interface)
        {
            foreach (string str in System.Enum.GetNames(typeof(InterfaceType)))
            {
                InterfaceType temp = (InterfaceType)System.Enum.Parse(typeof(InterfaceType), Interface.ToString(), true);
                if (temp.ToString() == str)
                    return temp + "Impl";
            }
            return "";
        }

        /// <summary>
        /// ��ȡʵ����ķ�����
        /// </summary>
        /// <param name="Method">��������</param>
        /// <returns></returns>
        public static string GetImplementMethodName(int Method)
        {
            foreach (string str in System.Enum.GetNames(typeof(InterfaceMethod)))
            {
                InterfaceMethod temp = (InterfaceMethod)System.Enum.Parse(typeof(InterfaceMethod), Method.ToString(), true);
                if (temp.ToString() == str)
                    return temp.ToString();
            }
            return "";
        }

        /// <summary>
        /// ��ȡSocketö����
        /// </summary>
        /// <param name="SocketType">Socketö��</param>
        /// <returns></returns>
        public static string GetSocketTypeName(int SocketType)
        {
            foreach (string str in System.Enum.GetNames(typeof(SocketMessageType)))
            {
                SocketMessageType temp = (SocketMessageType)System.Enum.Parse(typeof(SocketMessageType), SocketType.ToString(), true);
                if (temp.ToString() == str)
                    return temp.ToString();
            }
            return "";
        }

        #endregion
    }
}
