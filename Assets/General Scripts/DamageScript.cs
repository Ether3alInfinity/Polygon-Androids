using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    [SerializeField]
    private float maxHP, HPRegen;
    private float HP;


    // Use this for initialization
    void Start () {
        HP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("HP: " + HP);
        if(HP < maxHP)
            heal(HPRegen * Time.deltaTime);
        float percentHP = HP / maxHP;
        if (GetComponentInChildren<HPBarScript>() != null)
        {
            GetComponentInChildren<HPBarScript>().setSize(percentHP);
        }
    }
    public void takeDamage(float damage, float damageMultiplier=1)
    {
        HP -= damage * damageMultiplier;
        
        Debug.Log(gameObject.name + " HP remaining: " + HP);
        
        if(HP <= 0)
        {
            Die();
        }
    }
    public void heal(float healAmount)
    {
        HP += healAmount;
        if (HP > maxHP) HP = maxHP;
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
