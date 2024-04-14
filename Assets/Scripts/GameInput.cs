using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.BasicControls.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        UnityEngine.Vector2 inputVector = playerControls.BasicControls.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        Debug.Log(inputVector);
        return inputVector;
    }
}
