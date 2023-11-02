using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clic2Continue : MonoBehaviour
{
    [SerializeField] private GameObject targetCanvas;
    [SerializeField] private int Targetscene;
    [SerializeField] private bool UseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")) //mouse 0, es decir botón izquierdo
        {
            if (UseCanvas)
            {
                targetCanvas.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                SceneManager.LoadScene(Targetscene);
            }
        }
 
    }
}
