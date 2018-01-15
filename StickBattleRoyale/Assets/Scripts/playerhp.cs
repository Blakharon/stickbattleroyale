using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhp : MonoBehaviour {

	public const int max_health = 100;
	public int current_health = max_health;
	public RectTransform healthbar;

	public void hp_damage (int amount){
		current_health = current_health - amount;

		if (current_health < 0) {
			current_health = 0;
		}

		healthbar.sizeDelta = new Vector2 (current_health / 2, healthbar.sizeDelta.y);
	}
}
