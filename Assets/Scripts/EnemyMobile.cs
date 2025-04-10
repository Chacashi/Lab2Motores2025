using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyMobile : EnemyController
{
    [Header("Movement")]
    [SerializeField] protected float speed;
     protected float LastSpeed;
    protected Rigidbody2D _compRigidbody2d;
    

    protected virtual void Awake()
    {
        _compRigidbody2d = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        LastSpeed = speed;
    }

  

    protected abstract void FixedUpdate();

    private void OnEnable()
    {
        playerController.OnColorLayerChangue += StopMovement;
    }

    private void OnDisable()
    {
        playerController.OnColorLayerChangue -= StopMovement;
    }

    protected void StopMovement(int layer)
    {

        if (layer == this.gameObject.layer)
            speed = 0f;
        else
        {
            speed = LastSpeed;
        }
    }
}
