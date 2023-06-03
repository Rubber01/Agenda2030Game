using UnityEngine;
using UnityEngine.SceneManagement;
public class ShopGenerator : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab)&& SceneManager.sceneCount<2)
        {
            SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
        }
    }
}
