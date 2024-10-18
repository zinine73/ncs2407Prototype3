using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private AudioSource playerAudio;
    public float jumpForce;
    public float gravittyModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem psCrash;
    public ParticleSystem psDirt;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Physics.gravity *= gravittyModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            psDirt.Stop();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            anim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            isOnGround = true;
            if (!gameOver) psDirt.Play();
        }
        else if (collision.gameObject.CompareTag("OBSTACLE"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            psCrash.Play();
            psDirt.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
