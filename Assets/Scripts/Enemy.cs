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
    bool StopAttack = false;
    public float detectionrange;
    void Start()
    {
        enemyHealth = enemyMaxHealth;
        player = null;
    }
    public void damageEnemy(float damage)
    {
        enemyHealth -= damage;
        // if the health is less then 0 Game over.
    }
     void Update()
    {
        Collider2D Detectionzone = Physics2D.OverlapCircle(transform.position, detectionrange, 1 << 3);
        if (player == null)
        {
        player = GameObject.FindGameObjectWithTag("Player").transform;
            print("Hello world!");
        }

        if (Detectionzone)
        {


            if (transform.position.x < player.position.x)
            {
                Rb.velocity = new Vector2(speed, Rb.velocity.y);
            }
            else
            {
                if (transform.position.x == player.position.x)
                {
                    return;
                }
                Rb.velocity = new Vector2(speed * -1, Rb.velocity.y);
            }
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
    
        
        if (enemyHealth <= 0)
        {
            Storeddata.gainxp(5);
            Destroy(gameObject);
            int goldchance = Random.Range(1,4);
           if(goldchance != 1)
            {
                Storeddata.setgold(Storeddata.getgold() + Random.Range(1,10));
            }
            
        }
        if (enemyHealth > enemyMaxHealth)
        {
            enemyHealth = enemyMaxHealth;
        }
    }

    void jump()
    {
       Rb.velocity = new Vector3(0, jumpForce, 0);
        jumps += 1;
    }
    // Add more if statements when you add more characters \/ 
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Onground = true;
            jumps = 0;
        }
        if (collision.gameObject.tag == "Player" && StopAttack == false)
        {
            StartCoroutine(damageplayer(collision.gameObject));
            print("damaged player");
        }
    }

    IEnumerator damageplayer(GameObject player)
    {
        StopAttack = true;
        RobotMovementscript rm = player.GetComponent<RobotMovementscript>();
        SnoweysMovementscript sm = player.GetComponent<SnoweysMovementscript>();

        if (rm == null)
        {
            // Snowey
            sm.PlayerHealth(5);
        }
        else
        {
            //Robot
            rm.PlayerHealth(5);
        }
        yield return new WaitForSeconds(3);
        StopAttack = false;
    }
}
