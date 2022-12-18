using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, jumpForce;
    float horizontal;
    public float horizontalInput;
    public bool canJump;

    public float Y;

    public Transform lighting;

    Rigidbody rb;
    CapsuleCollider capsule;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        animator.SetBool("Idle", true);
        canJump = true;
    }
    void Update()
    {
        MovePlayer();
        Jump();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale = 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Time.timeScale = 0.2f;
        }

        Y = transform.position.y;
        if (transform.position.y <= -15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        horizontal += horizontalInput * moveSpeed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x, transform.position.y, horizontal);

        //animasi


        if (horizontalInput < 0)
        {
            transform.eulerAngles = Vector3.up * 180;


            lighting.localEulerAngles = new Vector3(40, -180, 0);
            lighting.localPosition = new Vector3(lighting.localPosition.x, lighting.localPosition.y, 2.5f);
        }
        if (horizontalInput > 0)
        {
            transform.eulerAngles = Vector3.zero;


            lighting.localEulerAngles = new Vector3(40, 0, 0);
            lighting.localPosition = new Vector3(lighting.localPosition.x, lighting.localPosition.y, -2.5f);
        }

        if (horizontalInput != 0)
        {
            animator.SetBool("Run", true);
        }
        else if (horizontalInput == 0)
        {
            
            animator.SetBool("Run", false);
        }
        
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.velocity = Vector3.up * jumpForce;
            canJump = false;
            capsule.center = new Vector3(0, 1f, 0);
            //animasi
            animator.SetTrigger("Jump");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            canJump = true;
            capsule.center = new Vector3(0, 0.4f, 0);
        }
    }
}
