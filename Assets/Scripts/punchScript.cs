using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchScript : MonoBehaviour
{
    Animation anim;

    public bool punched;
    // Start is called before the first frame update
    void Start()
    {
        punched = false;
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void animOver()
    {
        punched = true;
    }

    public void punchFist()
    {
        anim.Play("Punch");
    }

    //this is where I need to make the faux punching animation
}
