using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{
    //movement related
	public bool canClimb = false;
    private Rigidbody2D rb_;
    private GroundCollision gc_;
    private float mag_ = 15f;
    private float magUp_ = 500f;
    private float magJump_ = 1000f;
    private float magFall_ = 50f;
    private const float expo = 1.5f;
    private const float maxVel_  = 1f;


    //state related
    private int health_ = 3;
    public int health {
        get { return health_; }
        set { health_ = (value < 0) ? 0 : value; }
    }
    private float timeRemains = 1.0f; // 10 seconds.
    public bool damageShowing = false;
    private SpriteRenderer sr_;
    private bool deathOccured = false;

    // Use this for initialization
    void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        if (rb_ == null)
        {
            Debug.LogWarning("<color=maroon>no Rigidbody2D attached to Mouse! Do so!</color>");
        }
        gc_ = transform.Find("Ground").GetComponent<GroundCollision>();
        if (gc_ == null)
        {
            Debug.LogWarning("<color=maroon>Something wrong! Probably no GroundCollision script found on Ground of Mouse! Make it so!</color>");
        }
        sr_ = this.GetComponent<SpriteRenderer>();
        if (sr_ == null)
        {
            Debug.LogWarning("<color=maroon>Something wrong! How the hecks is the Sprite Renderer missing! WTF</color>");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (health_ <= 0 && !deathOccured)
        {
            sr_.color = Color.black;
            float x = transform.localScale.x , y = transform.localScale.y, z = transform.localScale.z;
            transform.localScale = new Vector3(x, -y, z);
            deathOccured = true;
            return;
        }
        else if (health_ <= 0)
        {
            return;
        }

        if (damageShowing)
        {
            if (timeRemains > 0)
            {
                // Decrease timeLimit.
                timeRemains -= Time.deltaTime;
                sr_.color = Color.red;

            }
            else
            {
                timeRemains = 1.0f;
                sr_.color = Color.white;
                damageShowing = false;

            }

        }
    }

    void FixedUpdate()
    {

        if (health_ <= 0)
        {
            return;
        }

        //MOVEMENT PHYSICS STUFF
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //vertical force upon jumping
        bool jumpExecuting = Input.GetKey(KeyCode.Space);
        if (gc_ == null)
        {
            Debug.LogWarning("<color=maroon>Something wrong! Probably no GroundCollision script found on Ground of Mouse! Make it so!</color>");
        }
        else if (rb_ == null)
        {
            Debug.LogWarning("<color=maroon>no Rigidbody2D attached to Mouse! Do so!</color>");
        }
        else if (jumpExecuting  && gc_.isGrounded)
        {
            Debug.Log("JUMP OCCURING!");
            rb_.AddForce(new Vector2(0, magJump_));
        }
        //upwards
        else if (rb_.velocity.y > 0)
        {
            rb_.velocity += -rb_.velocity / 10;
            //Debug.Log("UPSING");
        }
        //falling
        else if ( rb_.velocity.y < 0)
        {
            //Debug.Log("FALLING");
            rb_.AddForce(new Vector2(0, -magFall_));
        }


        //horizontal movement block
        if ( rb_ != null && (x != 0 || y != 0)) //&& gc_.isGrounded
        {
            float xx = Mathf.Abs(x);
            float yy = (jumpExecuting) ? Mathf.Abs(y) : 0;

            Vector2 force = new Vector2(xx*mag_, 0);
            rb_.velocity += new Vector2(
                Mathf.Clamp(Mathf.Pow(force.x, expo)*x, -maxVel_, maxVel_),
                0
                );

        }   
        //counter-force horizontal
        else
        {
            rb_.velocity += new Vector2( -rb_.velocity.x / 10, 0 );

        }
        //        Debug.Log("x: " + x + ", y: " + y + ", velocity: " + rb_.velocity);

        if (Input.GetKey(KeyCode.UpArrow) && canClimb) {
			// move up
		}
    }

}
