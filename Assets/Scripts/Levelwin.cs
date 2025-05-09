using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelwin : MonoBehaviour
{
    public GameObject telebox;
    public GameObject Player;
    public GameObject Uithing;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            telebox.SetActive(true);
            if (Player.TryGetComponent<SnoweysMovementscript>(out var compSnow))
            {
                compSnow.enabled = false;
            }
            if (Player.TryGetComponent<RobotMovementscript>(out var compRob))
            {
                compRob.enabled = false;
            }
            Player.SetActive(false);
            StartCoroutine(Turnoff());
        }
    }
    private void Start()
    {
        telebox.SetActive(false);
    }
    IEnumerator Turnoff()
    {
        yield return new WaitForSeconds(5);
        telebox.SetActive(false);
        Uithing.SetActive(true);
        yield return new WaitForSeconds(1);
    }
}
