using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItemCounter : MonoBehaviour
{
    [SerializeField] string nome;
    public void unloadShop()
    {
        SceneManager.UnloadSceneAsync("Shop");
    }
    public void itemValueSpawner()
    {
        if (!PlayerPrefs.HasKey(nome))
        {
            PlayerPrefs.SetInt(nome, 0);
        }
        PlayerPrefs.SetInt(nome, PlayerPrefs.GetInt(nome) + 1);
    }
    public void zone()
    {
        if (!PlayerPrefs.HasKey(nome))
        {
            PlayerPrefs.SetInt(nome, 0);
        }
        PlayerPrefs.SetInt(nome, PlayerPrefs.GetInt(nome) + 1);
    }
    public void desert()
    {
        if (!PlayerPrefs.HasKey("Desert"))
        {
            PlayerPrefs.SetInt("Desert", 0);
        }
        PlayerPrefs.SetInt("Desert", PlayerPrefs.GetInt("Desert") + 1);
    }
    public void forest()
    {
        if (!PlayerPrefs.HasKey("Forest"))
        {
            PlayerPrefs.SetInt("Forest", 0);
        }
        PlayerPrefs.SetInt("Forest", PlayerPrefs.GetInt("Forest") + 1);
    }
    public void solarPanel()
    {
        if (!PlayerPrefs.HasKey("SolarPanel"))
        {
            PlayerPrefs.SetInt("SolarPanel", 0);
        }
        PlayerPrefs.SetInt("SolarPanel", PlayerPrefs.GetInt("SolarPanel") + 1);
    }
    public void windTurbine()
    {
        if (!PlayerPrefs.HasKey("WindTurbine"))
        {
            PlayerPrefs.SetInt("WindTurbine", 0);
        }
        PlayerPrefs.SetInt("WindTurbine", PlayerPrefs.GetInt("WindTurbine") + 1);
    }
}
