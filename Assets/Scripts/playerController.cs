using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    private float horizontal;
    Rigidbody2D _compRigidbody2d;

    [Header("RaycastJump")]
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask rayLayer;
    [SerializeField] private Transform origin;
    [SerializeField] private Color collision;
    [SerializeField] private Color notCollision;
    RaycastHit2D hit;

    [Header ("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool canJump;
    [SerializeField] private bool isDoubleJump;
    [SerializeField] private bool isJump;

    private void Awake()
    {
        _compRigidbody2d = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }
    }

    private void FixedUpdate()
    {
        _compRigidbody2d.velocity = new Vector2(horizontal* speed, _compRigidbody2d.velocity.y);



        hit = Physics2D.Raycast(origin.position, Vector2.down, rayDistance, rayLayer);

        if(hit.collider != null)
        {
            Debug.DrawRay(origin.position, Vector2.down * hit.distance, collision);
            isJump = true;
            isDoubleJump = true;
        }
        else
        {
            
            Debug.DrawRay(origin.position, Vector2.down * rayDistance, notCollision);
            isJump = false;
            
        }


        if (canJump)
        {
            if (isJump)
            {
                _compRigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;
            }
            else if (isDoubleJump)
            {
                _compRigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isDoubleJump= false;
            }
        }

        



       
    }

}
