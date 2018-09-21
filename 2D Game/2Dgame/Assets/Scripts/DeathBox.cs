using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){

		if(other.name == "Cactus Jones")
		{
			Debug.Log("Player Enters Death Zone");
			Destroy(other);
		}
		
	}
}
	