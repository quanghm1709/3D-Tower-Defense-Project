using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : TowerStates
{
    public override TowerState GetState()
    {
        return TowerState.Attack;
    }

    public override void Action()
    {
        base.Action();
        if (_agent.Detect())
        {
            _agent.closetEnemy = _agent.ClosetEnemy();
            if(_agent.closetEnemy == null)
            {
                _agent.ChangeState(TowerState.Idle);
            }
            else
            {
                if (_agent.timeBtwHitCD <= 0)
                {
                    var fireball = Instantiate(_agent.fireBall, _agent.firePoint.position, _agent.firePoint.rotation);
                    _agent.timeBtwHitCD = _agent.timeBtwHit;
                }
                else
                {
                    _agent.timeBtwHitCD -= Time.deltaTime;
                }
            }       
        }
        else
        {
            _agent.ChangeState(TowerState.Idle);
        }
    }
}
