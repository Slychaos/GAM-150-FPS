using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunfireanimation : MonoBehaviour {

	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
            GameObject.Find("Noob gun").GetComponent<Animation>().Play("Firing animation");
    }
}

