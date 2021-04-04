using UnityEngine;
public class obstacle : MonoBehaviour{
				[SerializeField] private GameObject start;
				[SerializeField] private ItemBuilder builder;
				
				private void OnCollisionEnter2D(Collision2D collision) {
								if(collision.gameObject.tag=="Player"){
												builder.resetPlatforms();
												collision.gameObject.transform.position = start.transform.position;
												Physics.SyncTransforms();
								}
				}
}
