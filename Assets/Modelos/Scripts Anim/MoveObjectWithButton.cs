using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObjectWithButton : MonoBehaviour
{
    public GameObject objectToMove;
    public float targetYPosition = 5.0f;
    public float animationDuration = 1.0f;

    private bool isAnimating = false;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TriggerAnimation);
    }

    IEnumerator MoveObjectCoroutine()
    {
        isAnimating = true;

        Vector3 initialPosition = objectToMove.transform.position;
        Vector3 targetPosition = new Vector3(initialPosition.x, targetYPosition, initialPosition.z);

        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            objectToMove.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isAnimating = false;
    }

    void TriggerAnimation()
    {
        if (!isAnimating)
        {
            StartCoroutine(MoveObjectCoroutine());
        }
    }
}

