﻿using UnityEngine;
using System;
using System.Collections;
using JumpLib;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour {

	public float speed;

	private int touchindex = 0;

    private double distFing_to_Obj;
	private Vector2 _inputs;
	private Rigidbody2D rb2d;
    private Vector2 target;
	public playerDestroy GameOverScript;

    void Start()
    {
		rb2d = GetComponent<Rigidbody2D> ();

	}

	void Update ()
    {
		if (Input.GetMouseButtonDown(0) ) {
			if (GameOverScript.GameOver ) {
				
				SceneManager.LoadScene ("MainMenu");
			}  
		}

		if (Input.touchCount > 0) {
			if (Input.GetTouch (touchindex).phase == TouchPhase.Began) {
				if (GameOverScript.GameOver) {

					SceneManager.LoadScene ("MainMenu");
				}  
			}
		}
	}
    public void TouchOnScreen ()
    {
		//le if empêche les contrôles si le joueur est en état de game over
		if (!GameOverScript.GameOver) {
			target = (Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition);

			_inputs = -(target - (Vector2)transform.position);

			distFing_to_Obj = Math.Sqrt (Math.Pow (_inputs.x, 2) + Math.Pow (_inputs.y, 2));

			//Debug.Log(distFing_to_Obj);
        
			rb2d.velocity = _inputs * speed * (6 - (float)distFing_to_Obj);
		}


    }

    private void OnMouseDown()
    {
        TouchOnScreen();
    }
}
