using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttemptTracker : MonoBehaviour
{
    public GameObject saveManager;
    private SaveManager _saveManager;

    // Start is called before the first frame update
    void Start()
    {
        _saveManager = saveManager.GetComponent<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = ("Attempts: " + _saveManager.attemptCount.ToString());
    }
}
