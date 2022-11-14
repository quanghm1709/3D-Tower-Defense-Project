using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterCore : MonoBehaviour
{
    [Header("Data Core")]
    [SerializeField] public string characterName;
    [SerializeField] public int maxHp;
    [SerializeField] public int maxSpeed;
    [SerializeField] public int maxAtk;
    [SerializeField] public bool isOwner;
    [SerializeField] public bool canMove = true;
    [HideInInspector] public int currentHp;
    [HideInInspector] public int currentAtk;
    [HideInInspector] public int currentSpeed;

    [Header("Detector")]
    [SerializeField] public float detectRange;
    [SerializeField] public LayerMask detectLayer;

    [Header("Component")]
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Animator anim;

    private void Start()
    {
        currentHp = maxHp;
        currentSpeed = maxSpeed;
        currentAtk = maxAtk;
    }

    public abstract void Move();
    public abstract bool Detect();
    public abstract void Attack(int atk);
    public abstract void GetDamage(int damage);
}
