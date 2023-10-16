using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenshakeScript : MonoBehaviour
{
    //need something to affect intensity

    public static ScreenshakeScript shakeInstance;

    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    public int determineInt = 0;
    public float intensity = 1;

    public GameObject cracks;

    public GameObject experience;
    public GameObject performance;
    public GameObject busted;

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
            cracks.SetActive(true);
        }
    }

    public void ResetValues()
    {
        cracks.SetActive(false);
    }

    public void determineIntensity(int value)
    { //the passed in int will only ever have a value of 1, 2 or 3, for how well each mechanic was done
        switch (value)
        {
            case 1:
                determineInt += 1;
                break;
            case 2:
                determineInt += 2;
                break;
            case 3:
                determineInt += 3;
                break;
        }
    }

    public void startShaking()
    {
        if (determineInt <= 3)
        {
            Debug.Log("one");
            intensity = 0.5f;
            SaveManager.Instance.experience += 15;
            experience.SetActive(true);
            experience.gameObject.GetComponent<TextMeshProUGUI>().text = "Experience Gained: " + 15.ToString();
            experience.SetActive(false);
            performance.SetActive(true);
            performance.gameObject.GetComponent<TextMeshProUGUI>().text = "Performance: " + "Mediocre...";
            performance.SetActive(false);
            busted.SetActive(true);
            busted.gameObject.GetComponent<TextMeshProUGUI>().text = "Planet Busted? " + "No";
            busted.SetActive(false);
        }
        else if (determineInt <= 5)
        {
            Debug.Log("two");
            intensity = 1.5f;
            SaveManager.Instance.experience += 45;
            experience.SetActive(true);
            experience.gameObject.GetComponent<TextMeshProUGUI>().text = "Experience Gained: " + 45.ToString();
            experience.SetActive(false);
            performance.SetActive(true);
            performance.gameObject.GetComponent<TextMeshProUGUI>().text = "Performance: " + "Impressive";
            performance.SetActive(false);
            busted.SetActive(true);
            busted.gameObject.GetComponent<TextMeshProUGUI>().text = "Planet Busted? " + "No";
            busted.SetActive(false);
        }
        else if (determineInt >= 6)
        {
            Debug.Log("three");
            intensity = 3.0f;
            SaveManager.Instance.experience += 90;
            experience.SetActive(true);
            experience.gameObject.GetComponent<TextMeshProUGUI>().text = "Experience Gained: " + 90.ToString();
            experience.SetActive(false);
            performance.SetActive(true);
            performance.gameObject.GetComponent<TextMeshProUGUI>().text = "Performance: " + "BUSTING!";
            performance.SetActive(false);
            busted.SetActive(true);
            busted.gameObject.GetComponent<TextMeshProUGUI>().text = "Planet Busted? " + "No";
            busted.SetActive(false);
        }

        start = true;
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = Camera.main.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            Camera.main.transform.position = startPosition + (Random.insideUnitSphere * strength * intensity);
            yield return null;
        }
        //screenshake has stopped

        Camera.main.transform.position = startPosition;
        UIManager.Instance.resultsUIActive();
        experience.SetActive(true);
        performance.SetActive(true);
        busted.SetActive(true);
        intensity = 1; //resets values
        determineInt = 0;
    }
}
