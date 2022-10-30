using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip ButtonClick;
    [SerializeField] AudioClip GoldCatched;
    [SerializeField] AudioClip GoldDrop;

    [SerializeField]AudioSource sourse;

    void Start()
    {
        sourse = GetComponent<AudioSource>();

        Statistics.UpdateGameCount += Count;
        Statistics.LosedPoint += Lose;
    }

    private void Count(int x)
    {
        sourse.PlayOneShot(GoldCatched);
    }

    private void Lose()
    {
        sourse.PlayOneShot(GoldDrop);
    }

    public void ButtonSound()
    {
        sourse.PlayOneShot(ButtonClick);
    }
}
