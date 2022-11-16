using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGetDamage : TowerStates
{
    public override TowerState GetState()
    {
        return TowerState.GetDamage;
    }

    public override void Action()
    {
        base.Action();
        _agent.currentHp -= _agent.getDamage;
        if (_agent.currentHp <= 0)
        {
            _agent.characterSprite.SetActive(false);
        }
        else
        {
            _agent.ChangeState(TowerState.Attack);
        }
    }
}
