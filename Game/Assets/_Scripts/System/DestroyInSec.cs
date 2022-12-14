using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSec : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        Debug.Log("ar");
        yield return new WaitForSeconds(2);
        Debug.Log("arrr");
        Destroy(gameObject);
    }
}
