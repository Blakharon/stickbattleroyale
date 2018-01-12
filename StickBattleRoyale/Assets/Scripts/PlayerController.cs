using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public GameObject player;

    //Rotating Player
    Vector2 playerPos;
    Vector2 mousePos;
    Vector2 direction;
    float angle;
    //Moving Player
    public float WalkSpeed;
    private float Vertical;
    private float Horizontal;
    private Vector3 FuturePosition;
    //Health
    public float Health = 100;

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

    void Movement() {

        Vertical = Input.GetAxis("Vertical");
        if (Vertical != 0)
        {
            FuturePosition = player.transform.position + Vector3.up * WalkSpeed * Vertical;
            player.transform.position = Vector3.Lerp(player.transform.position, FuturePosition, Time.deltaTime);
        }

        Horizontal = Input.GetAxis("Horizontal");
        if (Horizontal != 0)
        {
            FuturePosition = player.transform.position + Vector3.right * WalkSpeed * Horizontal;
            player.transform.position = Vector3.Lerp(player.transform.position, FuturePosition, Time.deltaTime);
        }
	}
}
