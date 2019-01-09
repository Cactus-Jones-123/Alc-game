using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	public Transform FirePoint;
	public GameObject Projectile;
	
	void Start(){
		// Load Projectile from Resources/Prefabs Folder
		Projectile = Resources.Load("prefabs/Projectile") as GameObject;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			Instantiate(Projectile,FirePoint.position, FirePoint.rotation);
		
	}
}