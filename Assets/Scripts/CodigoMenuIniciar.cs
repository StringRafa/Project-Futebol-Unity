using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodigoMenuIniciar : MonoBehaviour
{

    private Animator barraAnim;
    private bool sobe;

    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }

    public void AnimaMenu()
    {
        barraAnim = GameObject.FindGameObjectWithTag("barraAnim").GetComponent<Animator>();

        if (sobe == false)
        {
            barraAnim.Play("MoviUI");
            sobe = true;
        }
        else
        {
            barraAnim.Play("MoviUIReverso");
            sobe = false;
        }
        
        
        barraAnim.Play("MoviUI");
    }
}
