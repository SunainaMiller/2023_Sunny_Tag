using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    public Vector2 forceToApply; // when something bumps into/pushes player
    public Vector2 PlayerInput;
    public float forceDamping;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 moveForce = PlayerInput * moveSpeed;

        // something about adding force to player if they get bumped & overriding player controls https://www.youtube.com/watch?v=5enQERJULh0
        moveForce += forceToApply; // force
        forceToApply /= forceDamping;

        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        rb.velocity = moveForce;
    }

    // when player gets hit by sth by that tag, apply force

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            forceToApply += new Vector2(-20, 0);
            Destroy(collision.gameObject);
        }
    }*/
}
