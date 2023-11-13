using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinalDOTAnims : MonoBehaviour
{
    [SerializeField] GameObject cubos;//0
    [SerializeField] GameObject kiosko;//1
    [SerializeField] GameObject pilares;//2
    [SerializeField] GameObject arena;//3
    [SerializeField] GameObject arenaCasa;//4
    [SerializeField] GameObject plano; //5

    [SerializeField] private float[] tiempos = new float[6];
    [SerializeField] private float[] ubicaciones = new float[6];

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        plano.transform.DOMoveY(ubicaciones[5], tiempos[5]);
        kiosko.transform.DOMoveY(ubicaciones[1], tiempos[1]);
        arenaCasa.transform.DOMoveY(ubicaciones[4], tiempos[4]);
        pilares.transform.DOMoveY(ubicaciones[2], tiempos[2]);
        cubos.transform.DOMoveY(ubicaciones[0], tiempos[0]);
        arena.transform.DOMoveY(ubicaciones[3], tiempos[3]);
    }

}
