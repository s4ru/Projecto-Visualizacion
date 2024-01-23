using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escapeScript : MonoBehaviour
{
    [SerializeField] string sceneName0;
    private void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(sceneName0);
        }
    }
}
