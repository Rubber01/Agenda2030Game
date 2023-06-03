using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    private float horizontal;
    private float speed = 8f * 50f;
    private bool isFacingRight = true;

    private bool movingRight = false;
    private bool movingLeft = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Animator animatorController;
    void Update()
    {
        if(!IsOwner)
            return;

        HandleInput();
        
    }
    private void FixedUpdate()
    {
        horizontal = 0f;

        if(movingLeft){ 
            horizontal += -1f;
            animatorController.SetFloat("Speed", Mathf.Abs(horizontal));
        }

        if(movingRight){
            horizontal += 1f;
            animatorController.SetFloat("Speed", Mathf.Abs(horizontal));
        }

        animatorController.SetFloat("Speed", Mathf.Abs(horizontal));

        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void HandleInput(){
        bool shouldMoveLeft = false;
        bool shouldMoveRight = false;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < Screen.width / 2)
            {
                shouldMoveLeft = true;
            }
            else
            {
                shouldMoveRight = true;
            }
        }

        if (Input.GetKey(KeyCode.A))
            shouldMoveLeft = true;

        if (Input.GetKey(KeyCode.D))
            shouldMoveRight = true;

        Flip();

        MovementServerRpc(shouldMoveRight, shouldMoveLeft);
    }


    [ServerRpc]
    private void MovementServerRpc(bool clientMovingRight, bool clientMovingLeft){
        movingRight = clientMovingRight;
        movingLeft = clientMovingLeft;
    }
}
