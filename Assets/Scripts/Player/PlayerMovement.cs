using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Horizontal Movement")]
        public float moveSpeed = 10f;
        public Vector2 direction;
        private bool facingRight = true;

        [Header("Vertical Movement")]
        public float jumpSpeed = 15f;
        public float jumpDelay = 0.25f;
        private float jumpTimer;

        [Header("Components")]
        public Rigidbody2D rb;
        public Animator animator;
        public LayerMask groundLayer;
        public GameObject characterHolder;

        [Header("Physics")]
        public float maxSpeed = 7f;
        public float linearDrag = 4f;
        public float gravity = 1f;
        public float fallMultiplier = 5f;

        [Header("Collision")]
        public bool onGround = false;
        public float groundLength = 0.6f;
        public Vector3 colliderOffset;

        // Update is called once per frame
        void Update() {
            if(Input.GetButtonDown("Jump")){
                jumpTimer = Time.time + jumpDelay;
            }
            //animator.SetBool("onGround", onGround);
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        void FixedUpdate() {
            onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);
            moveCharacter(direction.x);
            if(jumpTimer > Time.time && onGround){
                Jump();
            }
        
            modifyPhysics();
        }
        void moveCharacter(float horizontal) {
            rb.AddForce(Vector2.right * horizontal * moveSpeed);

            if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight)) {
                Flip();
            }
            if (Mathf.Abs(rb.velocity.x) > maxSpeed) {
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
            }
            //animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));
            //animator.SetFloat("vertical",rb.velocity.y);
        }
        void Jump(){
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumpTimer = 0;
        }
        void modifyPhysics() {
            bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

            if(onGround){
                if (Mathf.Abs(direction.x) < 0.4f || changingDirections) {
                    rb.drag = linearDrag;
                } else {
                    rb.drag = 0f;
                }
                rb.gravityScale = 0;
            }else{
                rb.gravityScale = gravity;
                // Disable slowing down  in the air
                // rb.drag = linearDrag * 0.15f;
                if(rb.velocity.y < 0){
                    rb.gravityScale = gravity * fallMultiplier;
                }else if(rb.velocity.y > 0 && !Input.GetButton("Jump")){
                    rb.gravityScale = gravity * (fallMultiplier / 2);
                }
            }
        }
        void Flip() {
            facingRight = !facingRight;
            transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
            Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
        }
    }
}
