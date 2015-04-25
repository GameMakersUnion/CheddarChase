using UnityEngine;
using System.Collections;

public class Hurt : MonoBehaviour
{

    private const int damageAmount = 1;
    private const string hurtLog = "<color=maroon>Mouse script missing from Mouse! Attach!</color>";

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Mouse mouse = other.GetComponent<Mouse>();

        if (other.tag == "Player" && mouse == null)
        {
            Debug.Log(hurtLog);
            return;
        }
        else if (other.tag == "Player")
        {
            Damaging(other);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        Mouse mouse = other.GetComponent<Mouse>();

        if (other.tag == "Player" && mouse == null)
        {
            Debug.Log(hurtLog);
            return;
        }
        else if (other.tag == "Player" && mouse.damageShowing == false)
        {
            Damaging(other);
        }
    }

    private void Damaging(Collider2D other)
    {
        Mouse mouse = other.GetComponent<Mouse>();

        mouse.health += -damageAmount;
        mouse.damageShowing = true;
        Debug.Log("<color=red>HURTING!!!</color>");
 
    }

}
