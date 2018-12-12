using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickeringFlashlight : MonoBehaviour {

    Light flashlight;
    public float minWaitTime;
    public float maxWaitTime;

	// Use this for initialization
	void Start () {
        flashlight = GetComponent<Light>();
        StartCoroutine(Flashing());
	}
	
    IEnumerator Flashing() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            flashlight.enabled = !flashlight.enabled;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
