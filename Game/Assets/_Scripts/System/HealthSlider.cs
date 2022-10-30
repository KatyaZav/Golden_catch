using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] float MaxHealth;
    [SerializeField] float waitTime;

    float _health;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        _health = MaxHealth;

        StartCoroutine(SliderWork());
        Statistics.UpdateGameCount += AddHealth;
    }

    IEnumerator SliderWork()
    {
        while (true)
        {
            if (_health <= 0)
            {
                Debug.Log("Lose");
                SceneManager.LoadScene(0);
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

    void AddHealth(int count)
    {
        _health += count * 2;

        if (_health > MaxHealth)
            _health = MaxHealth + 1;

        UpdateSlider();
    }
}
