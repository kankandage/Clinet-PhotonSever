using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using ExitGames.Client.Photon;

public abstract class BaseEvent : MonoBehaviour {

    public EventCode EventCode;

    public abstract void OnEvent(EventData eventData);

    public virtual void Start()
    {
        PhotonEngine.Instance.AddEvent(this);
    }
    public void OnDestroy()
    {
        PhotonEngine.Instance.RemoveEvent(this);
    }
}
