using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mat_Controller : MonoBehaviour
{

    public Material mat_1,mat_2;
    bool f;
    float timer = 2;
    Image img;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            timer = 2;
            f =!f;

            if(f)
            {
                img.material = mat_2;
            }
            else
            {
                img.material = mat_1;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
