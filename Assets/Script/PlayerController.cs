using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Rigidbody playerRb;
    public float speed = 5.0f;
    public float jumpForce = 5;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver = false;
    private float horizontalInput;
    private float forwardInput;
    public GameObject cameraView;
    public ParticleSystem dirtParticule;
    public bool victoire;
    //private Animator playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        //playerAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver == false)
        {
            

            //AJouter une vers le haut rigidbody  //// up = (0 , 1, 0)
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //Déclarer que le personnage n'est plus au sol
            isOnGround = false;
        }
        if (victoire == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(Vector3.forward * speed * forwardInput);
            playerRb.AddForce(Vector3.right * speed * horizontalInput);
        }
        if (transform.position.y < -5)
        {
            gameOver = true;

        }

        if (gameOver)
        {
            transform.position = new Vector3(1, 3, -45);
            playerRb.velocity = new Vector3(0, 0, 0);
            playerRb.angularVelocity = new Vector3(0, 0, 0);
            gameOver = false;
        }
        /*if (isOnGround == true)
        {
            dirtParticule.Stop();
        }*/


    }

    void OnCollisionEnter(Collision collision) // AVEC OBSTACLE OU GROUND?
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            //dirtParticule.Play();
        }


        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            // transform.position = new Vector3(1, 3, -45);

        }

        else if (collision.gameObject.CompareTag("Arrive"))
        {
            gameOver = true;
            Debug.Log("Victoire");
            
            

        }

        if (victoire)
        {
            //playerRb.velocity = new Vector3(0, 0, 0);
            //playerRb.angularVelocity = new Vector3(0, 0, 0);
           dirtParticule.Play();
        }





    }
}
  




