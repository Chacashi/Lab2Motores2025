using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public  class EnemyController : MonoBehaviour
{
    [Header("Atributtes")]
    [SerializeField] private int damage;

    public int Damage => damage * -1;
    
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float directionX;
    Rigidbody2D _compRigidbody2d;

    

    [Header("Raycast")]
    [SerializeField] private Transform objectDirection;
    [SerializeField] private float distanceRay;
    [SerializeField] private LayerMask layerRay;
    [SerializeField] private Color collision;
    [SerializeField] private Color notCollision;
    RaycastHit2D hit;

    private void Awake()
    {
        _compRigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        directionX = 1;
        
    }
    private void FixedUpdate()
    {

        _compRigidbody2d.velocity = new Vector2(directionX*speed, _compRigidbody2d.velocity.y);

        
        hit = Physics2D.Raycast(objectDirection.position, Vector2.down, distanceRay, layerRay);
        if (hit.collider !=null)
        {
            Debug.DrawRay(objectDirection.position, hit.distance * Vector2.down, collision);
        }
        else
        {
            Debug.DrawRay(objectDirection.position, distanceRay * Vector2.down, notCollision);
            directionX *= -1;
            transform.eulerAngles = new Vector3(0 , transform.eulerAngles.y+ 180,0);
            
        }


    }




}
