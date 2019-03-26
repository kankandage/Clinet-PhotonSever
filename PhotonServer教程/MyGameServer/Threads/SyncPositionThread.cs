using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common;
using System.Xml.Serialization;
using System.IO;
using Photon.SocketServer;

namespace MyGameServer.Threads
{
    public class SyncPositionThread
    {
        private Thread t;
        public void Run()
        {
            t = new Thread(UpdatePosition);
            t.IsBackground = true;
            t.Start();
        }
        public void Stop()
        {
            t.Abort();
        }

        private void UpdatePosition()
        {
            Thread.Sleep(5000);

            while (true)
            {
                Thread.Sleep(200);
                //进行同步
                SendPosition();
            }
        }
        private void SendPosition()
        {
            List<PlayerData> playerDataList = new List<PlayerData>();
            foreach (ClientPeer peer in MyGameServer.Instance.peerList)
            {
                if (string.IsNullOrEmpty(peer.username) == false)
                {
                    PlayerData playerData = new PlayerData();
                    playerData.Username = peer.username;
                    playerData.Pos = new Vector3Data() { x = peer.x, y = peer.y, z = peer.z };
                    playerDataList.Add(playerData);
                }
            }
            StringWriter sw = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(List<PlayerData>));
            serializer.Serialize(sw, playerDataList);
            sw.Close();
            string playerDataListString = sw.ToString();
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add((byte)ParameterCode.PlayerDataList, playerDataListString);

            foreach (ClientPeer peer in MyGameServer.Instance.peerList)
            {
                if (string.IsNullOrEmpty(peer.username) == false)
                {
                    EventData ed = new EventData((byte) EventCode.SyncPosition );
                    ed.Parameters=data;
                    peer.SendEvent(ed, new SendParameters());
                }
            }
        }
    }
}
