using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISeqs : MonoBehaviour
{
    [SerializeField] GameObject[] UIs;
    private CanvasGroup FScreen;
    // Start is called before the first frame update
    void Start()
    {
        UIs[1].SetActive(false);

        FScreen = UIs[0].GetComponent<CanvasGroup>();
        FScreen.alpha = 0f;
        StartCoroutine(sequencingUI());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator sequencingUI()
    {
        while (FScreen.alpha < 1.0f)
        {
            yield return new WaitForSeconds(0.1f);
            FScreen.alpha += 0.1f;
        }
        yield return new WaitForSeconds(3f);
        while (FScreen.alpha > 0f)
        {
            yield return new WaitForSeconds(0.1f);
            FScreen.alpha -= 0.1f;
        }

        UIs[1].SetActive(true);
    }
}
