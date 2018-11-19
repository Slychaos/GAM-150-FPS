using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Find("debugtext").GetComponent<UnityEngine.UI.Text>().text = debugText;
        transform.Find("debugtext-bg").GetComponent<UnityEngine.UI.Text>().text = debugText;
    }

    public string debugText;
}
