using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondsCount : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        text.text = YG.YandexGame.savesData.Diamonds.ToString();   
    }
}
