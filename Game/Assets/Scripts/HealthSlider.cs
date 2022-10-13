using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] float MaxHealth;
    [SerializeField] float waitTime;

    [SerializeField]float _health;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        _health = MaxHealth;

        StartCoroutine(SliderWork());
    }

    IEnumerator SliderWork()
    {
        while (true)
        {
            if (_health <= 0)
            {
                Debug.Log("Lose");
                break;
            }

            if (_health < MaxHealth * 0.2)
                yield return new WaitForSeconds(waitTime * 2);
            else 
                yield return new WaitForSeconds(waitTime);
            

            _health--;
            UpdateSlider();
        }
    }

    void UpdateSlider()
    {
        image.fillAmount =_health / MaxHealth;
    }
}
