using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float fowards = 1.0f;

    private void FixedUpdate()
    {
        if (target == null) return; 

      
        float direction = Mathf.Sign(target.transform.localScale.x);

     
        Vector3 targetPos = new Vector3(
            target.transform.position.x + (fowards * direction),
            target.transform.position.y,
            transform.position.z
        );

   
        transform.position = targetPos;
    }
}
