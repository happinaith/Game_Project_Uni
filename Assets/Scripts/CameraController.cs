using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smooth = 0.2f;

    private Vector3 velocity = Vector3.zero;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.z = player.position.z;
        pos.y = player.position.y + 20f;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }
}
