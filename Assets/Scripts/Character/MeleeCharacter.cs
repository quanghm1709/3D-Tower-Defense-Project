using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCharacter : CharacterCore, IBehavior
{
    [Header("Melee Combat")]
    [SerializeField] private float range;
    [SerializeField] private Transform hitPoint;

    private void Update()
    {
         
    }

    private void FixedUpdate()
    {
        Moving();
        if (Detect())
        {          
            Attack(currentAtk);
        }
    }

    public void Attack(int atk)
    {
        
        if(timeBtwHitCD <= 0)
        {
            Collider[] hitColliders = Physics.OverlapSphere(hitPoint.position, range);
            anim.SetTrigger("Attack");
            if (isOwner)
            {
                foreach (Collider enemy in hitColliders)
                {
                    if (enemy.tag == "Enemy")
                    {
                        //Debug.Log(enemy.gameObject.name);
                        enemy.gameObject.GetComponent<IBehavior>().GetDamage(atk);
                    } else if(enemy.tag == "Player")
                    {
                        canMove = false;
                    }
                    else
                    {
                        canMove = true;
                    }
                }
            }
            else
            {
                foreach (Collider enemy in hitColliders)
                {
                    if (enemy.tag == "Player")
                    {
                        enemy.gameObject.GetComponent<IBehavior>().GetDamage(currentAtk);
                    }
                }
            }
            timeBtwHitCD = timeBtwHit;
        }
        else
        {
            timeBtwHitCD -= Time.deltaTime;
        }
       
    }

    public bool Detect()
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

    public void GetDamage(int damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            Die();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitPoint.position, range);
    }

    public void Idle()
    {
        rb.velocity = Vector3.zero;
        anim.SetFloat("Move", 0);
    }

    public void Moving()
    {
        if (!Detect() && canMove)
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
        }
        else
        {
            Idle();
        }
    }

    public void Die()
    {
        Collider c = GetComponent<Collider>();
        c.isTrigger = true;
        characterSprite.SetActive(false);
    }
}
