using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameServer.Handler
{
    class DefaultHandler:BaseHandler
    {
        public DefaultHandler()
        {
            OpCode = Common.OperationCode.Default;
        }
        public override void OnOperationRequest(Photon.SocketServer.OperationRequest operationRequest, Photon.SocketServer.SendParameters sendParameters, ClientPeer peer)
        {
            throw new NotImplementedException();
        }
    }
}
