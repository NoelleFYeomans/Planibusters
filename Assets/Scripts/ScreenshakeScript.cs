using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshakeScript : MonoBehaviour
{
    //need something to affect intensity

    public static ScreenshakeScript shakeInstance;

    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    public float intensity; //will be used to have 3 "levels" of screenshake. Weak, Average, and Powerful.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + (Random.insideUnitSphere * strength);
            yield return null;
        }

        transform.position = startPosition;
    }
}