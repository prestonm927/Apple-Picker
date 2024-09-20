using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

	public ScoreCounter scoreCounter;

	private void Start() {
		// Find a reference to the ScoreCounter GameObject
		GameObject scoreGO = GameObject.Find("ScoreCounter");
		// Get the Text Component of the GameObject
		scoreCounter = scoreGO.GetComponent<ScoreCounter>();
	}

	void Update () {
		// Get the current screen position of the mouse from input
		Vector3 mousePos2D = Input.mousePosition;
		
		// The Camera's z position sets how far to push the mouse into 3D
		mousePos2D.z = Camera.main.transform.position.z;
		
		// Convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
		
		// Move the x position of this Basket to the x position of the Mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	private void OnCollisionEnter(Collision coll) {
		// Find out what hit this basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.CompareTag("Apple")) {
			Destroy(collidedWith);
			
			scoreCounter.score += 100;
			HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);

			if((scoreCounter.score % 1000) == 0) {
				RoundManager roundManager = FindObjectOfType<RoundManager>();
				roundManager.NextRound();
			}
		} else if (collidedWith.CompareTag("Branch")) {
			Destroy(collidedWith);

			ApplePicker hit = FindObjectOfType<ApplePicker>();
			hit.BranchHit();
		}
	}
}