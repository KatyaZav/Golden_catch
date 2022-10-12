using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();//GetComponent<TextMeshPro>();
        UpdateText(Statistics.GameCount);
        
        Statistics.UpdateGameCount += UpdateText;
    }

    void UpdateText(int count)
    {
        text.text = string.Format("Очки: {0}", count);
    }
}
