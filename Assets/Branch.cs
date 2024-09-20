using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour {
	public static float bottomY = -20f;

	void Update () {
		if (transform.position.y < bottomY) {
			Destroy(this.gameObject);
			
			// Get a referenece to the ApplePicker component of the Main Camera
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
			// Call the public BranchMissed() method of apScript
			apScript.BranchMissed();
		}
	}
}
