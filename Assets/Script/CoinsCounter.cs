using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinsCounter : MonoBehaviour
{
    public static CoinsCounter instance;
    public TMP_Text coinText;
    public float currentCoins;
    [SerializeField] int debugForCoinValue; //da cancellare, serve per far contare da 0 ogni volta che si preme play
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        debugCoin(); //da cancellare, serve per far contare da 0 ogni volta che si preme play
        if (PlayerPrefs.HasKey("Coins"))
        {
            currentCoins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            PlayerPrefs.SetInt("Coins", 0);

        }
        coinText.text = currentCoins.ToString() + "$";


    }
    public void increaseCoins(float v)
    {
        currentCoins += v;
        PlayerPrefs.SetFloat("Coins", currentCoins);

        coinText.text = currentCoins.ToString() + "$";
    }
    public void decreaseCoins(float v)
    {
        currentCoins -= v;
        PlayerPrefs.SetFloat("Coins", currentCoins);

        coinText.text = currentCoins.ToString() + "$";
    }
    void debugCoin()//da cancellare, serve per far contare da 0 ogni volta che si preme play
    {
        PlayerPrefs.SetInt("Coins", debugForCoinValue);
    }
}
