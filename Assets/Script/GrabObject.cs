using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GrabObject : MonoBehaviour
{
    public GameObject characterPrefab;  // Prefab del personaggio
    public LayerMask objectLayer;  // Layer degli oggetti da controllare
    public Button buttonToToggle;  // Riferimento al pulsante nel Canvas

    private GameObject characterInstance;  // Istanza del personaggio nella scena
    private bool isInRange;  // Flag per tenere traccia se l'oggetto è nel range del personaggio
    private bool attached;
    private GameObject objectTouching; // Oggetto che sta collidendo con il player

    private void Update()
    {
        GameObject character = GameObject.FindWithTag("Player");

        if (character != null)
        {
            // Aggiorna la posizione del cerchio di collisione in base alla posizione del personaggio
            transform.position = character.transform.position;

            // Verifica se ci sono oggetti nel range
            Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, 1f, objectLayer);

            // Controlla se ci sono oggetti nel range
            if (objectsInRange.Length > 0)
            {
                // Salva l'oggetto più vicino al centro del cerchio di collisione come objectTouching
                objectTouching = GetClosestObject(objectsInRange);

                // Se ci sono oggetti nel range, il pulsante diventa visibile se non lo era già
                if (!isInRange||attached==true)
                {
                    isInRange = true;
                    buttonToToggle.gameObject.SetActive(true);
                }
            }
            else
            {
                // Se non ci sono oggetti nel range, il pulsante diventa invisibile se non lo era già
                if (isInRange && attached == false)
                {
                    isInRange = false;
                    buttonToToggle.gameObject.SetActive(false);
                }

                objectTouching = null; // Resetta la variabile objectTouching se non ci sono oggetti nel range
            }
        }
    }

    private GameObject GetClosestObject(Collider2D[] colliders)
    {
        GameObject closestObject = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {
            float distance = Vector2.Distance(transform.position, collider.transform.position);
            if (distance < closestDistance)
            {
                closestObject = collider.gameObject;
                closestDistance = distance;
            }
        }

        return closestObject;
    }

    private void OnDrawGizmosSelected()
    {
        // Disegna una sfera nel raggio di controllo per visualizzarlo nell'editor di Unity
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
    public void AttachObjectToParent()
    {
        if (attached == false)
        {
            attached = true;
            GameObject character = GameObject.FindWithTag("Player");

            objectTouching.transform.SetParent(character.transform, false);
            objectTouching.transform.localPosition = new Vector3(1, 0, 0);
            objectTouching.transform.localRotation = Quaternion.identity;
            objectTouching.GetComponent<Rigidbody2D>().simulated = false;
        }
        else
        {
            GameObject character = GameObject.FindWithTag("Player");
            attached = false;
            character.transform.DetachChildren();
            objectTouching.GetComponent<Rigidbody2D>().simulated = true;
            StartCoroutine(waitFall(objectTouching));
        }
    }
    private IEnumerator waitFall(GameObject objectTouching)
    {
        yield return new WaitForSeconds(5f);
        
        objectTouching.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        objectTouching.GetComponent<Collider2D>().enabled = false;
    }
}
