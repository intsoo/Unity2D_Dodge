using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get user input with Input.GetAxis
        float xInput = Input.GetAxis("Horizontal");  // -1.0, 0, 1.0
        float zInput = Input.GetAxis("Vertical");  // -1.0, 0, 1.0

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;  // Instantly set the velocity of the current Rigidbody


    /*
        // Get user input with Input.GetKey

        if(Input.GetKey(KeyCode.UpArrow) == true){  // up
            playerRigidbody.AddForce(0f, 0f, speed);  // 
        }
        if(Input.GetKey(KeyCode.DownArrow) == true){
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if(Input.GetKey(KeyCode.RightArrow) == true) {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        if(Input.GetKey(KeyCode.LeftArrow) == true) {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
    */
    }

    public void Die() {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();  // 게임메니저 타입의 오브제트 가져옴
        gameManager.EndGame();
    }
}
