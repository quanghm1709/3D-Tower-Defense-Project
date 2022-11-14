using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : CharacterCore, IBehavior
{
    [Header("Attack System")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float fireballSpeed;
    private Collider[] enemyIn;
    private GameObject[] multiEnemy;
    private void Update()
    {
        if (Detect())
        {
            Attack(currentAtk);
        } 
    }
    public void Attack(int atk)
    {
        Transform enemy = getClosetEnemy();
        Vector3 lookDir = enemy.position - transform.position;
        float angle = Vector3.Angle(transform.position, enemy.position);
        firePoint.rotation = Quaternion.Euler(angle, 0, 0);
        Debug.Log(angle);

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
        enemyIn = Physics.OverlapSphere(transform.position, detectRange, detectLayer);
        if(enemyIn.Length != 0)
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
    public Transform getClosetEnemy()
    {
        multiEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        float closetDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject enemy in multiEnemy)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (currentDistance < closetDistance)
            {
                closetDistance = currentDistance;
                trans = enemy.transform;
            }
        }
        return trans;
    }

}
