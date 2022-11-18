using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : State
{

    public override CharacterState GetState()
    {
        return CharacterState.Moving;
    }
    public override void Action()
    {
        base.Action();

        TowerController tower;

        if (!_agent.Detect() && _agent.canMove)
        {
            if (!_agent.isOwner)
            {
                tower = GameObject.Find("My Tower").GetComponent<TowerController>();              
            }
            else
            {
                tower = GameObject.Find("Enemy Tower").GetComponent<TowerController>();        
            }
            _agent.movePos = tower.enemyPoint;
            _agent.navMeshAgent.destination = _agent.movePos.position;
            _agent.anim.SetBool("IsAttack", false);
            _agent.anim.SetFloat("Move", 1);
        }
        else
        {
            _agent.ChangeState(CharacterState.Attack);
        }

    }
}
