using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Rigidbody playerRB;
    
    private Vector3 moveInput;
    private Vector3 moveVel;

    private Camera mainCam;

    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject bullet;
    public bool hasHammer = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        mainCam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        moveVel = playerSpeed * moveInput;

        Ray cameraRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (ground.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.green);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        playerRB.velocity = moveVel;
    }

    void Shoot()
    {
        Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
    }

    public void TakeHammer()
    {
        hasHammer = true;
    }
}
