using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    Undefined = -1,
    Idle,
    Moving,
    Attack,
    Die,
    GetDamage,
}

public abstract class State : MonoBehaviour
{
    protected CharacterCore _agent = null;
    public void Init(CharacterCore character)
    {
        _agent = character;
    }
    public abstract CharacterState GetState();
    public virtual IEnumerator Action()
    {
        yield break;
    }

}

