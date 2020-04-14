using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 3f;

    Rigidbody2D rb2d;
    Animator anim;

    Vector2 movement;
    Vector2 move;

   // public LayerMask whatStopsMovement;
    //public Transform movePoint;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f;
        anim = GetComponent<Animator>();
        //movePoint.parent = null;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0.5f || movement.x < -0.5f)
        {
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = 0;
        }

        if (movement.y > 0.5f || movement.y < -0.5f)
        {
            move.y = Input.GetAxisRaw("Vertical");
            move.x = 0;
        }


       /* transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f) {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }

            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3( 0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }

            }
        }*/

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);

        anim.SetFloat("Speed", movement.sqrMagnitude);

        anim.SetFloat("LastMoveX", move.x);
        anim.SetFloat("LastMoveY", move.y);

    }

    void FixedUpdate()
    {
       rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.deltaTime);
    }

}
