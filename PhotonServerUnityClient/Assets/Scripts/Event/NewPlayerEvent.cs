using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Common.Tools;
using Common;

public class NewPlayerEvent :BaseEvent {

    private Player player;

    public override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }

    public override void OnEvent(EventData eventData)
    {
        string username = (string)DictTool.GetValue<byte, object>(eventData.Parameters,(byte) ParameterCode.Username);
        player.OnNewPlayerEvent(username);
    }
}
