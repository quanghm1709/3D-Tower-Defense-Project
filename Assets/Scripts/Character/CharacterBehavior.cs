using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehavior
{
    public void Idle();
    public void Moving(); 
    public bool Detect();
    public void Attack(int atk);
    public void GetDamage(int damage);
    public void Die();
}
