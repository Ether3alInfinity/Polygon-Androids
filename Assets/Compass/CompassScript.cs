using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CompassScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Rotate(GetComponent<Transform>().rotation.eulerAngles, Space.World);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TurnOnSelf(Vector3 rotation)
    {
        transform.Rotate(rotation, Space.Self);
    }
    public void TurnOnWorld(Vector3 rotation)
    {
        transform.Rotate(rotation, Space.World);
    }
    public void Turn(Vector3 rotation)
    {
        transform.rotation = Quaternion.Euler(rotation);
    }
}
