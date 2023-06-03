using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class BasicMovement : NetworkBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce; 

    private Rigidbody2D playerBody;
    private BoxCollider2D playerCollider;

    private bool movingLeft, movingRight, jumping;

    private float xMovement = 0f;
    private float yMovement = 0f;

    void Start()
    {
        Debug.Log("Player " + OwnerClientId + " init start");

        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();

        Debug.Log("Player " + OwnerClientId + " init done");
    }

    void Update(){
        if(!IsOwner)
            return;

        handle_input();
    }

    void FixedUpdate()
    {
        xMovement = 0f;

        if(movingLeft)
            xMovement += -moveSpeed;

        if(movingRight)
            xMovement += moveSpeed;

        if(jumping && is_grounded())
            yMovement = jumpForce;

        xMovement *= Time.deltaTime;

        playerBody.velocity = new Vector2(xMovement, yMovement);
    }

    [ServerRpc]
    private void movement_ServerRpc(bool clientMovingLeft, bool clientMovingRight, bool clientJumping){
            movingLeft = clientMovingLeft;
            movingRight = clientMovingRight;
            jumping = clientJumping;
    }

    private void handle_input(){
        bool inputMovingLeft, inputMovingRight, inputJumping;

        inputMovingLeft = Input.GetKey(KeyCode.A);
        inputMovingRight = Input.GetKey(KeyCode.D);
        inputJumping = Input.GetKeyDown(KeyCode.Space) && is_grounded();

        movement_ServerRpc(inputMovingLeft, inputMovingRight, inputJumping);
    }

    private bool is_grounded(){
        return Physics2D.BoxCast(
                playerCollider.bounds.center,
                playerCollider.bounds.size,
                0f,
                Vector2.down,
                .1f,
                groundLayer
        ).collider != null;
    }
}
