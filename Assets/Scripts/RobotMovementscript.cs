using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RobotMovementscript : MonoBehaviour
{
    public GameObject pausemenu;

    public Rigidbody2D Michelsoftbinbos;
    public AudioSource audioSource;

    public float jumpForce;
    bool Onground = false;
    bool playedSound = false;
    public Animator anim;
    public Sprite[] pictures;
    public Image healthBarImage;
    int jumps = 0;
    int maxjumps = 2;
    
    bool attackdone = true;

   

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pausemenu.SetActive(!pausemenu.activeSelf);
            Time.timeScale = Time.timeScale == 0f ? 1f : 0f;
            
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

        if (X < 0)
        {
            transform.localScale = new Vector3(-1.537962f, 1.501369f, 1);
        }
        else if (X > 0)
        {
            transform.localScale = new Vector3(1.537962f, 1.501369f, 1);
        }

        transform.Translate(X * Time.deltaTime * 10, 0, 0);
        if (Input.GetButtonDown("Jump") && jumps < maxjumps)
        {
            StartCoroutine(resetAnimations("Jump"));
            Michelsoftbinbos.velocity = new Vector3(0, jumpForce, 0);
            jumps += 1;
            anim.SetBool("Jump", true);
        }

        //if (this.transform.position.y < -6.42)
        //{
        //    StartCoroutine(ExampleCoroutine());
        //}
        if (Input.GetKeyDown(KeyCode.X) && !anim.GetBool("Attack"))
        {
            anim.SetBool("Attack", true);
            StartCoroutine(resetAnimations("Attack"));

        }
        if (Input.GetKeyDown(KeyCode.C) && !anim.GetBool("Attack") && !anim.GetBool("Attack2"))
        {     
            anim.SetBool("Attack2", true);
            StartCoroutine(resetAnimations("Attack2"));
        }

       
    }
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Ground")
        {
            Onground = true;
            jumps = 0;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            if ((anim.GetBool("Attack") || anim.GetBool("Attack2")) && attackdone)
            {
                print("Damaged Enemy");
                collision.gameObject.GetComponent<Enemy>().damageEnemy(1);
                attackdone = false;
            }


            //PlayerHealth(3);
        }
    }


    //IEnumerator ExampleCoroutine()
    //{
    //    if (!playedSound)
    //    {
    //        playedSound = true;
    //        Camera.main.GetComponent<AudioSource>().mute = true;
    //        audioSource.PlayOneShot(audioSource.clip, 1);
    //        yield return new WaitForSeconds(4.2f);
    //        Camera.main.GetComponent<AudioSource>().mute = false;
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //    }
    //}

    IEnumerator resetAnimations(string animation)
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool(animation, false);
        if (animation == "Attack" || animation == "Attack2")
        {
            attackdone = true;
        }
    }


    public float playerHealth;
    public float playerMaxHealth;

    void Start()
    {
        playerHealth = playerMaxHealth;
        pausemenu = GameObject.FindGameObjectWithTag("Pause");
        pausemenu.SetActive(false);
    }

    public void PlayerHealth(float damage)
    {
        playerHealth -= damage;
        if (playerHealth > 20)
        {
            healthBarImage.sprite = pictures[0];
        }
        else if (playerHealth > 10)
        {
            healthBarImage.sprite = pictures[1];
        }
        else if (playerHealth > 5)
        {
            healthBarImage.sprite = pictures[2];
        }
        // if the health is less then 0 Game over.
        else if (playerHealth == 0)
        {
            healthBarImage.sprite = pictures[3];
        }
    }
}


