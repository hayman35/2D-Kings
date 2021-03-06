using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Movement
{

    public class PlayerController : MonoBehaviour
    {
        private float GroundDistance = .2f;

        [SerializeField] private float speed, jumpForce;
        [SerializeField] private LayerMask whatisGround;
        [SerializeField] Transform firePoint;
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] private Transform groundPoint;

        private Rigidbody2D rigidbody;
        private Collider2D collider;
        private Animator animator;
        private bool isGrounded;
        private float inputX, inputY;

        private void Awake() 
        {
            rigidbody = GetComponent<Rigidbody2D>();
            collider = GetComponent<Collider2D>();
            animator = GetComponent<Animator>();
        }

        private void Update() 
        {
            rigidbody.velocity = new Vector2(inputX * speed, rigidbody.velocity.y);

            //Check if on the ground
            isGrounded = Physics2D.OverlapCircle(groundPoint.position, GroundDistance, whatisGround);

            if(rigidbody.velocity.x > 0f)
            {
                transform.localScale = Vector3.one;
            }else if(rigidbody.velocity.x < 0f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            animator.SetFloat("speed", Mathf.Abs(rigidbody.velocity.x));
            animator.SetBool("isGrounded", isGrounded);

             if(isGrounded && inputY > 0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            }
        }


        // Only gets called when the input changes 
        public void Move(InputAction.CallbackContext context)
        {
            inputX = context.ReadValue<Vector2>().x;
            inputY = context.ReadValue<Vector2>().y;
        }

    }


}

