using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D CactusJones;

	// Particles
	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	// Respawn Delay
	public float RespawnDelay;


	// Point Penalty on Death
	public int PointPenaltyOnDeath;

	// Stor Gravity Value
	private float GravityStore;



	// Use this for initialization
	void Start () {
		//CactusJones = FindObjectOfType<Rigidbody2D> ();
	}
	
	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}
	
	public IEnumerator RespawnPlayerCo(){
		// Genterate Death Paricle
		Instantiate (DeathParticle, CactusJones.transform.position, CactusJones.transform.rotation);
		// Hide CactusJones
		// CactusJones.enaable = false;
		CactusJones.GetComponent<Renderer> ().enabled = false;
		// Gravity Reset
		GravityStore = CactusJones.GetComponent<Rigidbody2D>().gravityScale;
		CactusJones.GetComponent<Rigidbody2D>().gravityScale = 0f;
		CactusJones.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		// Debug Message
		Debug.Log ("CactusJones Respawn");
		// Respawn Dealay
		yield return new WaitForSeconds (RespawnDelay);
		// Gravity Restore
		CactusJones.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		// Match CactusJones's transform position
		CactusJones.transform.position = CurrentCheckPoint.transform.position;
		// Show CactusJones
		// CactusJones.enabled = true;
		CactusJones.GetComponent<Renderer> ().enabled = true;
		//Spawn CactusJones
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}
