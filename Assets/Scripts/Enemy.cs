using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 startPosition;
    public Vector3 targetPosition;
    public float moveSpeed;
    private bool movingTowardTargetPosition;

    void Start() {
        startPosition = transform.position;
        movingTowardTargetPosition = true;
    }

    void Update() {
        if (movingTowardTargetPosition) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition) {
                movingTowardTargetPosition = false;
            }
        } else {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);

            if (transform.position == startPosition) {
                movingTowardTargetPosition = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Player>().GameOver();
        }
    }
}
