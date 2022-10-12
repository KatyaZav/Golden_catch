using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountText : MonoBehaviour
{
    TextMeshPro text;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        Statistics.UpdateGameCount += UpdateText;
        UpdateText(Statistics.GameCount);
    }

    void UpdateText(int count)
    {
        text.text = string.Format("Очки: {0}", count);
    }
}
