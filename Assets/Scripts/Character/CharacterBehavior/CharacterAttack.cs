using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : State
{
    public override CharacterState GetState()
    {
        return CharacterState.Attack;
    }
    public override void Action()
    {
        base.Action();
        
        if (_agent.Detect())
        {
            _agent.rb.velocity = Vector3.zero;
            if (_agent.timeBtwHitCD <= 0)
            {
                Collider[] hitColliders = Physics.OverlapSphere(_agent.hitPoint.position, _agent.range);
                _agent.anim.SetBool("IsAttack", true);
                _agent.anim.SetFloat("Move", 0);

                if (_agent.isOwner)
                {
                    foreach (Collider enemy in hitColliders)
                    {
                        if (!enemy.gameObject.GetComponent<Core>().isOwner)
                        {
                            enemy.gameObject.GetComponent<Core>().SetTotalDamageToGet(_agent.currentAtk);
                            enemy.gameObject.GetComponent<TowerController>().ChangeState(TowerState.GetDamage);
                        }
                        else if (enemy.tag == "Player")
                        {
                            _agent.canMove = false;
                        }
                        else
                        {
                            _agent.canMove = true;
                        }
                    }
                }
                else
                {
                    foreach (Collider enemy in hitColliders)
                    {
                        if (enemy.gameObject.GetComponent<Core>().isOwner)
                        {
                            enemy.gameObject.GetComponent<Core>().SetTotalDamageToGet(_agent.currentAtk);
                            //enemy.gameObject.GetComponent<Core>().ChangeState(CharacterState.GetDamage);
                        }
                    }
                }
                _agent.timeBtwHitCD = _agent.timeBtwHit;
            }
            else
            {
                _agent.anim.SetBool("IsAttack", false);
                _agent.anim.SetFloat("Move", 0);
                _agent.timeBtwHitCD -= Time.deltaTime;
            }
        }
        else
        {
            _agent.ChangeState(CharacterState.Moving);
        }
    }
}
