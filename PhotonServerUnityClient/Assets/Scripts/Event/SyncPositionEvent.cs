using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Common;
using Common.Tools;
using System.Xml.Serialization;
using System.IO;

public class SyncPositionEvent :BaseEvent {

    private Player player;

    public override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }
    public override void OnEvent(EventData eventData)
    {
        string playerDataListString =(string) DictTool.GetValue<byte, object>(eventData.Parameters, (byte)ParameterCode.PlayerDataList);

        using (StringReader reader = new StringReader(playerDataListString))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PlayerData>));
            List<PlayerData> playerDataList = (List<PlayerData>)serializer.Deserialize(reader);
            player.OnSyncPositionEvent(playerDataList);
        }
    }
}
