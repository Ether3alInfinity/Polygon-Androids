using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquareController : MonoBehaviour {

    [SerializeField]
    private float finalSpeed;
    private float speed;
    [SerializeField]
    private float maxMP, jumpSpeed, MPRegen;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private float MP;
    private float miniCubeCost = 5;
    private float UltCost = 50;
    private float fireCost = 10;
    
    //minicube
    public Transform firePoint;
    public GameObject projectile;
    //ulti
    public Transform ultPoint;
    public GameObject ultiNuke;

    public float fireRate;
    private float fireTime;
    private float MPRatio;

    private int maxJump = 3;
    private int jump = 0;
    //private bool grounded = false;

    Rigidbody2D rb;
    

	// Use this for initialization
	void Start () {
        speed = finalSpeed;
        MP = maxMP;
        rb = GetComponent<Rigidbody2D>();
	}

	
	// Update is called once per frame
	void FixedUpdate () {

        //keys need to be moved to playerScript
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left*Time.deltaTime*speed);
            Aim(new Vector3(0f, 0f, 180f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        //aim
        if (Input.GetKeyDown(KeyCode.A))
        {
            Aim(new Vector3(0f, 0f, 180f));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Aim(new Vector3(0f, 0f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Aim(new Vector3(0f, 0f, 90f));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Aim(new Vector3(0f, 0f, 270f));
        }

    }
    private void Update()
    {
        if(MP<maxMP)
            MP += MPRegen * Time.deltaTime;
        MPRatio = MP / maxMP;
        //Debug.Log("MP: " + MP);
        
        //mario jump effect
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        //keys need to be moved to playerScript
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            onFire();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(MP >= UltCost)
                Ult();
        }
        
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            Aim(new Vector3(0f, 0f, 90f));
        }*/
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(MP >= miniCubeCost)
                miniCube();
        }
        if (GetComponentInChildren<MPBarScript>() != null)
            GetComponentInChildren<MPBarScript>().setSize(MPRatio);
    }
    private void LateUpdate()
    {
        if(!Input.GetKey(KeyCode.LeftShift))
            noFire();    
    }

    void Jump()
    {   
        if (jump < maxJump) {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * jumpSpeed;
            jump++;
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.layer == 8)
        {
            //grounded = true;
            jump = 0;
        }
    }
    
    //attacks
    void Ult()
    {
        Instantiate(ultiNuke, ultPoint.position, ultPoint.rotation);
        MP -= UltCost;
    }
    void onFire()
    {
        Color col = new Color(1,0,0);
        GetComponent<Renderer>().material.color = col;
        if (MP >= fireCost)
        {
            MP -= 10 * Time.deltaTime;
            speed = 2 * finalSpeed;
        }
    }
    void noFire()
    {
        Color col = new Color(1, 1, 1);
        GetComponent<Renderer>().material.color = col;
        speed = finalSpeed;
    }
    void miniCube()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        MP -= miniCubeCost;
    }
    void Aim(Vector3 aim)
    {
        GetComponentInChildren<CompassScript>().Turn(aim);
    }
}
