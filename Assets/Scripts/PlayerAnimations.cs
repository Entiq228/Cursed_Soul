using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Transform topCheck;
    public float topCheckRadius;
    private Animator anim;
    public LayerMask roof;
    private Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("StartRun", true);
        }
        else
        {
            anim.SetBool("StartRun", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("StartRun", false);
            anim.SetBool("OctoPose", true);
        }
        else if (!Physics2D.OverlapCircle(topCheck.position, topCheckRadius, roof))
        {
            anim.SetBool("OctoPose", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("StartRun", false);
            anim.SetBool("Jumping", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Jumping", false);
        }
    }
    
}
