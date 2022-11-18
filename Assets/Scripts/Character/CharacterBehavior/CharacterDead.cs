using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDead : State
{
    public override CharacterState GetState()
    {
        return CharacterState.Die;
    }
    public override void Action()
    {
        base.Action();
        _agent.col.isTrigger = true;
        _agent.anim.SetBool("IsDead", true);
        _agent.anim.SetBool("IsAttack", true);
        _agent.anim.SetFloat("Move", 0);
    }
}
