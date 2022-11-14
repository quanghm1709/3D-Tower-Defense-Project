using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : CharacterCore, IBehavior
{
    public void Attack(int atk)
    {
        throw new System.NotImplementedException();
    }

    public bool Detect()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void GetDamage(int damage)
    {
        currentHp -= damage;
    }

    public void Idle()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void Moving()
    {
        throw new System.NotImplementedException();
    }
}
