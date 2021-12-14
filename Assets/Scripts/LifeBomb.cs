using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBomb : MonoBehaviour
{
    private GameObject bombRep;
 
    void Start()
    {
        bombRep = GameObject.Find("Tnt");
        AudioManager.instance.SonsFXToca(4);

    }

    
    void Update()
    {
        StartCoroutine(Life());
    }

    IEnumerator Life()
    {
       
            yield return new WaitForSeconds(0.2f);
            Destroy(bombRep.gameObject); 
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);

    }
}
