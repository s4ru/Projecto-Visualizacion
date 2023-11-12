using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positionrandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        transform.position= new Vector3(Random.Range(0, 100 ),3,Random.Range(0, 100));

    }
}
