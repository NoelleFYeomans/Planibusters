using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBars : MonoBehaviour
{
    public GameObject UIManager;
    private UIManager _UIManager;

    public int powerMax;
    public int powerCurrent;
    public Image powerMask;
    public Image powerBar;

    private bool isFilling;
    private bool isStopped;

    // Start is called before the first frame update
    void Start()
    {
        _UIManager = UIManager.GetComponent<UIManager>();

        isFilling = true;
        isStopped = false;
    }

    private void FixedUpdate() //I want this to NOT be framerate dependant
    {
        if (!_UIManager.gameplayUI.isActiveAndEnabled) return; //only want this code to be active while the UI element is active

        if (isFilling && !isStopped)
        {
            powerMask.fillAmount += (float)0.025;
            if (powerMask.fillAmount >= 1) isFilling = false;
        }
        else if (!isFilling && !isStopped)
        {
            powerMask.fillAmount -= (float)0.025;
            if (powerMask.fillAmount <= 0) isFilling = true;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_UIManager.gameplayUI.isActiveAndEnabled) return; //only want this code to be active while the UI element is active

        if (Input.GetKeyDown(KeyCode.Space) && powerBar.gameObject.activeInHierarchy)
        {
            isStopped = true;
            powerBar.gameObject.SetActive(false); //no longer need the power bar
            gameObject.GetComponent<AccuracyMovement>().enableAccuracy();
        }
    }

    public void enableBar()
    {
        isStopped = false;
        powerBar.gameObject.SetActive(true);
    }
}
