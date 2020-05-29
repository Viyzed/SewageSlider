using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMove_Demo: MonoBehaviour {

    [SerializeField] private LayerMask groundLayerMask; 

    public int playerSpeed = 10;
    public int playerJumpPower = 1500;
    private float moveX;
    public bool isGrounded;
    public float extraHeightText = 0.5f;

    // Update is called once per frame
    void Update() {

        PlayerMove();
        PlayerRaycast();
        
    }

    void PlayerMove() {

        //Controls
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }

        //Animation

        //Player direction
        if(moveX < 0.0f) {
            GetComponent<SpriteRenderer>().flipX = true;
        } 
        else if(moveX > 0.0f) {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Jump() {

        //Jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
        //GetComponent<Rigidbody2D>().MoveRotation(0);

    }

    void PlayerRaycast() {
        RaycastHit2D hit = Physics2D.BoxCast(gameObject.GetComponent<CircleCollider2D>().bounds.center, gameObject.GetComponent<CircleCollider2D>().bounds.size, 0f, Vector2.down, extraHeightText, groundLayerMask);
        Color rayColour;
        if(hit.collider != null) {
            rayColour = Color.green;
            isGrounded = true;
        } else {
            rayColour = Color.red;
            isGrounded = false;
        }
        //BoxCast rays have bugs
        UnityEngine.Debug.DrawRay(gameObject.GetComponent<CircleCollider2D>().bounds.center + new Vector3(gameObject.GetComponent<CircleCollider2D>().bounds.extents.x, 0), Vector2.down * (gameObject.GetComponent<CircleCollider2D>().bounds.extents.y + extraHeightText), rayColour);
        UnityEngine.Debug.DrawRay(gameObject.GetComponent<CircleCollider2D>().bounds.center - new Vector3(gameObject.GetComponent<CircleCollider2D>().bounds.extents.x, 0), Vector2.down * (gameObject.GetComponent<CircleCollider2D>().bounds.extents.y + extraHeightText), rayColour);
        UnityEngine.Debug.DrawRay(gameObject.GetComponent<CircleCollider2D>().bounds.center - new Vector3(gameObject.GetComponent<CircleCollider2D>().bounds.extents.x, gameObject.GetComponent<CircleCollider2D>().bounds.extents.y), Vector2.right * (gameObject.GetComponent<CircleCollider2D>().bounds.extents.y + extraHeightText), rayColour);

        if(hit.collider.tag == "Germ") {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

}
