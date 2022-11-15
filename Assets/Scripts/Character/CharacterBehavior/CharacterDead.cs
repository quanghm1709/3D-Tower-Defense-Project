using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDead : State
{
    public override CharacterState GetState()
    {
        return CharacterState.Die;
    }
    public override IEnumerator Action()
    {
        base.Action();

        _agent.ChangeState(CharacterState.Attack);
        yield break;
    }
}
