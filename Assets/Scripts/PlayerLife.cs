using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator anim;
    private int heartCount;

    [SerializeField] private Image[] hearts;

    [SerializeField] Color DamagedHeartColor;
    [SerializeField] Transform startPosition;
    [SerializeField] private AudioSource dieSound;

    private void Start()
    {
        heartCount = 2;
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (transform.position.y < -4)
        {
            transform.position = startPosition.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        dieSound.Play();
        rb2D.bodyType = RigidbodyType2D.Static;
        //anim.SetBool("isDead", true);
        anim.SetTrigger("dead");

        //hearts[heartCount].SetActive(false);
        hearts[heartCount].GetComponent<Image>().color = DamagedHeartColor;

        //Debug.Log("Hearts: " + heartCount);
        //Debug.Log(hearts[heartCount].name);
   
        heartCount--;
        if(heartCount < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            StartCoroutine(lossLife());
        }
    }

    IEnumerator lossLife()
    {
        yield return new WaitForSeconds(1.5f);
        this.transform.position = startPosition.transform.position;
        rb2D.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("idle");
    }

}
