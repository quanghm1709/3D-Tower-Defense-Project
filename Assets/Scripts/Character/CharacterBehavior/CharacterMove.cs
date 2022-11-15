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
        if (!_agent.Detect() && _agent.canMove)
        {
            if (_agent.isOwner)
            {
                _agent.rb.velocity = new Vector3(_agent.rb.velocity.x, _agent.rb.velocity.y, -_agent.currentSpeed * Time.fixedDeltaTime);
            }
            else
            {
                _agent.rb.velocity = new Vector3(_agent.rb.velocity.x, _agent.rb.velocity.y, _agent.currentSpeed * Time.fixedDeltaTime);
            }
            _agent.anim.SetBool("IsAttack", false);
            _agent.anim.SetFloat("Move", Mathf.Abs(_agent.rb.velocity.z));
        }
        else
        {
            _agent.ChangeState(CharacterState.Attack);
        }
        yield break;
    }
}
