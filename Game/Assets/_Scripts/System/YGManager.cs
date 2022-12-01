using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YGManager : MonoBehaviour
{
    private void OnEnable() => YG.YandexGame.GetDataEvent += CheckAutorisation;
    private void OnDisable() => YG.YandexGame.GetDataEvent -= CheckAutorisation;


    void Start()
    {
        if (YG.YandexGame.SDKEnabled == true)
            CheckAutorisation();
    }

    private void CheckAutorisation()
    {
        if (!YG.YandexGame.auth)
        {
            YG.YandexGame.AuthDialog();
        }
    }
}
