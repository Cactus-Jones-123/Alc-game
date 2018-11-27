using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D Cactus_Jones; 

	public GameObject Cactus_Jones2;

	// Particles
	public GameObject DeathPS;
	public GameObject RespawnPS;

	//Respawn Delay
	public float RespawnDelay;


	//Point Penalty on Death
	public int PointPenaltyOnDeath;
	
	// Store Gravity Value
	private float GravityStore;


	// Use this for initialization
	void Start () {
		Cactus_Jones = GameObject.Find("Cactus Jones").GetComponent<Rigidbody2D>();
		Cactus_Jones2 = GameObject.Find("Cactus Jones");
	}
	
	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		//Generate Death Particle
		Instantiate (DeathPS, Cactus_Jones.transform.position, Cactus_Jones.transform.rotation);
		//Hide PC
		// PC.enabled = false;
		Cactus_Jones2.SetActive(false);
		Cactus_Jones.GetComponent<Renderer> ().enabled = false;
		// Gravity Reset
		GravityStore = Cactus_Jones.GetComponent<Rigidbody2D>().gravityScale;
		Cactus_Jones.GetComponent<Rigidbody2D>().gravityScale = 0f;
		Cactus_Jones.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		//Debug Message
		Debug.Log ("Cactus Jones Respawn");
		//Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		//Gravity Restore
		Cactus_Jones.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		//Match PCs transform position
		Cactus_Jones.transform.position = CurrentCheckPoint.transform.position;
		//Show PC
		// PC.enabled = true;
		Cactus_Jones2.SetActive(true);
		Cactus_Jones.GetComponent<Renderer> ().enabled = true;
		//Spawn PC
		Instantiate (RespawnPS, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}