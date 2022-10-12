using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, ICollectable
{
    [SerializeField] GameObject disapearEffectPrefab;
    [SerializeField] GameObject collectEffectPrefab;

    public void Collect()
    {
        var effect = Instantiate(collectEffectPrefab);
        effect.transform.position = transform.position;

        Debug.Log("Pick gold");
        Destroy(gameObject);
    }

    public void Disapear()
    {
        var explosion = Instantiate(disapearEffectPrefab);
        explosion.transform.position = transform.position;
        Destroy(gameObject);

        Statistics.AddCount(1);
    }
}
