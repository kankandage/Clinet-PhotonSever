using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Common;

public class LoginRequest : Request {
    [HideInInspector]
    public string Username;
    [HideInInspector]
    public string Password;

    private LoginPanel loginPanel;

    public override void Start()
    {
        base.Start();
        loginPanel = GetComponent<LoginPanel>();
    }

    public override void DefaultRequest()
    {
        Dictionary<byte,object> data = new Dictionary<byte,object>();
        data.Add((byte)ParameterCode.Username, Username);
        data.Add((byte)ParameterCode.Password, Password);
        PhotonEngine.Peer.OpCustom((byte)OpCode, data, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        ReturnCode returnCode = (ReturnCode)operationResponse.ReturnCode;
        if (returnCode == ReturnCode.Success)
        {
            PhotonEngine.username = Username;
        }
        loginPanel.OnLoginResponse(returnCode);
    }
}
