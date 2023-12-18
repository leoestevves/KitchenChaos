using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //Nao tem nenhum kitchenObject aqui
            if (player.HasKitchenObject())
            {
                //Player ta carregando algo
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player nao ta carregando nada
            }
        }
        else
        {
            //Tem um kitchenObject aqui
            if (player.HasKitchenObject())
            {
                //Player ta carregando algo
            }
            else
            {
                //Player nao ta carregando nada
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
