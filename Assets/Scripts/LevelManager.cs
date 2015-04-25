using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    private Mouse mouse;
    private Sprite healthIndi;
    private float padDisp = 10;
    private bool deathReported = false;

	// Use this for initialization
	void Start ()
	{
	    mouse = GameObject.Find("Mouse").GetComponent<Mouse>();
	    healthIndi = Resources.Load<Sprite>("Textures/Ice1x1");

	}
	
	// Update is called once per frame
	void Update () {
        if (mouse.health <= 0 && !deathReported)
        {
            //mouse dead.
            deathReported = true;
            Debug.Log("YOUR MOUSE <color=red>DIED</color>!!!");
        }
    }

    void OnGUI()
    {
        if (mouse == null)
        {
            Debug.LogWarning("<color=maroon>MOUSE NOT FOUND! Cannot display it's health! Exiting OnGUI in LevelManager");
            return;
        }

        Texture t = healthIndi.texture;
        Rect tr = healthIndi.textureRect;
        Rect r = new Rect(tr.x / t.width, tr.y / t.height, tr.width / t.width, tr.height / t.height);

        for (int i = 0; i < mouse.health; i++)
        {
            GUI.DrawTextureWithTexCoords(new Rect(t.width * i + padDisp, padDisp, tr.width, tr.height), t, r);
        }

    }
}
