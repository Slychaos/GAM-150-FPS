using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionController : MonoBehaviour
{    
    void OnAnimEnd()
    {
        GameObject.Destroy(gameObject);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<grenadeController>() != null)
        {
            //grenade has hit an explosions
            other.transform.GetComponent<grenadeController>().OnCaughtInExplosion();
        }
        else
        {
            if (other.transform.GetComponent<Rigidbody>() != null)
            {
                var direction = other.transform.position - transform.position;
                direction.Normalize();
                other.transform.GetComponent<Rigidbody>().AddForce(direction * 5, ForceMode.Impulse);
            }
        }
    }
}
