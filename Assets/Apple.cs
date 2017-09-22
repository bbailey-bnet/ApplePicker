using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
	[Header("Set in Inspector")]
	public static float bottomY = -23f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < bottomY) {
			Destroy (this.gameObject);



			ApplePicker appleScript = Camera.main.GetComponent<ApplePicker> ();
			appleScript.AppleDestroyed ();
		}
	}
}
