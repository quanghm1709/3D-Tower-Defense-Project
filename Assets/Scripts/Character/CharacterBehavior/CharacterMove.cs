using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : State
{

    public override CharacterState GetState()
    {
        return CharacterState.Moving;
    }
    public override IEnumerator Action()
    {
        base.Action();

        TowerController tower;
        TowerController enemyTower;
        if (_agent.isOwner)
        {
            tower = GameObject.Find("My Tower").GetComponent<TowerController>();
            enemyTower = GameObject.Find("Enemy Tower").GetComponent<TowerController>();
        }
        else
        {
            tower = GameObject.Find("Enemy Tower").GetComponent<TowerController>();
            enemyTower = GameObject.Find("My Tower").GetComponent<TowerController>();
        }

        if(tower.closetEnemy == null)
        {
            _agent.movePos = enemyTower.enemyPoint;
        }
        else
        {
            _agent.movePos = tower.closetEnemy;
        }

        if (!_agent.Detect() && _agent.canMove)
        {
            _agent.navMeshAgent.destination = _agent.movePos.position;
            _agent.anim.SetBool("IsAttack", false);
            _agent.anim.SetFloat("Move", 1);
        }
        else
        {
            _agent.ChangeState(CharacterState.Attack);
        }
        yield break;
    }
}
