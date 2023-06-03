using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGame : MonoBehaviour
{
    //public int value;
    private float currentCoins;
    [SerializeField] int solarPanelRevenue;
    [SerializeField] int windTurbineRevenue;
    bool check=true;
    [SerializeField] int debugPerSolarPanelValuePref; //da cancellare, serve per far contare dal nostro valore ogni volta che si preme play
    [SerializeField] int debugPerWindTurbineValuePref; //da cancellare, serve per far contare dal nostro valore ogni volta che si preme play

    private void Start()
    {
        PlayerPrefs.SetInt("Forest", 0);
        debugSolarPanel(); //da cancellare, serve per far contare dal nostro valore ogni volta che si preme play
        debugWindTurbine(); //da cancellare, serve per far contare dal nostro valore ogni volta che si preme play

        currentCoins = PlayerPrefs.GetInt("Coins");
        //StartCoroutine(earnSecond());

    }
    private void Update()
    {
        currentCoins = solarPanelRevenue/60f * PlayerPrefs.GetInt("SolarPanel")+ windTurbineRevenue / 60f * PlayerPrefs.GetInt("WindTurbine");
        Debug.Log("Solar Panel number " + PlayerPrefs.GetInt("SolarPanel"));
        Debug.Log("WindTurbine number  " + PlayerPrefs.GetInt("WindTurbine"));
        if (!PlayerPrefs.HasKey("Forest"))
        {
            PlayerPrefs.SetInt("Forest", 0);
        }
        else if (PlayerPrefs.GetInt("Forest") > 0)
        {
            string tagName = "ForestWall";
            GameObject[] wall = GameObject.FindGameObjectsWithTag(tagName);
            foreach (GameObject obj in wall)
            {
                Destroy(obj);
            }
        }
        if (!PlayerPrefs.HasKey("Desert"))
        {
            PlayerPrefs.SetInt("Desert", 0);
        }
        else if (PlayerPrefs.GetInt("Desert") > 0)
        {
            string tagName = "DesertWall";
            GameObject[] wall = GameObject.FindGameObjectsWithTag(tagName);
            foreach (GameObject obj in wall)
            {
                Destroy(obj);
            }
        }
        if (check)
        {
            StartCoroutine(earnSecond());
        }
    }
    IEnumerator earnSecond()
    {
        check = false;
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetFloat("Coins", currentCoins);
        Debug.Log("sto guadagnando"+ currentCoins);
        CoinsCounter.instance.increaseCoins(currentCoins);
        check = true;

    }
    
    void debugSolarPanel() //da cancellare, serve per far contare dal nostro valore ogni volta che si preme play
    {
        PlayerPrefs.SetInt("SolarPanel", debugPerSolarPanelValuePref);
    }
    void debugWindTurbine() //da cancellare, serve per far contare dal nostro valore ogni volta che si preme play
    {
        PlayerPrefs.SetInt("WindTurbine", debugPerWindTurbineValuePref);
    }
}
