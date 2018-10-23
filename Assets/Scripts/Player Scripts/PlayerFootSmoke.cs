 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSmoke : MonoBehaviour {

    public GameObject SmokeEffect;
    public GameObject SmokePosition;


    void OnTriggerEnter(Collider target)
    {
        if (target.tag == Tags.PLATFORM_TAG)
        {
            if (SmokePosition.activeInHierarchy)
            {
                Instantiate(SmokeEffect, SmokePosition.transform.position, Quaternion.identity);
            }
        }
        
    }

}// class















