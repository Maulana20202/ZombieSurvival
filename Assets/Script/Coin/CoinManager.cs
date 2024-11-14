using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private static CoinManager _instance;

    public static CoinManager Instance {  get { return _instance; } }

    public  int Coin;

    public int CoinCurrent;

    public int CurrentSelectedWeapon;

    public  TextMeshProUGUI CoinText;

    public  TextMeshProUGUI TotalCoinText;

    public bool[] weaponUnlock;
    // Start is called before the first frame update
    void Awake()
    {
        if(_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(this.gameObject);

        } else
        {
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
       
    }


    public void CoinPlus()
    {
        CoinCurrent++;
        CoinText.text = "Coin : " + CoinCurrent.ToString();
    }

    public  void CoinGameOver()
    {
        Coin += CoinCurrent;

        CoinCurrent = 0;

    }

    public void CoinStart()
    {
        TotalCoinText.text = "Total Coin : " + Coin.ToString();
    }

    
}
