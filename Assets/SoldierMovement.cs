using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour {

	public GameObject player;
	public float moveSpeed = .2f;

    //NavMeshAgent nav;

	// Use this for initialization
	void Awake () {
        //Player = GameObject.FindGameObjectsWithTag("Player").transform.position;


	}

	void Start(){


	}

	// Update is called once per frame
	void Update () {

		Movement ();

	}





	void Movement(){ // will follow the player

		if (player.GetComponent<Transform> ().position.x > transform.position.x)
			transform.position = new Vector2 (transform.position.x + moveSpeed, transform.position.y);

		if (player.GetComponent<Transform> ().position.x < transform.position.x)
			transform.position = new Vector2 (transform.position.x - moveSpeed, transform.position.y);

		if (player.GetComponent<Transform> ().position.y > transform.position.y)
			transform.position = new Vector2 (transform.position.x, transform.position.y + moveSpeed);

		if (player.GetComponent<Transform> ().position.y < transform.position.y)
			transform.position = new Vector2 (transform.position.x, transform.position.y - moveSpeed);
		



	}


}
