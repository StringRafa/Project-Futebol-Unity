using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilhaManenger : MonoBehaviour
{

    private SliderJoint2D trap;
    private JointMotor2D aux;

    void Start()
    {

        trap = GetComponent<SliderJoint2D>();
        aux = trap.motor;
    
    }

   
    void Update()
    {

        if (trap.limitState == JointLimitState2D.UpperLimit)
        {
            aux.motorSpeed = Random.Range(-1, -5);
            trap.motor = aux;
        }
        if (trap.limitState == JointLimitState2D.LowerLimit)
        {
            aux.motorSpeed = Random.Range(1, 5);
            trap.motor = aux;
        }

    }

 
}
