using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trave : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("bola"))
        {
            AudioManager.instance.SonsFXToca(2);
        }
    }
}
