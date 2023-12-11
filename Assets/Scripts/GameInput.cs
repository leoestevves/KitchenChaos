using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();        

        inputVector = inputVector.normalized; //Nao anda mais rapido quando pressiona os dois botoes ao mesmo tempo

        Debug.Log(inputVector);
        return inputVector;
    }


}
