using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeScript : MonoBehaviour {

    public float vel;
    public int damageVal;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity += Vector2.up * Physics2D.gravity.y;

    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        //make target take damage
        DamageScript victim = target.GetComponent<DamageScript>();
        if (victim != null)
        {
            if (victim.gameObject.layer != 9)
            {
                victim.takeDamage(damageVal);
                Destroy(gameObject);
            }
            else victim.heal(damageVal / 2);
        }
        //Debug.Log(target.name);
        
    }
}
