using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountText : MonoBehaviour
{
    TextMeshProUGUI text;   
    [SerializeField] bool isText = true;
    private void OnEnable() => YG.YandexGame.GetDataEvent += UpdateRecord;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (isText)
        {
            UpdateText(Statistics.GameCount);

            Statistics.UpdateGameCount += UpdateText;
        }
        else
        {
            Debug.Log(string.Format("Record: {0}", YG.YandexGame.savesData.RecordCount));


            if (YG.YandexGame.SDKEnabled == true)
                UpdateRecord();
            else
                text.text = "Рекорд не загружен";
        }
    }

    void UpdateRecord()
    {
        text.text = string.Format("Рекорд: {0}", YG.YandexGame.savesData.RecordCount);
    }

    void UpdateText(int count)
    {
        text.text = string.Format("Очки: {0}", Statistics.GameCount);
    }


    private void OnDestroy()
    {
        Statistics.UpdateGameCount -= UpdateText;
    }
}
