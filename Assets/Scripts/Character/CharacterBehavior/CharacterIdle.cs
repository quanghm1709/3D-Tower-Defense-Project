using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdle : State
{

    public override CharacterState GetState()
    {
        return CharacterState.Idle;
    }
    public override void Action()
    {
        base.Action();
        _agent.rb.velocity = Vector3.zero;
        _agent.anim.SetFloat("Move", 0);
        _agent.ChangeState(CharacterState.Moving);
    }
}
