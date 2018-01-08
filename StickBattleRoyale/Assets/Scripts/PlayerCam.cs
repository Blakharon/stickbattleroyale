using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCam : NetworkBehaviour {

	public GameObject Player;
	public GameObject Camera;

	public float ZoomOut;

	Vector2 PlayerPos;

	void Start () {

		if (isLocalPlayer) {
			return;
		}

		Camera.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer) {

			return;
		}

		PlayerPos.x = Player.transform.position.x;
		PlayerPos.y = Player.transform.position.y;

		Camera.transform.position = new Vector3 (PlayerPos.x, PlayerPos.y, -ZoomOut);
	}
}
