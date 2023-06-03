using UnityEngine;

public class AttachObject : MonoBehaviour
{
    public GameObject objectToAttach; // Oggetto da attaccare
    private void AttachObjectToParent()
    {
        GameObject attachPoint = GameObject.FindWithTag("Player");

        objectToAttach.transform.SetParent(attachPoint.transform, false);
            objectToAttach.transform.localPosition = Vector3.zero;
            objectToAttach.transform.localRotation = Quaternion.identity;
            objectToAttach.GetComponent<Rigidbody2D>().simulated = false;

    }
}