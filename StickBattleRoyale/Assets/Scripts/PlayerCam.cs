using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour {

	public GameObject Player;
	public float ZoomOut;

	Vector2 PlayerPos;

	// Update is called once per frame
	void Update () {

		PlayerPos.x = Player.transform.position.x;
		PlayerPos.y = Player.transform.position.y;

		transform.position = new Vector3 (PlayerPos.x, PlayerPos.y, -ZoomOut);
	}
}
