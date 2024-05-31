using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaricadeHealth : MonoBehaviour
{
    public int health;
    private int currHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = UnityEngine.Random.Range(20, 60);
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

    public void HurtBaricade(int damage)
    {
        currHealth -= damage;
    }

}
