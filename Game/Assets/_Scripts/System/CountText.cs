using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountText : MonoBehaviour
{
    TextMeshProUGUI text;

    [SerializeField] bool isText = true;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();//GetComponent<TextMeshPro>();
        if (isText)
        {
            UpdateText(Statistics.GameCount);

            Statistics.UpdateGameCount += UpdateText;
        }
        else
        {
            text.text = string.Format("Рекорд: {0}", YG.YandexGame.savesData.RecordCount);
        }
    }

    void UpdateText(int count)
    {
        Debug.Log("ok");
        text.text = string.Format("Очки: {0}", Statistics.GameCount);
    }


    private void OnDestroy()
    {
        Statistics.UpdateGameCount -= UpdateText;
    }
}
