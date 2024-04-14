using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 2f;

    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteractions()
    {
        UnityEngine.Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        UnityEngine.Vector3 moveDir = new UnityEngine.Vector3(inputVector.x, 0f, inputVector.y);

        float interactDistance = 2f;
        Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit,interactDistance);
    }

    private void HandleMovement()
    {
        UnityEngine.Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        UnityEngine.Vector3 moveDir = new UnityEngine.Vector3(inputVector.x, 0f, inputVector.y);

        float playerRadius = .7f;
        float playerHeight = 2f;
        float moveDistance = moveSpeed * Time.deltaTime;

        bool canWalk = !Physics.CapsuleCast(transform.position, transform.position + UnityEngine.Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);


        if (!canWalk)
        {

            UnityEngine.Vector3 moveDirx = new UnityEngine.Vector3(moveDir.x,0,0).normalized;
            canWalk = !Physics.CapsuleCast(transform.position, transform.position + UnityEngine.Vector3.up * playerHeight, playerRadius, moveDirx, moveDistance);

            if (canWalk)
            {
                moveDir = moveDirx;
            }
            else
            {
                UnityEngine.Vector3 moveDirZ = new UnityEngine.Vector3(0,0,moveDir.z).normalized;
                canWalk = !Physics.CapsuleCast(transform.position, transform.position + UnityEngine.Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canWalk)
                {
                    moveDir = moveDirZ;
                }
                else
                {
                    // cannot move in any direction
                }
            }
        }
        
        if (canWalk)
        {
            transform.position += moveDir * moveDistance;
        }
        
        isWalking = moveDir != UnityEngine.Vector3.zero;

        float rotateSpeed = 10f;

        transform.forward = UnityEngine.Vector3.Slerp( transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }
}
