using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour
{
	public bool canClimb = false;
    private Rigidbody2D rb_;
    private GroundCollision gc_;
    private float mag_ = 15f;
    private float magUp_ = 500f;
    private float magJump_ = 500f;
    private const float expo = 1.5f;
    private const float maxVel_  = 1f;


    // Use this for initialization
    void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        if (rb_ == null) { Debug.LogWarning("<color=maroon>no Rigidbody2D attached to Mouse! Do so!</color>"); }
        gc_ = transform.Find("Ground").GetComponent<GroundCollision>();
        if (gc_ == null) { Debug.LogWarning("<color=maroon>no GroundCollision script found on Ground of Mouse! Make it so!</color>"); }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //vertical force upon jumping
        bool jumping = Input.GetKey(KeyCode.Space);
        if (jumping && gc_.isGrounded) rb_.AddForce(new Vector2(0, magJump_));

        //horizontal movement block
        if (rb_ != null && (x != 0 || y != 0)) //&& gc_.isGrounded
        {
            float xx = Mathf.Abs(x);
            float yy = (jumping) ? Mathf.Abs(y) : 0;

            Vector2 force = new Vector2(xx*mag_, yy*magJump_);
            rb_.velocity += new Vector2(
                Mathf.Clamp(Mathf.Pow(force.x, expo)*x, -maxVel_, maxVel_),
                0
                );

        }
        else
        {
            rb_.velocity += -rb_.velocity/10;
        }
        Debug.Log("x: " + x + ", y: " + y + ", velocity: " + rb_.velocity);
        
		if (Input.GetKey(KeyCode.UpArrow) && canClimb) {
			// move up
		}
    }
}
