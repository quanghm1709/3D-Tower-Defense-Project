using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGetDamage : State
{
    public override CharacterState GetState()
    {
        return CharacterState.GetDamage;
    }

    public override IEnumerator Action()
    {
        base.Action();
        _agent.currentHp -= _agent.getDamage;
        if (_agent.currentHp <= 0)
        {
            _agent.ChangeState(CharacterState.Die);
        }
        else
        {
            _agent.ChangeState(CharacterState.Attack);
        }
        yield break;
    }

}
