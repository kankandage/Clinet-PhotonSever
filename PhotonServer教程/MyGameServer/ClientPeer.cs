using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using Common.Tools;
using Common;
using MyGameServer.Handler;

namespace MyGameServer
{
    public class ClientPeer:Photon.SocketServer.ClientPeer
    {
        public float x, y, z;
        public string username;

        public ClientPeer(InitRequest initRequest):base(initRequest)
        {

        }

        //处理客户端断开链接的后续工作
        protected override void OnDisconnect(PhotonHostRuntimeInterfaces.DisconnectReason reasonCode, string reasonDetail)
        {
            MyGameServer.Instance.peerList.Remove(this);
        }

        //处理客户端的请求
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            BaseHandler handler = DictTool.GetValue<OperationCode, BaseHandler>(MyGameServer.Instance.HandlerDict, (OperationCode)operationRequest.OperationCode);
            if (handler != null)
            {
                handler.OnOperationRequest(operationRequest, sendParameters, this);
            }
            else
            {
                BaseHandler defaultHandler = DictTool.GetValue<OperationCode, BaseHandler>(MyGameServer.Instance.HandlerDict, OperationCode.Default);
                defaultHandler.OnOperationRequest(operationRequest, sendParameters, this);
            }
            //switch (operationRequest.OperationCode)//通过OpCode区分请求
            //{
            //    case 1:
            //        MyGameServer.log.Info("收到了一个客户端的请求");
            //        Dictionary<byte,object> data = operationRequest.Parameters;
            //        object intValue;
            //        data.TryGetValue(1, out intValue);
            //        object stringValue;
            //        data.TryGetValue(2, out stringValue);
            //        MyGameServer.log.Info("得到的参数数据是 " + intValue.ToString() + stringValue.ToString());
            //        OperationResponse opResponse = new OperationResponse(1);
            //        Dictionary<byte,object> data2 = new Dictionary<byte,object>();
            //        data2.Add(1, 100);
            //        data2.Add(2, "errr230498lkd的数量看风景");
            //        opResponse.SetParameters(data2);
            //        SendOperationResponse(opResponse, sendParameters);//给客户端一个响应
            //        EventData ed = new EventData(1);ed.Parameters=data2;
            //        SendEvent(ed, new SendParameters());
            //        break;
            //    case 2:
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
