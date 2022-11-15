using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : CharacterCore
{
    [Header("Attack System")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireBall;
    [SerializeField] public Transform enemyPoint;
    private Collider[] enemyIn;
    private GameObject[] multiEnemy;
    [HideInInspector] public Transform closetEnemy;
    private void Update()
    {
        closetEnemy = getClosetEnemy();
        //var curState = GetState(_characterState);
        //curState.Init(this);
        //StartCoroutine(curState.Action());
        if (Detect())
        {
            Attack();
        }
    }

    private State GetState(CharacterState characterState)
    {
        foreach (var state in states)
        {
            if (state.GetState() == characterState)
                return state;
        }
        return null;
    }

    public override void ChangeState(CharacterState characterState)
    {
        _characterState = characterState;
    }
    public void Attack()
    {
        if (timeBtwHitCD <= 0)
        {
            var fireball = Instantiate(fireBall, firePoint.position, firePoint.rotation);
            timeBtwHitCD = timeBtwHit;
        }
        else
        {
            timeBtwHitCD -= Time.deltaTime;
        }
    }

    public override bool Detect()
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

    public Transform getClosetEnemy()
    {
        if (isOwner)
        {
            multiEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        }
        else
        {
            multiEnemy = GameObject.FindGameObjectsWithTag("Player");
        }
        

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
