using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour{
				[SerializeField] private GameObject start;
				
				private void OnCollisionEnter2D(Collision2D collision) {
								if(collision.gameObject.tag=="Player"){
												collision.gameObject.transform.position = start.transform.position;
												Physics.SyncTransforms();
								}
				}
}
