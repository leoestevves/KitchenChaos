using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;



    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                                            playerRadius, moveDir, moveDistance);

        if (!canMove) //Se encontrar um obstaculo
        {
            // Nao pode se mover na direcao do moveDir

            // Tentar se mover apenas na direcao X
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                                            playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                //Se consegue se mover na direcao X
                moveDir = moveDirX;
            }
            else
            {
                //Nao consegue se mover na direcao X

                //Tentar se mover apenas na direcao Z
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                                            playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    //Pode se mover apenas na direcao Z
                    moveDir = moveDirZ;
                }
                else
                {
                    //Nao consegue se mover em nenhuma direcao
                }
            }
        }


        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }
        

        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); //Ponto A, ponto B, interpolacao
        
    }

    public bool IsWalking()
    {
        return isWalking;
    }


}
