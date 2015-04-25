using UnityEngine;
using System.Collections;

public class GroundCollision : MonoBehaviour
{

    public bool isGrounded = false;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }
}
