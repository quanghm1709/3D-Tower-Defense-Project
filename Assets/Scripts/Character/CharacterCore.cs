using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterCore : Core
{  
    [Header("Component")]
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Animator anim;
    [SerializeField] public Collider col;
    
    [Header("Moving")]
    [SerializeField] public Transform movePos;
    [SerializeField] public NavMeshAgent navMeshAgent;
    [SerializeField] public int speed;

    [Header("Melee Combat")]
    [SerializeField] public float range;
    [SerializeField] public Transform hitPoint;

    [Header("Range Combat")]
    [SerializeField] public float rangeRange;

    [Header("Behavior")]
    [SerializeField] public List<State> states;
    [HideInInspector] public CharacterState _characterState;

    public abstract void ChangeState(CharacterState troopState);
}
