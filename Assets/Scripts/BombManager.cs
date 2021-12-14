using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bombFX;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("bola"))
        {
            Instantiate(bombFX, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        }
    }
}
