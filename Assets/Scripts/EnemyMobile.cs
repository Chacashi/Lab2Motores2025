using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyMobile : EnemyController
{
    [Header("Movement")]
    [SerializeField] protected float speed;
   protected Rigidbody2D _compRigidbody2d;
    

    protected virtual void Awake()
    {
        _compRigidbody2d = GetComponent<Rigidbody2D>();
    }


    protected abstract void FixedUpdate();
    

   
}
