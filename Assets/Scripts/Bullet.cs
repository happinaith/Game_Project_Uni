using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private float maxDistance;
    public int damageDeal;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().HurtEnemy(damageDeal);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Baricade")
        {
            Debug.Log("Dealt");
            collision.gameObject.GetComponent<BaricadeHealth>().HurtBaricade(damageDeal);
            Destroy(gameObject);
        }
    }
}
