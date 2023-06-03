using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    private void Update()
    {
        string tagName = "Player";
        GameObject[] player = GameObject.FindGameObjectsWithTag(tagName);
        target = player[0].transform;
        transform.position = new Vector3(target.position.x, target.position.y+3, transform.position.z);
    }
}
