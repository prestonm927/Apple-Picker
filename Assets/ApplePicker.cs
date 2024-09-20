using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
	[Header("Inscribed")]
	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	public List<GameObject> basketList;
	
	void Start () {
		basketList = new List<GameObject>();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add(tBasketGO);
		}
	}

	public void BranchMissed() {
		GameObject[] tBranchArray = GameObject.FindGameObjectsWithTag("Branch");
		foreach (GameObject tGO in tBranchArray) {
			Destroy(tGO);
		}
	}

	public void BranchHit() {
		while(basketList.Count > 0) {
			int basketIndex = basketList.Count - 1;
			GameObject tBasketGO = basketList[basketIndex];
			basketList.RemoveAt(basketIndex);
			Destroy(tBasketGO);
		}
		
		RoundManager roundManager = FindObjectOfType<RoundManager>();
		roundManager.GameOver();
	}

	public void AppleMissed() {
		// Destroy all of the falling apples
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
		foreach (GameObject tGO in tAppleArray) {
			Destroy(tGO);
		}
		
		// Destroy one of the baskets
		// Get the index of the last Basket in the basketList
		int basketIndex = basketList.Count - 1;
		// Get a reference to that Basket GameObject
		GameObject tBasketGO = basketList[basketIndex];
		// Remove the Basket for the list and destroy the GameObject
		basketList.RemoveAt(basketIndex);
		Destroy(tBasketGO);
		
		// If there are no Baskets left, restart the game
		if (basketList.Count == 0) {
			RoundManager roundManager = FindObjectOfType<RoundManager>();
			roundManager.GameOver();
		}
	}
}
