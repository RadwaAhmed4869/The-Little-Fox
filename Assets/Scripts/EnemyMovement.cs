using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float direction;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D enemy;
    private Vector3 localScale;

    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        direction = 1f;
        localScale = transform.localScale;
        //// facing left localScale.x = +ve
        //// facing right localScale.x = -ve
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Position"))
        {
            direction = - direction;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void FixedUpdate()
    {
        enemy.velocity = new Vector2(direction * moveSpeed, enemy.velocity.y);
    }

    //private float direction;
    //private float moveSpeed;
    //private Rigidbody2D enemy;
    //private bool facingRight = false;
    //private Vector3 localScale;

    //void Start()
    //{
    //    localScale = transform.localScale;
    //    enemy = GetComponent<Rigidbody2D>();
    //    direction = 1f;
    //    moveSpeed = 3f;
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Position"))
    //    {
    //        direction = -direction;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    enemy.velocity = new Vector2(direction * moveSpeed, enemy.velocity.y);
    //}

    //private void LateUpdate()
    //{
    //    checkWhereToFace();
    //}

    //private void checkWhereToFace()
    //{
    //    if (direction > 0)
    //        facingRight = false;
    //    else if (direction < 0)
    //        facingRight = true;

    //    if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
    //        localScale.x *= -1;

    //    transform.localScale = localScale;
    //}
}
