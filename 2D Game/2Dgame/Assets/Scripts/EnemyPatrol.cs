using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	// Movement Variable
	public float MoveSpeed;
	public bool MoveRight;

	// Wall Check
	public Transform WallCheck;
	public float WallCheckRadius;
	public LayerMask WhatIsWall;
	private bool Hittingwall;
	// Edge Check
	private bool NotAtEdge;
	public Transform EdgeCheck;


	// Update is called once per frame
	void update () {
		NotAtEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);
		
		Hittingwall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);

		if (Hittingwall || !NotAtEdge){
			MoveRight = !MoveRight;
		}

		if (MoveRight){
			transform.localScale = new Vector3(-0.25f,0.25f,1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody>().velocity.y);
		}
		else {
			transform.localScale = new Vector3(0.25f,0.25f,1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody>().velocity.y);	
		}
	}
}
