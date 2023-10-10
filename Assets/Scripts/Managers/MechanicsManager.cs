using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicsManager : MonoBehaviour
{
    private ProgressBars _powerBar;
    private BalanceMechs _balance;
    private UniqueMechs _unique;

    public bool powerInputted = false;
    public bool accuracyInputted = false;
    public bool balanceInputted = false;
    public bool uniqueInputted = false;

    // Start is called before the first frame update
    void Start()
    {
        _powerBar = gameObject.GetComponent<ProgressBars>();
        _balance = gameObject.GetComponent<BalanceMechs>();
        _unique = gameObject.GetComponent<UniqueMechs>();

    }

    // Update is called once per frame
    void Update()
    {
        //move control structure for mechanics into THIS code

        if (powerInputted == true && accuracyInputted == true) //&& balanceInputted == false && uniqueInputted == false
        {
            //screenshake then to upgrade screen
            Debug.Log("logma bugs");
        }
    }
}
