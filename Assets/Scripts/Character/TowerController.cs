using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : Core
{
    [Header("Attack System")]
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject fireBall;
    [SerializeField] public Transform enemyPoint;

    [Header("Behavior")]
    [SerializeField] public List<TowerStates> states;
    [SerializeField] public TowerState _towerState;

    private void Update()
    {
        var curState = GetState(_towerState);
        curState.Init(this);
        curState.Action();
    }

    private TowerStates GetState(TowerState towerState)
    {
        foreach (var state in states)
        {
            if (state.GetState() == _towerState)
                return state;
        }
        return null;
    }

    public void ChangeState(TowerState towerState)
    {
        _towerState = towerState;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
