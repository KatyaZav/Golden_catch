using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            ICollectable obj = collision.gameObject.GetComponent<ICollectable>();

            if (obj != null)
            {
                Debug.Log("Deleted " + collision.gameObject.ToString());
                obj.Disapear();
            }
            else
            {
               Debug.LogWarning("Fall something (" + collision.gameObject.ToString() + ") non ICollectible! ");
                Destroy(collision.gameObject);
            }
        }
    }
}
