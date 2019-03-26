using Common;
using UnityEngine;
using ExitGames.Client.Photon;
public abstract class Request:MonoBehaviour  {
    public OperationCode OpCode;
    public abstract void DefaultRequest();
    public abstract void OnOperationResponse(OperationResponse operationResponse);

    public virtual void Start()
    {
        PhotonEngine.Instance.AddRequest(this);
    }
    public void OnDestroy()
    {
        PhotonEngine.Instance.RemoveRequest(this);
    }
}
