using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Photon.SocketServer;
using Common.Tools;
using MyGameServer.Manager;

namespace MyGameServer.Handler
{
    class LoginHandler:BaseHandler
    {
        public LoginHandler()
        {
            OpCode = OperationCode.Login;
        }
        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            string username = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Username) as string;
            string password = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Password) as string;
            UserManager manager = new UserManager();
            bool isSuccess = manager.VerifyUser(username, password);

            OperationResponse response = new OperationResponse(operationRequest.OperationCode);
            if (isSuccess)
            {
                response.ReturnCode = (short)Common.ReturnCode.Success;
                peer.username = username;
            }
            else
            {
                response.ReturnCode = (short)Common.ReturnCode.Failed;
            }
            peer.SendOperationResponse(response, sendParameters);
        }
    }
}
