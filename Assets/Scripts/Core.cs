using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Core : MonoBehaviour
{
    [Header("Data Core")]
    [SerializeField] public string characterName;
    [SerializeField] public int maxHp;
    [SerializeField] public int maxAtk;
    [SerializeField] public bool isOwner;
    [SerializeField] public bool canMove = true;
    [SerializeField] public bool isBuilding;
    public int currentHp;
    [SerializeField] public int getDamage;
    [HideInInspector] public int currentAtk;

    [SerializeField] public GameObject characterSprite;

    [Header("Detector")]
    [SerializeField] public Detect detect;
    [SerializeField] public float detectRange;
    [SerializeField] public LayerMask detectLayer;
    [SerializeField] public float timeBtwHit;
    [SerializeField] public Collider[] enemyIn;
    [SerializeField] public GameObject[] multiEnemy;
    [HideInInspector] public float timeBtwHitCD;
    [HideInInspector] public Transform closetEnemy;

    private void Start()
    {
        currentHp = maxHp;
        currentAtk = maxAtk;
    }

    public virtual bool Detect()
    {
        return detect.Detecting(detectRange, detectLayer);
    }
    public virtual Transform ClosetEnemy()
    {
        return detect.GetClosetEnemy(detectRange, detectLayer);
    }
    public virtual void SetTotalDamageToGet(int damage)
    {
        getDamage = damage;
    }
}
