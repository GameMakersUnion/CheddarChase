using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour
{
    private Rigidbody2D rb_;
    private float mag_ = 25f;
    private float magUp_ = 20f;

    // Use this for initialization
    void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        if (rb_ == null) { Debug.LogWarning("<color=maroon>no Rigidbody2D attached! Do so!</color>"); }
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (rb_ != null && ( x != 0 || y != 0 ))
        {
            Debug.Log("x: " + x + ", y: " + y);
            Vector2 force = new Vector2(x * mag_, 0 * magUp_);
            rb_.AddForce(force);
        }
    }
}
