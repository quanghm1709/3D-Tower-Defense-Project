using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCharacter : CharacterCore
{
    private void Update()
    {
         
    }

    private void FixedUpdate()
    {
        Move();     
    }

    public override void Attack(int atk)
    {
        throw new System.NotImplementedException();
    }

    public override bool Detect()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, detectRange, detectLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * detectRange, Color.red);
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * detectRange, Color.blue);
            return false;
        }
    }

    public override void GetDamage(int damage)
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        if (!Detect())
        {
            if (isOwner)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -currentSpeed * Time.fixedDeltaTime);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, currentSpeed * Time.fixedDeltaTime);
            }
            anim.SetFloat("Move", Mathf.Abs(rb.velocity.z));
            //anim.SetFloat("Move", Mathf.Abs(rb.velocity.x));
        }
        else
        {
            rb.velocity = Vector3.zero;
            anim.SetFloat("Move", 0);
            anim.SetTrigger("Attack");
        }
    }
}
