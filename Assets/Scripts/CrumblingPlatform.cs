using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatform : MonoBehaviour {
	[SerializeField] private float fallDelay = 1f;
	Rigidbody2D rigidbody;

	private void Awake() 
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.gameObject.tag == "Player") 
		{	
			Invoke("DropPlatform",fallDelay);
			Destroy(gameObject, 2f);							
		}
	}
	

	void DropPlatform()
	{
		rigidbody.isKinematic = false;
	}

}
