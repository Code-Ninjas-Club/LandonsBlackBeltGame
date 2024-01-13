using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemyHealth;
    public float enemyMaxHealth;

     void Start()
    {
        enemyHealth = enemyMaxHealth;

    }
    public void damageEnemy(float damage)
    {
        enemyHealth -= damage;
        // if the health is less then 0 Game over.
    }

}
