using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip ButtonClick;
    [SerializeField] AudioClip GoldCatched;
    [SerializeField] AudioClip GoldDrop;

    [SerializeField] AudioClip menu;
    [SerializeField] AudioClip level;

    public static SoundManager Manager;
    static AudioSource sourse;
    static AudioSource MusicSource;

    private void Awake()
    {
        if (Manager == null)
        {
            Manager = this;
            AudioSource[] sources = GetComponentsInChildren<AudioSource>();
            MusicSource = sources[1];
            //MusicSource.GetComponentInChildren<AudioSource>();
            //sourse = GetComponent<AudioSource>();
            sourse = sources[0];

            UpdateVolume();
        }
        else
        {
            Debug.LogWarning("Sound manager generated more than once");
            Destroy(gameObject);
        }

        Statistics.UpdateGameCount += Count;
        Statistics.LosedPoint += Lose;
        MainMenu.ButtonClicked += ButtonSound;


        PlayMusic(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        Statistics.UpdateGameCount -= Count;
        Statistics.LosedPoint -= Lose;
        MainMenu.ButtonClicked -= ButtonSound;

        Manager = null;
        MusicSource = null;
        sourse = null;
    }

    /*void Start()
    {
        if (Manager == null)
        {
            Manager = this;
            MusicAudio.GetComponentInChildren<AudioSource>();
            sourse = GetComponent<AudioSource>();

            UpdateVolume();
        }
        else
        {
            Debug.LogWarning("Sound manager generated more than once");
            Destroy(gameObject);
        }        
    }*/

    private void Count(int x)
    {
        sourse.PlayOneShot(GoldCatched);
    }

    public static void PlayMusic(int number)
    {
        switch (number)
        {
            case 0:
                MusicSource.clip = Manager.menu;
                break;
            case 1:
                MusicSource.clip = Manager.level;
                break;
            default:
                Debug.LogWarning("Music not founded");
                break;
        }

        MusicSource.Play();
    }

    private void Lose()
    {
        sourse.PlayOneShot(GoldDrop);
    }

    private void ButtonSound()
    {
        sourse.PlayOneShot(ButtonClick);
    }

    public void UpdateVolume()
    {
        sourse
            .volume = 
            YG.YandexGame.savesData.SoundVolume;
        MusicSource.volume = YG.YandexGame.savesData.MusicVolume;
    }
}
