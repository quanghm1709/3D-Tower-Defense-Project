using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : CharacterCore
{
    [Header("Attack System")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireBall;
    [SerializeField] public Transform enemyPoint;
    
    
    private void Update()
    {
        closetEnemy = ClosetEnemy();
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
        return base.Detect();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }

    public override Transform ClosetEnemy()
    {
        return base.ClosetEnemy();
    }
}
