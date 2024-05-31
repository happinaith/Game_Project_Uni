using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    private int currHealth;
    void Start()
    {
        health = UnityEngine.Random.Range(4, 16);
        currHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage)
    {
        currHealth -= damage;
    }
}
