using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComoJogar : MonoBehaviour
{
    private Animator comojogar;
    void Start()
    {
        comojogar = GameObject.FindGameObjectWithTag("comojogar").GetComponent<Animator>() as Animator;
    }

    public void AnimaInfo()
    {
        comojogar.Play("ComoJogarAnim");
    }
}
