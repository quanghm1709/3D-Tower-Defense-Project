using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerState
{
    Undefined = -1,
    Idle,
    Attack,
    GetDamage,
}

public abstract class TowerStates : MonoBehaviour
{
    protected TowerController _agent = null;
    public void Init(TowerController tower)
    {
        _agent = tower;
    }
    public abstract TowerState GetState();
    public virtual void Action()
    {
    }

}
