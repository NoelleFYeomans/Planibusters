using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public Canvas ShopUI;

    public GameObject singleStrikeUI;
    public GameObject rapidStrikeUI;
    public GameObject kickUI;

    public int singlePower = 1, singleAccuracy = 1, singleBalance = 1, singleUnique = 1; //implemented
    public int rapidPower = 1, rapidAccuracy = 1, rapidBalance = 1, rapidUnique = 1; //might be removed
    public int kickPower = 1, kickAccuracy = 1, kickBalance = 1, kickUnique = 1;

    enum Style
    {
        Single,
        Rapid,
        Kick
    }

    private Style currentStyle = Style.Single; //this also needs to be saved


    // Start is called before the first frame update
    void Start()
    {
        //read data from SaveManager

        //make the first upgrade menu visisble/select style visible
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendDataToManager() //sends all relevent shop data to the SaveManager(data manager)
    {
        //single data
        SaveManager.Instance.singlePower = singlePower;
        SaveManager.Instance.singleAccuracy = singleAccuracy;
        SaveManager.Instance.singleBalance = singleBalance;
        SaveManager.Instance.singleUnique = singleUnique;
        //rapid data
        SaveManager.Instance.rapidPower = rapidPower;
        SaveManager.Instance.rapidAccuracy = rapidAccuracy;
        SaveManager.Instance.rapidBalance = rapidBalance;
        SaveManager.Instance.rapidUnique = rapidUnique;
        //kick data
        SaveManager.Instance.kickPower = kickPower;
        SaveManager.Instance.kickAccuracy = kickAccuracy;
        SaveManager.Instance.kickBalance = kickBalance;
        SaveManager.Instance.kickUnique = kickUnique;

        //other data
        //style (could be an int?)
    }


    public void Dropdown(int index)
    {
        switch (index)
        {
            case 0:
                singleUpgradeActive();
                currentStyle = Style.Single;
                break;
            case 1:
                rapidUpgradeActive();
                currentStyle = Style.Rapid;
                break;
            case 2:
                kickUpgradeActive();
                currentStyle = Style.Kick;
                break;
        }
    }

    public void upgradePower() //used for all 3 styles
    {
        switch (currentStyle)
        {
            case Style.Single:
                singlePower++; //tentative
                break;
            case Style.Rapid:

                break;
            case Style.Kick:

                break;
        }
    }

    public void upgradeAccuracy() //used for all 3 styles
    {
        switch (currentStyle)
        {
            case Style.Single:

                break;
            case Style.Rapid:

                break;
            case Style.Kick:

                break;
        }
    }

    public void upgradeBalance() //used for all 3 styles
    {
        switch (currentStyle)
        {
            case Style.Single:

                break;
            case Style.Rapid:

                break;
            case Style.Kick:

                break;
        }
    }

    //public void OnPointerEnter(EventSystems.PointerEventData eventData) //this is awesome!
    //{
    //    //childText.SetActive(true);
    //}
    //public void OnPointerExit(EventSystems.PointerEventData eventData)
    //{
    //    //childText.SetActive(false);
    //}


    //coulds be refactored into UIManager
    public void singleUpgradeActive()
    {
        singleStrikeUI.SetActive(true);
        rapidStrikeUI.SetActive(false);
        kickUI.SetActive(false);
    }

    public void rapidUpgradeActive()
    {
        singleStrikeUI.SetActive(false);
        rapidStrikeUI.SetActive(true);
        kickUI.SetActive(false);
    }

    public void kickUpgradeActive()
    {
        singleStrikeUI.SetActive(false);
        rapidStrikeUI.SetActive(false);
        kickUI.SetActive(true);
    }
}
