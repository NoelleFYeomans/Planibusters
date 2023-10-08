using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Canvas ShopUI;

    public GameObject singleStrikeUI;
    public GameObject rapidStrikeUI;
    public GameObject kickUI;

    // Start is called before the first frame update
    void Start()
    {
        //make the first upgrade menu visisble/select style visible
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dropdown(int index)
    {
        switch (index)
        {
            case 0:
                singleUpgradeActive();
                break;
            case 1:
                rapidUpgradeActive();
                break;
            case 2:
                kickUpgradeActive();
                break;
        }
    }

    //public void OnPointerEnter(EventSystems.PointerEventData eventData) //this is awesome!
    //{
    //    childText.SetActive(true);
    //}
    //public void OnPointerExit(EventSystems.PointerEventData eventData)
    //{
    //    childText.SetActive(false);
    //}

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
