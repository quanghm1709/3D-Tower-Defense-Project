using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] public float speed;
    [SerializeField] private bool isEnemyBullet;
    [SerializeField] private float lifeTime;
    private Vector3 enemy;
    private int damage;

    private void Start()
    {
        if (!isEnemyBullet)
        {
            TowerController tower = GameObject.Find("My Tower").GetComponent<TowerController>();
            enemy = tower.closetEnemy.position;
            damage = tower.currentAtk;

        }
        else
        {
            TowerController tower = GameObject.Find("Enemy Tower").GetComponent<TowerController>();
            enemy = tower.closetEnemy.position;
            damage = tower.currentAtk;
        }
       
    }
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, enemy, speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if(enemy != null && enemy.tag != "Ground")
        {
            enemy.gameObject.GetComponent<CharacterCore>().SetTotalDamageToGet(damage);
            enemy.gameObject.GetComponent<CharacterCore>().ChangeState(CharacterState.GetDamage);
            Destroy(gameObject);
        }     
    }

}
