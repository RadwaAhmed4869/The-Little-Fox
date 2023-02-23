using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{
	[SerializeField] private float speed = 7f;
	public Rigidbody2D rb;
	[SerializeField] private GameObject gemDropped;
	[SerializeField] private GameObject destoryEffect;
	//[SerializeField] private List<GameObject> Drops;
	//private Vector3 offset = new Vector3(1, 0, 0);
	//private Transform dropPos;


	void Start()
	{
		rb.velocity = transform.right * speed;
		//dropPos = transform;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Enemy"))
        {
			GameObject effect = Instantiate(destoryEffect, transform.position, transform.rotation);
			effect.transform.localPosition = Vector3.zero;
			Destroy(collision.gameObject);
			Destroy(gameObject);
			Instantiate(gemDropped, transform.position, transform.rotation);

			//for(int i = 0; i < Drops.Count; i++)
			//         {
			//	//dropPos.position = transform.position;
			//	dropPos.position += offset;

			//	Drops[i].AddComponent<Rigidbody2D>();
			//	Drops[i].GetComponent<BoxCollider2D>().isTrigger = false;
			//	Instantiate(Drops[i], dropPos.position, transform.rotation);
			//         }
		}
		else
        {
			Destroy(gameObject, 4);
        }
	}
}
