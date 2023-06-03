using UnityEngine;

public class RangeDetection : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private void Update()
    {
        Vector3 center = new Vector3(0, 0, 0);
        float distance = Vector3.Distance(Player.transform.position, center);

        if (distance >= 0 && distance <= 0.5f)
        {
            Debug.Log("Dentro al range");
        }
    }
}