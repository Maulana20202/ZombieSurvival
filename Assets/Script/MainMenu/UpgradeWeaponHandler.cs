using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeWeaponHandler : MonoBehaviour
{

    public GameObject[] weapon;

    public int[] weaponPrice;

    public Button[] weaponButton;

    public GameObject BuyButton;

    public GameObject UseButton;

    public GameObject Selected;

    public int weaponPriceSelected;

    public int indexSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeWeapon(int index)
    {
        foreach(GameObject item in weapon)
        {
            item.SetActive(false);
        }

        weapon[index].SetActive(true);

        weaponPriceSelected = weaponPrice[index];

        foreach(Button button in weaponButton)
        {
            button.interactable = true;
        }

        weaponButton[index].interactable = false;

        indexSelected = index;

        if (!CoinManager.Instance.weaponUnlock[index])
        {
            BuyButton.SetActive(true);
            BuyButton.transform.Find("Price").GetComponent<TextMeshProUGUI>().text = weaponPriceSelected.ToString();
            UseButton.SetActive(false);
            Selected.SetActive(false);

        } else
        {
            BuyButton.SetActive(false);
            UseButton.SetActive(true);
            Selected.SetActive(false);
        }

        if(CoinManager.Instance.CurrentSelectedWeapon == index)
        {
            BuyButton.SetActive(false);
            UseButton.SetActive(false);
            Selected.SetActive(true);
        }
    }

    public void BuyWeapon()
    {
        if (CoinManager.Instance.Coin >= weaponPriceSelected)
        {
            CoinManager.Instance.Coin -= weaponPriceSelected;
            CoinManager.Instance.weaponUnlock[indexSelected] = true;
            CoinManager.Instance.CurrentSelectedWeapon = indexSelected;

            BuyButton.SetActive(false);
            UseButton.SetActive(false);
            Selected.SetActive(true);
        }
       
    }

    public void SelectWeapon()
    {
        CoinManager.Instance.CurrentSelectedWeapon = indexSelected;

        BuyButton.SetActive(false);
        UseButton.SetActive(false);
        Selected.SetActive(true);
    }
}
