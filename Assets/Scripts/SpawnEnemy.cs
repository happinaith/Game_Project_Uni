using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 25f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", spawnTime, spawnTime);
    }

    private void spawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation) as GameObject;
    }
}
