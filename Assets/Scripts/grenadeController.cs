using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeController : MonoBehaviour {

    public GameObject explosion;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);           
        }        
    }

    public void OnCaughtInExplosion()
    {
        if (explosion != null)
        {
            var inst = Instantiate(explosion, transform.position, transform.rotation);
        }

        GameObject.Destroy(gameObject);
    }
}
