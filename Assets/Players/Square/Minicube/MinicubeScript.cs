using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinicubeScript : MonoBehaviour {

    public float vel = 5f;
    public int damageVal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * vel * Time.deltaTime);
        
	}
    private void OnTriggerEnter2D(Collider2D target)
    {
        //make target take damage
        DamageScript victim = target.GetComponent<DamageScript>();
        if (victim != null)
        {
            victim.takeDamage(damageVal);
        }
        //Debug.Log(target.name);
        Destroy(gameObject);
    }
}
