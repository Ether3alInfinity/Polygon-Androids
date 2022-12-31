using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarScript : MonoBehaviour {

    private Transform bar;
    
    

	// Use this for initialization
	void Start () {
        bar = transform;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void setSize(float sizeNorm)
    {
        bar.localScale = new Vector3(sizeNorm, 1f, 1f);
    }
}
