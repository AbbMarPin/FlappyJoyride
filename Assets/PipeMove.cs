using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed = 100;

    void Update()
    {
        if (GameManager.Instance.GameState())
        {
            // Continuosly move the obstacles to the left if the game hasn't ended
            transform.position = new Vector2(transform.position.x - Time.deltaTime * moveSpeed, transform.position.y);
        }
        if (transform.position.x < -290)
        {
            Destroy(gameObject);
        }
    }

}
