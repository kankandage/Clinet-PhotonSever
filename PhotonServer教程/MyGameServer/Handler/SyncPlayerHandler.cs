using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Photon.SocketServer;
using System.Xml.Serialization;
using System.IO;

namespace MyGameServer.Handler
{
    class SyncPlayerHandler:BaseHandler
    {
        public SyncPlayerHandler()
        {
            OpCode = OperationCode.SyncPlayer;
        }
        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            //取得所有已经登录（在线玩家）的用户名
            List<string> usernameList = new List<string>();
            foreach (ClientPeer tempPeer in MyGameServer.Instance.peerList)
            {
                if (string.IsNullOrEmpty(tempPeer.username) == false &&tempPeer!=peer)
                {
                    usernameList.Add(tempPeer.username);
                }
            }
            
            StringWriter sw = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            serializer.Serialize(sw, usernameList);
            sw.Close();
            string usernameListString = sw.ToString();
            //MyGameServer.log.Info(usernameListString);

            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add((byte)ParameterCode.UsernameList, usernameListString);
            OperationResponse response = new OperationResponse(operationRequest.OperationCode);
            response.Parameters = data;
            peer.SendOperationResponse(response,sendParameters);

            //告诉其他客户端有新的客户端加入
            foreach (ClientPeer tempPeer in MyGameServer.Instance.peerList)
            {
                if (string.IsNullOrEmpty(tempPeer.username) == false && tempPeer != peer)
                {
                    EventData ed = new EventData( (byte) EventCode.NewPlayer);
                    Dictionary<byte,object> data2 = new Dictionary<byte,object>();
                    data2.Add( (byte)ParameterCode.Username, peer.username );
                    ed.Parameters=data2;
                    tempPeer.SendEvent(ed, sendParameters);
                }
            }
        }
    }
}
