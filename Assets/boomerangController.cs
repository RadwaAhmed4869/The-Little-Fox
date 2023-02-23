using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomerangController : MonoBehaviour
{
    [SerializeField] private Transform firePoint1;
    [SerializeField] private Transform firePoint2;

    [SerializeField] private GameObject boomerangPrefab;
    [SerializeField] private SpriteRenderer playerSprite;

    private Rigidbody2D rb2d;
    private Animator anim;

    [SerializeField] private float boomerangSpeed = 10f;

    private void Start()
    {
        rb2d = boomerangPrefab.GetComponent<Rigidbody2D>();
        anim = boomerangPrefab.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //shoot();
            StartCoroutine(swing());

        }
    }

    void shoot()
    {
        if (playerSprite.flipX)
        {
            Debug.Log("swing flipx");
            rb2d.velocity = -transform.right * boomerangSpeed;
            anim.SetBool("isRotating", true);

        }
        else if (!playerSprite.flipX)
        {
            Debug.Log("swing !flip x");
            rb2d.velocity = transform.right * boomerangSpeed;
            anim.SetBool("isRotating", true);
        }
    }

    IEnumerator swing()
    {
        int flipVar = 1;
        if (playerSprite.flipX)
            flipVar = -flipVar;
            
        Debug.Log("swing flipx");
        rb2d.velocity = flipVar * transform.right * boomerangSpeed;
        anim.SetBool("isRotating", true);

        yield return new WaitForSeconds(1.5f);

        Debug.Log("swing !flip x");
        rb2d.velocity = -flipVar * transform.right * boomerangSpeed;
        anim.SetBool("isRotating", true);
    }
}
