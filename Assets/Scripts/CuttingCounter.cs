using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;    


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


    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            //Tem um kitchenObject aqui
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);           
        }
    }


}
