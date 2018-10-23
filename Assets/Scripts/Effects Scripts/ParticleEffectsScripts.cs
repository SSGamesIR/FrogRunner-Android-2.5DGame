using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectsScripts : MonoBehaviour {

    public float timer = 1.5f;
	// Use this for initialization
	void Start () {
        StartCoroutine(StopEffect());
	}
	
    IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
	
}
