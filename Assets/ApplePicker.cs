using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
	[Header("Set in Inspector")]
	public GameObject basketPrefab;
	public int numberOfLives = 3;
	public float basketBottomY = -24;
	public float basketSpacing = 2f;
	public List<GameObject> basketList; 


	// Use this for initialization
	void Start () {
		basketList = new List<GameObject> ();
		for (int i = 0; i < numberOfLives; i++) {
			GameObject tBasketGO = Instantiate<GameObject> (basketPrefab);
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacing * i);
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
		}
	}




	public void AppleDestroyed() {
		//Destroy all of the falling apples
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
		foreach (GameObject tGO in tAppleArray) {
			Destroy (tGO);
		}


		int basketIndex = basketList.Count - 1;


		GameObject tBasketGO = basketList [basketIndex];

		basketList.RemoveAt (basketIndex);
		Destroy (tBasketGO);


		//Reset the game if there are no more baskets
		if (basketList.Count == 0) {
			SceneManager.LoadScene ("_sceneTEST");
		}
	}



	// Update is called once per frame
	void Update () {
		
	}
}
