using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Growing : MonoBehaviour
{
    public GameObject square;
    public GameObject triangle;
    public GameObject circle;
    public TextMeshProUGUI squareTMP;
    public TextMeshProUGUI triangleTMP;
    public TextMeshProUGUI circleTMP;
    public TextMeshProUGUI crTMP;
    public int running;
    Coroutine coroutine;

    bool Circlerunning = true;
    void Start()
    {
        StartCoroutine(GrowingShapes());
    }

    void Update()
    {
        crTMP.text = "Coroutines: " + running.ToString();
    }

    IEnumerator GrowingShapes()
    {
        running += 1;
        yield return StartCoroutine(Square());
        StartCoroutine (Triangle());
        yield return new WaitForSeconds(1);
        coroutine = StartCoroutine(Circle());
        yield return coroutine;
        running -= 1;
    }
    IEnumerator Square()
    {
        running += 1;
        float size = 0;
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            square.transform.localScale = scale;
            squareTMP.text = "Square: " + scale;
            yield return null;
        }
        running -= 1;
    }
    IEnumerator Triangle()
    {
        running += 1;
        float size = 0;
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            triangle.transform.localScale = scale;
            triangleTMP.text = "Triangle: " + scale;
            yield return null;
        }
        running -= 1;
    }
    IEnumerator Circle()
    {
        running += 1;
        while (Circlerunning)
            {
            float size = 0;
            while (size < 5)
            {
                size += Time.deltaTime;
                Vector3 scale = new Vector3(size, size, size);
                circle.transform.localScale = scale;
                circleTMP.text = "Cirlce: " + scale;
                yield return null;
            }
            while (size > 0)
            {
                size -= Time.deltaTime;
                Vector3 scale = new Vector3(size, size, size);
                circle.transform.localScale = scale;
                circleTMP.text = "Cirlce: " + scale;
                yield return null;
            }
        }
        running -= 1;
    }
}
