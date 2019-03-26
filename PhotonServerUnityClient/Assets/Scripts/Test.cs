using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SendRequest();
        }
	}
    void SendRequest()
    {
        Dictionary<byte,object> data = new Dictionary<byte,object>();
        data.Add(1, 100);
        data.Add(2, "errr230498lkd的数量看风景");

        PhotonEngine.Peer.OpCustom(1, data, true);
    }
}
