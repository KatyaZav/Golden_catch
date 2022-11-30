using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip ButtonClick;
    [SerializeField] AudioClip GoldCatched;
    [SerializeField] AudioClip GoldDrop;

    [SerializeField]AudioSource sourse;

    private void Awake()
    {
        Statistics.UpdateGameCount += Count;
        Statistics.LosedPoint += Lose;
        MainMenu.ButtonClicked += ButtonSound;       
    }

    void Start()
    {
        if (gameObject != null)
            DontDestroyOnLoad(gameObject);
        var e = GameObject.FindGameObjectsWithTag("SoundManager");
        if (e.Length>1)
        {
            for (int i = 1; i < e.Length; i++)
                Destroy(e[i]);
        }

        sourse = GetComponent<AudioSource>();

    }

    private void Count(int x)
    {
        if (sourse == null)
            Start();

        sourse.PlayOneShot(GoldCatched);
    }

    private void Lose()
    {
        sourse.PlayOneShot(GoldDrop);
    }

    private void ButtonSound()
    {
        sourse.PlayOneShot(ButtonClick);
    }
}
