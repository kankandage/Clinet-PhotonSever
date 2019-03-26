using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Photon.SocketServer;
using Common.Tools;
using MyGameServer.Manager;
using MyGameServer.Model;

namespace MyGameServer.Handler
{
    class RegisterHandler:BaseHandler
    {
        public RegisterHandler()
        {
            OpCode = OperationCode.Register;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            string username = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Username) as string;
            string password = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Password) as string;
            UserManager manager = new UserManager();
            User user = manager.GetByUsername(username);
            OperationResponse response = new OperationResponse( operationRequest.OperationCode );
            if (user == null)
            {
                user= new User(){Username=username,Password=password};
                manager.Add(user);
                response.ReturnCode =(short) ReturnCode.Success;
            }
            else
            {
                response.ReturnCode = (short)ReturnCode.Failed;
            }
            peer.SendOperationResponse(response, sendParameters);
        }
    }
}
