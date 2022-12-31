using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Controller : MonoBehaviour {

    //right
    public delegate void p2Right();
    public static event p2Right p2right;

    //left
    public delegate void p2Left();
    public static event p2Left p2left;

    //up
    public delegate void p2Up();
    public static event p2Up p2up;

    //down
    public delegate void p2Down();
    public static event p2Down p2down;

    //jump
    public delegate void p2Jump();
    public static event p2Jump p2jump;

    //melee
    public delegate void p2Melee();
    public static event p2Melee p2melee;

    //ranged
    public delegate void p2Ranged();
    public static event p2Ranged p2ranged;

    //special
    public delegate void p2Special();
    public static event p2Special p2special;

    //specMove
    public delegate void p2SpecialMove();
    public static event p2SpecialMove p2specMove;

    //shield
    public delegate void p2Shield();
    public static event p2Shield p2shield;

    //ultimate
    public delegate void p2Ult();
    public static event p2Ult p2ult;

    

    // Use this for initialization
    void Start () {
        transform.Rotate(0f, 180f, 0f, Space.World);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
