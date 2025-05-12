using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    //I made the player faster, because I want to make everything a bit harder, and make it more likely for you to slam into one of the poison mushrooms. 
    public float jumpSpeed = 6f;
    //I changed the jumpspeed because i wanted to make it harder for the player, and to stop the jumps fromcovering the whole map. 
    public Transform respawnPoint; // Assign this in the Inspector

    private float direction = 0f;
    private Rigidbody2D player;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (direction != 0f)
        {
            player.linearVelocity = new Vector2(direction * speed, player.linearVelocity.y);
        }
        else
        {
            player.linearVelocity = new Vector2(0, player.linearVelocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            player.linearVelocity = new Vector2(player.linearVelocity.x, jumpSpeed);
        }
    }

    // Trigger-based obstacle detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            // Respawn player at the respawn point
            transform.position = respawnPoint.position;
            player.linearVelocity = Vector2.zero; // Reset velocity
        }
    }
}
