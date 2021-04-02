using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatform : MonoBehaviour {
				[SerializeField] private int delay = 5;
				[SerializeField] private GameObject self;
				private IEnumerator wait() {
								yield return new WaitForSeconds(delay);
								self.SetActive(false);
				}
				private void OnCollisionStay2D(Collision2D collision) {
								if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Hook") {
												StartCoroutine(wait());
								}
				}
}
