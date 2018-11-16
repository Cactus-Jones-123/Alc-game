using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public Transform FirePoint;
	public GameObject Projectile;

	void Start () {
		Projectile = Resources.Load("Prefabs/Projectile") as GameObject;
	}
	
// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		Instantiate(Projectile,FirePoint.position, FirePoint.rotation);
	}
}
