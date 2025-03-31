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


    [Header("Life")]
    
    [SerializeField] private int currentLife;
    [SerializeField] private int maxLife;
    [SerializeField] private bool isDead;

    public bool Isdead => isDead;

    public int CurrentLife => currentLife;

    [Header("System Receive Damage")]
    [SerializeField] private bool isReceiveDamage;
    [SerializeField] private bool isTakeEnemy;
    private GameObject enemy;

    public bool IsReceiveDamage => isReceiveDamage;
    public bool IsTakeEnemy => isTakeEnemy;


    [Header("Sprite")]
    SpriteRenderer _compSpriteRenderer;

    [Header("State Game")]
    [SerializeField] private bool isTakeTacho;
    public bool IsTakeTacho => isTakeTacho;
    private void Awake()
    {
        _compRigidbody2d = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetLife(maxLife);
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        CheckDirectionSprite(horizontal);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }
    }

    private void FixedUpdate()
    {
        _compRigidbody2d.linearVelocity = new Vector2(horizontal* speed, _compRigidbody2d.linearVelocity.y);



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
                canJump = false ;
            }
        } 
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Obstacle"))
        {
            isTakeEnemy = true;
            if (this.gameObject.layer != collision.gameObject.layer)
            {
                isReceiveDamage = true;
                enemy = collision.gameObject;
            }
            
        }

        if(collision.gameObject.tag == "tacho")
        {
            isTakeTacho = true;
        }


        if(collision.gameObject.tag == "dead")
        {
            isDead = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Obstacle"))
        {
            isTakeEnemy = false;

        }
    }


    void CheckDirectionSprite( float horizontal)
    {
        if(horizontal != -1)
        {
            _compSpriteRenderer.flipX = false;
        }
        else
        {
            _compSpriteRenderer.flipX = true;
        }
    }

    public void SetReceiveDamage(bool statusReceiveDamage)
    {
        isReceiveDamage =statusReceiveDamage;
    }

    public void SetLife(int maxLife)
    {
        currentLife = maxLife;
    }

    public int AddLife(int pointLife)
    {
        currentLife += pointLife;
        return currentLife;
    }

    public int GetDamageEnemy()
    {
       return enemy.GetComponent<EnemyController>().Damage;
    }




   

}
