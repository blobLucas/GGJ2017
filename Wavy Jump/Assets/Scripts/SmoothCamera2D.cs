﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmoothCamera2D : MonoBehaviour
{

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;

	//banque de patterns
	public GameObject[] BanquePatterns; 
	public float NextPattern;

	//variables instantiation des murs
	public GameObject Wall;
	private float CameraYStart;

	//variables instatiation du BG
	public GameObject Background;
	private float BackgroundY;





    void Start()
    {
        targetPos = transform.position;
		CameraYStart = transform.position.y;
		BackgroundY = transform.position.y;
		GameObject.Instantiate (Wall, new Vector2 (8, transform.position.y), Quaternion.identity);
		GameObject.Instantiate (Wall, new Vector2 (-8, transform.position.y), Quaternion.identity);
		NextPattern = transform.position.y;
    }
		
    void FixedUpdate()
    {
		//instanciation des murs
		if (transform.position.y > CameraYStart + 50) {
			GameObject.Instantiate (Wall, new Vector2 (8, transform.position.y), Quaternion.identity);
			GameObject.Instantiate (Wall, new Vector2 (-8, transform.position.y), Quaternion.identity);
			CameraYStart = transform.position.y;
		}

		if (transform.position.y > BackgroundY - 5) {
			GameObject.Instantiate (Background, new Vector3 (0 , BackgroundY + 19, 20), Quaternion.identity);
			BackgroundY += 19;

		}

		if (transform.position.y >= NextPattern) {
			Instantiate(BanquePatterns[Random.Range(0,7)], new Vector2 (0, transform.position.y + 20), Quaternion.identity);
			NextPattern += 20;

		}

		if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;
            posNoZ.x = target.transform.position.x;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
			if (targetPos.y > transform.position.y) {
				transform.position = Vector3.Lerp (transform.position, targetPos + offset, 0.25f);
			}

        }
    }
}

