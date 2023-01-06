using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();  // Get the Rigidbody component of the current objct
        bulletRigidbody.velocity = transform.forward * speed;  // Change its velocity

        Destroy(gameObject, 3f);  // Destroy the current object after 3.0f seconds
    }

    void OnTriggerEnter(Collider other) {
        // If the hit object has a tag "Player"
        if(other.tag == "Player") {
            PlayerController playerController = other.GetComponent<PlayerController>();  // Get the PlayerController(script) Component 

            if(playerController != null) {
                playerController.Die();  // Call the function Die()
            }
        }
    }
}
