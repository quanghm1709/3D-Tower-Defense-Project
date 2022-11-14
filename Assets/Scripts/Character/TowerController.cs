using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : CharacterCore, IBehavior
{
    [Header("Fire System")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float fireballSpeed;
    private Collider[] enemyIn;
    private void Update()
    {
        if (Detect())
        {
            Attack(currentAtk);
        } 
    }
    public void Attack(int atk)
    {
        if (timeBtwHitCD <= 0)
        {
            var fireball = Instantiate(fireBall, firePoint.position, firePoint.rotation);
            fireball.GetComponent<Rigidbody>().velocity = firePoint.forward * fireballSpeed;
            timeBtwHitCD = timeBtwHit;
        }
        else
        {
            timeBtwHitCD -= Time.deltaTime;
        }
    }

    public bool Detect()
    {
        enemyIn = Physics.OverlapSphere(transform.position, detectRange);
        if(enemyIn != null)
        {
            return true;
        }
        else
        {
            return false;   
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void GetDamage(int damage)
    {
        currentHp -= damage;
    }

    public void Idle()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void Moving()
    {
        throw new System.NotImplementedException();
    }
}
