using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public bool Detecting(float detectRange, LayerMask detectLayer)
    {
        Collider[] enemyIn = Physics.OverlapSphere(transform.position, detectRange, detectLayer);
        if(enemyIn.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal Transform GetClosetEnemy(float detectRange, LayerMask detectLayer)
    {
        Collider[] multiEnemy = Physics.OverlapSphere(transform.position, detectRange+3, detectLayer);
        float closetDistance = Mathf.Infinity;
        Transform trans = null;

        if(multiEnemy.Length > 0)
        {
            foreach (Collider enemy in multiEnemy)
            {
                float currentDistance;
                currentDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (currentDistance < closetDistance && enemy.GetComponent<Core>().currentHp>0)
                {
                    closetDistance = currentDistance;
                    trans = enemy.transform;
                }
            }
            return trans;
        }
        else
        {
            return null;
        }     
    }
}
