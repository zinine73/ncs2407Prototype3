using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public float gravittyModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravittyModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("OBSTACLE"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
