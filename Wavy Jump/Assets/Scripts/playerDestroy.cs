﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDestroy : MonoBehaviour {

	public bool GameOver = false;



	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "KillZone") {
			
			GameOver = true;
		}
	}

}
