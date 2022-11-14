using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public abstract class CharacterCore : MonoBehaviour
{
    [Header("Data Core")]
    [SerializeField] public string characterName;
    [SerializeField] public int maxHp;
    [SerializeField] public int maxSpeed;
    [SerializeField] public int maxAtk;
    [SerializeField] public bool isOwner;
    [SerializeField] public bool canMove = true;
    public int currentHp;
    [HideInInspector] public int currentAtk;
    [HideInInspector] public int currentSpeed;

    [Header("Detector")]
    [SerializeField] public float detectRange;
    [SerializeField] public LayerMask detectLayer;
    [SerializeField] public float timeBtwHit;
    [HideInInspector] public float timeBtwHitCD;

    [Header("Component")]
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Animator anim;
    [SerializeField] public GameObject characterSprite;

    private void Start()
    {
        currentHp = maxHp;
        currentSpeed = maxSpeed;
        currentAtk = maxAtk;


        timeBtwHitCD = timeBtwHit;
    }    
}
