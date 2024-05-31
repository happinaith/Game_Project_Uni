using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMedkit : MonoBehaviour
{
    public int healAmn;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().HealPlayer(healAmn);
            Destroy(gameObject);
        }
    }
}
