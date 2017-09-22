using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Basket : MonoBehaviour {
	[Header("Set Dynamically")]
	public Text scoreGT;




	// Use this for initialization
	void Start () {
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		scoreGT = scoreGO.GetComponent<Text> ();
		scoreGT.text = "0";
	}

	// Update is called once per frame
	void Update () {
		Vector3 mousePos2D = Input.mousePosition;


		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);


		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}



	void OnCollisionEnter(Collision coll) {
		//find out wtf hit the basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag.ToLower() == "apple") {
			Destroy (collidedWith);
			Debug.Log ("Apple Destroyed..");
		}
		Destroy (collidedWith);
		int userScore = int.Parse (scoreGT.text);
		userScore += 100;
		scoreGT.text = userScore.ToString ();
		Debug.Log ("Another one bites the dust - Score is now: " + userScore);


		//Track the high score
		if (userScore > HighScore.score) {
			HighScore.score = userScore;
		}
	}
}
