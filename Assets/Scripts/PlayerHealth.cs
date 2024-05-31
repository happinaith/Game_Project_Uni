using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;
    public int startingHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        gameManager = GameObject.Find("GameBehavior").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameManager.loadMainMenu();
        }
    }

    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
    } 

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
    }
}
