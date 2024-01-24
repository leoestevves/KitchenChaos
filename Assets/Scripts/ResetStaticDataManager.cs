using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Codigo utilizando para resetar eventos e evitar problemas quando mudar de cena

public class ResetStaticDataManager : MonoBehaviour
{
    private void Awake()
    {
        CuttingCounter.ResetStaticData();
        BaseCounter.ResetStaticData();
        TrashCounter.ResetStaticData();
    }


}
