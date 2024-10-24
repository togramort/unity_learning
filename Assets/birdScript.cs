using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && !logic.endOfGame) {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }

        if ((transform.position.y > 20 || transform.position.y < -20) && !logic.endOfGame) {
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        logic.gameOver();
    }
}
