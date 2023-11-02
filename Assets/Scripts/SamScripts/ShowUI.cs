using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    [SerializeField] Canvas thecanvas;
    [SerializeField] GameObject TargetUI;
    // Start is called before the first frame update
    void Start()
    {
        thecanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnCollisionStay(Collision collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("its happenign");
            thecanvas.enabled = true;
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {

            Debug.Log("its happenign");
            //thecanvas.enabled = true;
            TargetUI.SetActive(true);
        
    }

    private void OnTriggerExit(Collider other)
    {

        Debug.Log("its happenign");
        //thecanvas.enabled = false;
        TargetUI.SetActive(false);
    }
}
