using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemyHealth;
    public float enemyMaxHealth;
    public Transform player;
    public Rigidbody2D Rb;
    public float speed;
    public Animator anim;
    public float jumpForce;
    int maxjumps = 2;
    int jumps = 0;
    bool Onground = false;
    void Start()
    {
        enemyHealth = enemyMaxHealth;

    }
    public void damageEnemy(float damage)
    {
        enemyHealth -= damage;
        // if the health is less then 0 Game over.
    }
     void Update()
    {
        if(transform.position.x < player.position.x)
        {
            Rb.velocity = new Vector2(speed, Rb.velocity.y);
        }
        else
        {
         if(transform.position.x == player.position.x)
            {
                return;
            }
            Rb.velocity = new Vector2(speed * -1, Rb.velocity.y);
        }
        float X = Input.GetAxis("Horizontal");
        if (X != 0)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }

        RaycastHit2D Beam;

        if (Rb.velocity.x < 0)
        {
            Beam = Physics2D.Raycast(transform.position, Vector3.left, 2f, 1<<6);
        }
        else
        {
            Beam = Physics2D.Raycast(transform.position, Vector3.right, 2f, 1<<6);
        }

        if (Beam && jumps < maxjumps)
        {
            jump();
        }
    }

    void jump()
    {
       Rb.velocity = new Vector3(0, jumpForce, 0);
        jumps += 1;
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Onground = true;
            jumps = 0;
        }
    }
}
