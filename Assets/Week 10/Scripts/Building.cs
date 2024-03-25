using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform[] pieces;
    public float buildTime = 1;

    Vector3[] pieceScales;
    // Start is called before the first frame update
    private void Start()
    {
        pieceScales = new Vector3[pieces.Length];

        for(int i = 0; i < pieces.Length; i++)
        {
            pieceScales[i] = pieces[i].localScale;
            pieces[i].localScale = Vector3.zero;
        }
        StartCoroutine(Build());
    }

    // Update is called once per frame
    IEnumerator Build()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            float timer = 0;
            while (timer < buildTime)
            {
                timer += Time.deltaTime;
                pieces[i].localScale = Vector3.Lerp(Vector3.zero, pieceScales[i], timer / buildTime);
                yield return null;
            }
        }
    }
}
