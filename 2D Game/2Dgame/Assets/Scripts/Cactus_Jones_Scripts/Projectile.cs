﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float Speed;

	public float TimeOut;
	public GameObject Cactus_Jones;

	public GameObject EnemyDeath;

	public GameObject ProjectileParticle;

	public int PointsForKill;

	// Use this for initialization
	void Start () {
		 Cactus_Jones = GameObject.Find("prefabs/Cactus Jones"); 

		 EnemyDeath = Resources.Load("prefabs/DeathPS") as GameObject;

		 ProjectileParticle = Resources.Load("prefabs/RespawnPS") as GameObject;

		if(Cactus_Jones.transform.localScale.x < 0)
			Speed = -Speed;

			

		// Destroys Projectile after X seconds
		Destroy(gameObject,TimeOut);
						
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other){
		//Destroys enemey on contact with projectile. Adds points. 
		if(other.tag == "Enemy"){
			Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints (PointsForKill);
		}
		
		
		// Instantiate(ProjectileParticle, transform.position, transform.rotation);
		Destroy (gameObject);
	}

		void OnCollisionEnter2D(Collision2D other)
	{
		Instantiate(ProjectileParticle, transform.position, transform.rotation);
		Destroy (gameObject);
		
	}
}
