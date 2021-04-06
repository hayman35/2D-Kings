using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {
				[SerializeField] private float groundDistance = .1f;
				[SerializeField] private float moveSpeed, jumpForce;
				[SerializeField] private LayerMask whatisGround;
				[SerializeField] private Transform groundPointLeft, groundPointRight;
				[SerializeField] private float hangTime = .2f;
				[SerializeField] private float jumpBufferLength = .1f;
				[SerializeField] private int currentScene;
				[SerializeField] private GameObject pauseMenu;
				private bool showPause=false;

				private Rigidbody2D rigidbody;
				private Collider2D collider;
				private Animator animator;
				private bool isGrounded, trigger;
				private float inputX, inputY, hangCounter, jumpBufferCount;
				

				private void Awake() {
								rigidbody = GetComponent<Rigidbody2D>();
								collider = GetComponent<Collider2D>();
								trigger = true;
								animator = GetComponent<Animator>();
				}

				private void Update() {
								rigidbody.velocity = new Vector2(inputX * moveSpeed, rigidbody.velocity.y); // Moving the player side to side with a given force 

								//Check if on the ground
								isGrounded = Physics2D.OverlapCircle(groundPointLeft.position, groundDistance, whatisGround) || Physics2D.OverlapCircle(groundPointRight.position, groundDistance, whatisGround);

								// Setting the hangtime and counter so if the player wants to jump last second at the edge of the platform they can
								if (isGrounded) {
												hangCounter = hangTime;
								}
								else {
												hangCounter -= Time.deltaTime;
								}

								if (inputY > 0f) {
												jumpBufferCount = jumpBufferLength;
								}
								else {
												jumpBufferCount -= Time.deltaTime;
								}

								// Rotating the player so hes always looking the right way 
								if (rigidbody.velocity.x < 0f) {
												transform.localScale = Vector3.one;
								}
								else if (rigidbody.velocity.x > 0f) {
												transform.localScale = new Vector3(-1f, 1f, 1f);
								}


								animator.SetFloat("speed", Mathf.Abs(rigidbody.velocity.x));
								animator.SetBool("isGrounded", isGrounded);

								// For the jumping 
								if (hangCounter > 0f && jumpBufferCount >= 0) {
												rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
												jumpBufferCount = 0;
												if (isGrounded)
												{
													SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Player_Jump);
												}
								}

								// Short jumps if the player does not hold the jump button (Mapped to W for now)
								if (Keyboard.current.wKey.wasReleasedThisFrame && rigidbody.velocity.y > 0f) {
												rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * .5f);

								}
								if (Keyboard.current.escapeKey.wasReleasedThisFrame) {
												pause();
								}
				}
				public void pause() {
								if (!showPause) {
												pauseMenu.SetActive(true);
												showPause = true;
												Time.timeScale = 0f;
								}
								else {
												pauseMenu.SetActive(false);
												showPause = false;
												Time.timeScale = 1f;
								}
				}
				// Only gets called when the input changes 
				public void Move(InputAction.CallbackContext context) {
								inputX = context.ReadValue<Vector2>().x;
								inputY = context.ReadValue<Vector2>().y;

				}

				private void OnTriggerEnter2D(Collider2D other) {
								if (other.gameObject.CompareTag("Death")) {
												SceneManager.LoadScene(currentScene);
												SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Player_Death);
								}
				}
}


