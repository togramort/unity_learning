using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D myRigidBody;
    public float jump;
    public SpriteRenderer sr;
    private void FixedUpdate() {
        float xInput = Input.GetAxis("Horizontal");

        myRigidBody.velocity = new Vector2(xInput * moveSpeed, myRigidBody.velocity.y);   
    }

    void Update() {
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && IsOnTheGround()) {
            myRigidBody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

        if (myRigidBody.velocity.x > 0) {
            sr.flipX = false; 
        } else if (myRigidBody.velocity.y < 0) {
            sr.flipX = true;
        }        
    }

    bool IsOnTheGround() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -1f, 0), Vector2.down, 0.2f);
        return hit.collider != null;
    }

    public void GameOver() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
