using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class experienceTracker : MonoBehaviour
{
    public GameObject SaveManager;
    private SaveManager _saveManager;

    // Start is called before the first frame update
    void Start()
    {
        _saveManager = SaveManager.GetComponent<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = ("Total Experience: " + _saveManager.experience.ToString());
    }
}
