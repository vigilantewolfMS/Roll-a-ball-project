using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour {

	private int direction = 1;
	private float xpos;

	// Use this for initialization
	void Start () {

		xpos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3 (transform.localPosition.x + Random.Range (0.001f, 0.1f) * direction, transform.localPosition.y, transform.localPosition.z);
		if (transform.localPosition.x > 1+xpos) {
			direction = -1;
		}
		if (transform.localPosition.x < xpos-1) {

			direction = 1;
		}
	}
}
