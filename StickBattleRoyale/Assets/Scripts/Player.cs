﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

	public GameObject player;

    //Rotating Player
    Vector2 playerPos;
    Vector2 mousePos;
    Vector2 direction;
    float angle;
    //Moving Player
    public float WalkSpeed;
    public float StrafeSpeed;
    private float Vertical;
    private float Horizontal;

	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer) {

			return;
		}

        RotatePlayer ();
		Movement ();
	}

	public override void OnStartLocalPlayer() {

		Camera.main.GetComponent<PlayerCam> ().setTarget (gameObject.transform);
	}

    void RotatePlayer () {

        playerPos = Camera.main.WorldToScreenPoint(player.transform.position);
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        direction = mousePos - playerPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;    //Gets angle between current direction and the direction vector

        player.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); //Rotates towards the angle, for some reason our character is 90degrees off set
    }

	void Movement () {

		Vertical = Input.GetAxis("Vertical");
		if (Vertical >= 0) {
			
			player.transform.Translate (Vector3.up * WalkSpeed * Time.deltaTime * Vertical);
		} else {

			player.transform.Translate(Vector3.up * StrafeSpeed * Time.deltaTime * Vertical);
		}

		Horizontal = Input.GetAxis("Horizontal");
		player.transform.Translate(Vector3.right * StrafeSpeed * Time.deltaTime * Horizontal);
	}
}
