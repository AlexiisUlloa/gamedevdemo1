using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColicionBala : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("he is hittler"))
        {
            Destroy(collision.gameObject);  
        }

    }






}
