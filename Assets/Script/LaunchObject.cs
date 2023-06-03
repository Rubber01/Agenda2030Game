using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class LaunchObject : NetworkBehaviour
{
    public GameObject solarPanelPrefab;
    public float launchForce = 10f;
    public float randomXMin = -2f;
    public float randomXMax = 2f;
    public float randomYMin = 0f;
    public float randomYMax = 2f;
    public float randomZ = 0f;
    private float number;
    private float previousNumber;
    private string gameObjectName;
    private void Start()
    {
        gameObjectName = solarPanelPrefab.name;
        number =PlayerPrefs.GetInt(gameObjectName);
        previousNumber = number;
    }

    private void Update()
    {
        number = PlayerPrefs.GetInt(gameObjectName);
        if (number != previousNumber)
        {
            Debug.Log("Il numero è cambiato: " + number);
            previousNumber = number;
            LaunchItem();
        }
    }
    public void LaunchItem()
    {
        Debug.Log("Dentro");
        spawnStuffServerRpc();
        Debug.Log("fuori spawnStuffServerRpc");
        SceneManager.UnloadSceneAsync("Shop");
        Debug.Log("unload Shop");
    }

    [ServerRpc]
    private void spawnStuffServerRpc(){
        Debug.Log("Dentro spawnStuffServerRpc");
        Vector3 launchPosition = transform.position;
        Quaternion launchRotation = Quaternion.identity;

        float randomX = Random.Range(randomXMin, randomXMax);
        float randomY = Random.Range(randomYMin, randomYMax);
        Vector2 launchDirection = new Vector2(randomX, randomY).normalized;
        Debug.Log("pre Instanza");
        GameObject solarPanel = Instantiate(solarPanelPrefab, launchPosition, launchRotation);
        Debug.Log("instanza generata");
        Rigidbody2D solarPanelRb = solarPanel.GetComponent<Rigidbody2D>();

        solarPanelRb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
    }
}
