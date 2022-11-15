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
    public int currentHp;
    [SerializeField] public int getDamage;
    [HideInInspector] public int currentAtk;
    [HideInInspector] public int currentSpeed;

    [Header("Detector")]
    [SerializeField] public Detect detect;
    [SerializeField] public float detectRange;
    [SerializeField] public LayerMask detectLayer;
    [SerializeField] public float timeBtwHit;
    [HideInInspector] public float timeBtwHitCD;

    [Header("Component")]
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Animator anim;
    [SerializeField] public GameObject characterSprite;

    [Header("Behavior")]
    [SerializeField] public List<State> states;
    [HideInInspector] public CharacterState _characterState;

    [Header("Melee Combat")]
    [SerializeField] public float range;
    [SerializeField] public Transform hitPoint;

    [Header("Moving")]
    [SerializeField] public Transform movePos;
    [SerializeField] public NavMeshAgent navMeshAgent;

    private void Start()
    {
        currentHp = maxHp;
        currentSpeed = maxSpeed;
        currentAtk = maxAtk;
        timeBtwHitCD = timeBtwHit;

        _characterState = 0;
        movePos = GameObject.Find("Enemy Tower").GetComponent<Transform>();
    }

    protected State State;

    public void SetState(State state)
    {
        State = state;
        State.Action();
    }

    public abstract void ChangeState(CharacterState troopState);
    public virtual bool Detect()
    {
        return detect.Detecting(detectRange, detectLayer);
    }
    public virtual void SetTotalDamageToGet(int damage) {
        getDamage = damage;
    }  
}
