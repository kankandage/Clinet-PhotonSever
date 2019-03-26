using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class SyncPositionRequest :Request {

    [HideInInspector]
    public Vector3 pos;

    public override void DefaultRequest()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        //data.Add((byte)ParameterCode.Position, new Vector3Data() { x=pos.x,y=pos.y,z = pos.z});
        data.Add((byte)ParameterCode.X, pos.x);
        data.Add((byte)ParameterCode.Y, pos.y);
        data.Add((byte)ParameterCode.Z, pos.z);
        PhotonEngine.Peer.OpCustom((byte)OpCode, data, true);
    }

    public override void OnOperationResponse(ExitGames.Client.Photon.OperationResponse operationResponse)
    {
        throw new System.NotImplementedException();
    }
}
