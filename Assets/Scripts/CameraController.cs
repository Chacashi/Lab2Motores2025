using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 targetPos;
    [SerializeField] private float fowards;

    private void FixedUpdate()
    {
        targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

        if (target.transform.localScale.x == 1)
        {
            targetPos = new Vector3(targetPos.x + fowards, targetPos.y, transform.position.z);
        }

        if (target.transform.localScale.x == -1)
        {
            targetPos = new Vector3(targetPos.x - fowards, targetPos.y, transform.position.z);
        }

        transform.position = targetPos;
    }
}
