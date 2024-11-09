using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed = 5f; // Speed at which the object moves

    private void Update()
    {
        // Get input from the horizontal axis (Arrow keys or A/D keys)
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Move the object based on the input
        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check the tag of the collided object
        if (other.CompareTag("Coin"))
        {
            ScoreManager.Instance.AddScore();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Poison"))
        {
            ScoreManager.Instance.EndGame();
           // Destroy(other.gameObject);
        }
      
    }
}
