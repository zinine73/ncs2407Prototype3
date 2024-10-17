using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController pc;
    private float leftBound = -15;
    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (pc.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);        
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("OBSTACLE"))
        {
            Destroy(gameObject);
        }
    }
}
