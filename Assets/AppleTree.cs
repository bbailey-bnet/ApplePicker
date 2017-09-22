using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
	[Header("Set in Inspector")]

	public GameObject applePrefab;
	public float speed = 1f;
	public float leftAndRightEdge = 10f; //Distance where the apple tree turns around
	public float chanceToChangeDirections = 0.1f;
	public float secondsBetweenAppleDrops = 1f;



	// Use this for initialization
	void Start () {
		Invoke ("DropApple", 2f);
	}



	void DropApple() {
		GameObject apple = Instantiate<GameObject> (applePrefab);
		apple.transform.position = transform.position;
		Invoke ("DropApple", secondsBetweenAppleDrops);
	}



	// Update is called once per frame
	void Update () {
		//Basic Movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;



		//Changing Direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed);
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);
		} 
	}



	void FixedUpdate() {
		//Changing direction randomly based  on time
		if (Random.value < chanceToChangeDirections) {
			speed *= -1;
		}
	}
}
