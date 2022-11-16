using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIdle : TowerStates
{
    public override TowerState GetState()
    {
        return TowerState.Idle;
    }

    public override void Action()
    {
        base.Action();
        if (_agent.Detect())
        {
            _agent.ChangeState(TowerState.Attack);
        }
    }
}
