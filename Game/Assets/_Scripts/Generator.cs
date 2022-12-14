using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject Gold;
    [SerializeField] GameObject left;
    [SerializeField] GameObject right;

    [SerializeField] GameObject leftPointer;
    [SerializeField] GameObject rightPointer;
    float Middle;


    [SerializeField] GameObject goldenSpawner;
    
    void Start()
    {
        Statistics.LosedPoint += Generate;
        HealthSlider.LowHp += Generate;
        Statistics.UpdateGameCount += Checking;

        Middle = (right.transform.position.x + left.transform.position.x)/2;
    }

    void Checking(int count)
    {
        if (Statistics.GameCount==5)
        {
            var yPos = Random.Range(rightPointer.transform.position.y + 1, right.transform.position.y);
            var x = Random.Range(left.transform.transform.position.x, right.transform.position.x);

            var a = Instantiate(goldenSpawner, new Vector2(x, yPos), Quaternion.identity);
            var y = a.GetComponent<Spawner>();
            
            y.ChangeTimeBetweenSpawn(Random.Range(3,30));
            y.ChanceChangeDirection = Random.Range(1, 10);
            y.ChanceChangeSpeed = Random.Range(1, 10);
        }
    }

    void Generate()
    {
        {
            if (Random.Range(0, 10) >= 5)
                StartCoroutine(Animate(leftPointer, left, Gold));
            else StartCoroutine(Animate(rightPointer, right, Gold));
        }            
    }

    private IEnumerator Animate(GameObject obj, GameObject border, GameObject pref)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(3f);
        obj.SetActive(false);
        yield return new WaitForSeconds(1f);
        
        var yPos = border.transform.position.y+1;
        float X;

        if (border == left)
        {
            X = Random.Range(border.transform.position.x, Middle);
        }
        else
        {
            X = Random.Range(Middle, border.transform.position.x);
        }

        Instantiate(pref, new Vector2(X, yPos), Quaternion.identity);
    }

    private void OnDestroy()
    {
        Statistics.LosedPoint -= Generate;
        HealthSlider.LowHp -= Generate;
    }
}
