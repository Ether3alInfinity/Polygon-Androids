using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour {

    //right
    public delegate void p1Right();
    public static event p1Right p1right;

    //left
    public delegate void p1Left();
    public static event p1Left p1left;

    //up
    public delegate void p1Up();
    public static event p1Up p1up;

    //down
    public delegate void p1Down();
    public static event p1Down p1down;

    //jump
    public delegate void p1Jump();
    public static event p1Jump p1jump;

    //melee
    public delegate void p1Melee();
    public static event p1Melee p1melee;

    //ranged
    public delegate void p1Ranged();
    public static event p1Ranged p1ranged;

    //special
    public delegate void p1Special();
    public static event p1Special p1special;

    //specMove
    public delegate void p1SpecialMove();
    public static event p1SpecialMove p1specMove;

    //shield
    public delegate void p1Shield();
    public static event p1Shield p1shield;

    //ultimate
    public delegate void p1Ult();
    public static event p1Ult p1ult;

    

	// Use this for initialization
	void Start () {
        transform.Rotate(0f, 0f, 0f, Space.World);
	}


    // Update is called once per frame
    void Update () {
		
	}
    void moveRight()
    {
        //make shape move right
        Debug.Log("moving right");
    }
}
