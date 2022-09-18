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
        RetryCancel,
        Input
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
        Disconnect,
        HeartBeat
    }

    public enum ErrorType
    {
        None,
        IsNotIP,
        IsNotPort,
        WrongFormat
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

    public enum SocketHelperMethod
    {
        CreateSocket,
        CloseSocket,
        StartSocketHelper,
        Login,
        Logout,
        Disconnect
    }

    public enum InterfaceMethod
    {
        RemoteServerIP,
        DBConnection,
        GetServerSettings
    }

    #endregion

}
