using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DotAnims : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] private float targetY;
    [SerializeField] private float theTime;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }

    public void moveThings()
    {

        targetObject.transform.DOMoveY(targetY,theTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        moveThings();
    }
}
