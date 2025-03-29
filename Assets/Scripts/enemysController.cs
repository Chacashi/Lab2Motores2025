using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysController : MonoBehaviour
{
    [Header("Atributtes")]
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float directionX;

    public int Damage => damage * -1;
    
    [Header("Others")]
    Rigidbody2D _compRigidbody2d;

    private void Awake()
    {
        _compRigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        _compRigidbody2d.velocity = new Vector2(directionX, _compRigidbody2d.velocity.y);
    }




}
