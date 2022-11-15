using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCharacter : CharacterCore
{
    private void Update()
    {
        var curState = GetState(_characterState);
        curState.Init(this);
        StartCoroutine(curState.Action());
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

    public override bool Detect()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, detectRange, detectLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * detectRange, Color.red);
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * detectRange, Color.blue);
            return false;
        }
    }
    public virtual void SetTotalDamageToGet(int damage)
    {
        base.SetTotalDamageToGet(damage);
    }
}
