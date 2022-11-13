using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       try
        {
            ICollectable obj = collision.gameObject.GetComponent<ICollectable>();
          
            Debug.Log("Deleted " + collision.gameObject.ToString());
            obj.Disapear();
            
        }
        catch(System.Exception e)
        {
            Debug.LogWarning("Fall something (" + collision.gameObject.ToString() +") non ICollectible! " + e );
            Destroy(collision.gameObject);
        }
    }
}
