using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCam : MonoBehaviour {

	Vector3 offSet = new Vector3(0,0,-8);
	public Transform playerTransform;

	void Update () {

		if (playerTransform != null) {

			transform.position = Vector3.Lerp(transform.position, playerTransform.position + offSet, 3.0f * Time.deltaTime);
		}
	}

	public void setTarget (Transform target) {

		playerTransform = target;
	}
}
