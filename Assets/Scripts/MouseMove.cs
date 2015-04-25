using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour
{
    private Rigidbody2D rb_;
    private GroundCollision gc_;
    private float mag_ = 15f;
    private float magUp_ = 20f;
    private const float expo = 1.5f;
    private const float maxVel_  = 5f;


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

        bool jumping = Input.GetKeyDown(KeyCode.Space);

        if (rb_ != null && gc_.isGrounded && ( x != 0 || y != 0 ))
        {
            float xx = Mathf.Abs(x);
            float yy = (jumping) ? Mathf.Abs(y) : 0 ;

            Vector2 force = new Vector2(xx * mag_, yy * magUp_);
            rb_.velocity += new Vector2(
                Mathf.Clamp(Mathf.Pow(force.x, expo) * x, -maxVel_, maxVel_), 
                Mathf.Clamp(Mathf.Pow(force.y, expo) * y * magUp_, -maxVel_, maxVel_ )
            );
        }
        Debug.Log("x: " + x + ", y: " + y + ", velocity: " + rb_.velocity);
        
    }
}
