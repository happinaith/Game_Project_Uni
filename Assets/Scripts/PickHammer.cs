using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHammer : MonoBehaviour
{
    public GameObject barr;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeHammer();
            Destroy(barr);
            Destroy(gameObject);
        }
    }
}
