using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterCore : MonoBehaviour
{
    [Header("Data Core")]
    [SerializeField] public string characterName;
    [SerializeField] public int maxHp;
    [SerializeField] public int maxSpeed;
    [SerializeField] public int maxAtk;
    [SerializeField] public bool isOwner;
    [SerializeField] public bool canMove = true;
    [SerializeField] public bool isBuilding;
    public int currentHp;
    [SerializeField] public int getDamage;
    [HideInInspector] public int currentAtk;
    [HideInInspector] public int currentSpeed;

    [Header("Detector")]
    [SerializeField] public Detect detect;
    [SerializeField] public float detectRange;
    [SerializeField] public LayerMask detectLayer;
    [SerializeField] public float timeBtwHit;
    [SerializeField] public Collider[] enemyIn;
    [SerializeField] public GameObject[] multiEnemy;
    [HideInInspector] public float timeBtwHitCD;
    [HideInInspector] public Transform closetEnemy;

    [Header("Component")]
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Animator anim;
    [SerializeField] public GameObject characterSprite;

    [Header("Behavior")]
    [SerializeField] public List<State> states;
    [HideInInspector] public CharacterState _characterState;

    [Header("Moving")]
    [SerializeField] public Transform movePos;
    [SerializeField] public NavMeshAgent navMeshAgent;

    [Header("Melee Combat")]
    [SerializeField] public float range;
    [SerializeField] public Transform hitPoint;

    [Header("Range Combat")]
    [SerializeField] public float rangeRange;

    private void Start()
    {
        currentHp = maxHp;
        currentSpeed = maxSpeed;
        currentAtk = maxAtk;
        
        _characterState = 0;
    }
        

    protected State State;

    public abstract void ChangeState(CharacterState troopState);
    public virtual bool Detect()
    {
        return detect.Detecting(detectRange, detectLayer);
    }
    public virtual Transform ClosetEnemy()
    {
        return detect.GetClosetEnemy(detectRange, detectLayer);
    }
    public virtual void SetTotalDamageToGet(int damage) {
        getDamage = damage;
    }  
}
