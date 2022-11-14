using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] public float speed;
    [SerializeField] private bool isEnemyBullet;
    private int atk;

    private void Start()
    {
        atk = GameObject.Find("My Tower").GetComponent<CharacterCore>().currentAtk;
    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isEnemyBullet)
        {
            if (collision.tag == "Enemy")
            {
                collision.gameObject.GetComponent<IBehavior>().GetDamage(atk);
                Destroy(gameObject);
            }
        }
    }

}
