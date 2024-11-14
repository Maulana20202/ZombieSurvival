using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public TextMeshProUGUI TotalCoinText;

    public GameObject MainMenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        TotalCoinText.text = "Total Coin : " + CoinManager.Instance.Coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false );
        MainMenuPanel.SetActive(true);
    }
}
