using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Transform firePoint1;
    [SerializeField] private Transform firePoint2;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private SpriteRenderer playerSprite;

    [SerializeField] private AudioSource fireSound;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        //Debug.Log(playerSprite.flipX);
        if (playerSprite.flipX)
        {
            Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        }
        else if (!playerSprite.flipX)
        {
            Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        }
        fireSound.Play();
    }
}
