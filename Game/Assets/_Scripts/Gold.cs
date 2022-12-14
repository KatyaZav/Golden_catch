using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, ICollectable
{
    [SerializeField] GameObject disapearEffectPrefab;
    [SerializeField] GameObject collectEffectPrefab;

    private static int GoldPower = 1;

    public static void UpdateGoldPower(int value)
    {
        if (value > 0)
            GoldPower = value;
    }

    public void Collect()
    {
        var effect = Instantiate(collectEffectPrefab);
        effect.transform.position = transform.position;

        Destroy(gameObject);
        Statistics.AddCount(GoldPower, 1);
    }

    public void Disapear()
    {
        var explosion = Instantiate(disapearEffectPrefab);
        explosion.transform.position = transform.position;

        Destroy(gameObject);
        Statistics.AddLosePoints();
    }
}
