using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viceMovement : MonoBehaviour
{
    public float smoothness = 0.5f; // Adjust this value to control the smoothness of the transition

    public void MoveUp()
    {
        StartCoroutine(MoveObject(transform.position, transform.position + new Vector3(0f, 0f, -.1f)));
    }

    public void MoveDown()
    {
        StartCoroutine(MoveObject(transform.position, transform.position + new Vector3(0f, 0f, .1f)));
    }

    public void MoveLeft()
    {
        StartCoroutine(MoveObject(transform.position, transform.position + new Vector3(0f, 0.1f, 0f)));
    }

    public void MoveRight()
    {
        StartCoroutine(MoveObject(transform.position, transform.position + new Vector3(.1f, 0f, 0f)));
    }

    private IEnumerator MoveObject(Vector3 startPosition, Vector3 targetPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < smoothness)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / smoothness);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}