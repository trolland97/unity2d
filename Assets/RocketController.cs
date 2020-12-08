using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

    public float maxDistance = 3.0f;

    private Vector3 startPosition;

	void Awake () {
        startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float distance =
            Vector3.Distance(
                GameObject.FindGameObjectWithTag("Player")
                    .transform.position,
                this.transform.position);

        if (distance > maxDistance)
        {
            this.gameObject.SetActive(false);
        }
	}
}
