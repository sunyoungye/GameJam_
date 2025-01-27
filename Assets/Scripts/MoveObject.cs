using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    // Collision Water
    public float updatedWatering;

    public Image waterFill;
    public float maxWaterFill;

    public GameObject wateringCan;
    public GameObject flower;


    // Move Watering Can
    private Vector2 originPosition;

    void Start()
    {
        originPosition = transform.position;
    }

    void Update()
    {
       waterFill.fillAmount = updatedWatering / maxWaterFill;
    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
        }
    }

    private void OnMouseUp()
    {
        StartCoroutine(ReturnToOriginPosition());
    }

    private IEnumerator ReturnToOriginPosition()
    {
        float elapsedTime = 0f;
        float duration = 0.5f;

        Vector2 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector2.Lerp(startPosition, originPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originPosition;
    }

    private IEnumerator ReturnToOriginPosition2()
    {
        float elapsedTime = 0f;
        float duration = 1f;

        Vector2 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector2.Lerp(startPosition, originPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originPosition;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject == flower)
        {
            Debug.Log("Well it's fine collision");
            updatedWatering = updatedWatering - 20;
            StartCoroutine(ReturnToOriginPosition2());
        }
    }
}
