using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

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

    void RotatePlayer ()
    {

        playerPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        direction = mousePos - playerPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;    //Gets angle between current direction and the direction vector

        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); //Rotates towards the angle, for some reason our character is 90degrees off set
    }

	void Movement () {

		Vertical = Input.GetAxis("Vertical");
		if (Vertical >= 0) {
			
			transform.Translate (Vector3.up * WalkSpeed * Time.deltaTime * Vertical);
		} else {

			transform.Translate(Vector3.up * StrafeSpeed * Time.deltaTime * Vertical);
		}

		Horizontal = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.right * StrafeSpeed * Time.deltaTime * Horizontal);
	}
}
