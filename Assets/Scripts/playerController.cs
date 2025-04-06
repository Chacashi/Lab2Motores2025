using System;
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

    public int CurrentLife => currentLife;
    public int MaxLife => maxLife;  

    [Header("System Receive Damage")]
    [SerializeField] private bool canChangueColor;
    [SerializeField] private int enemieCollisionCount =0;

    public bool CanChangueColor => canChangueColor;


    [Header("Sprite")]
    SpriteRenderer _compSpriteRenderer;

    [Header("Points")]
    [SerializeField] private int currentPointsPlayer;
    public int CurrentPointsPlayer => currentPointsPlayer;

    public static event Action OnPlayerDeath;
    public static event Action OnPlayerTakeTrush;
    public static event Action OnPlayerAddPointsCoin;
    public static event Action<int> OnPlayerReceiveDamage;
    public static event Action<int> OnPlayerTakeCoin;
    public static event Action<int> OnPlayerTakeHeart;

    private void Awake()
    {
        _compRigidbody2d = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
       SetLife(maxLife);
        canChangueColor = true;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        CheckDirectionSprite(horizontal);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }

        if (currentLife <= 0)
        {
            OnPlayerDeath?.Invoke();
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
            enemieCollisionCount++;
            canChangueColor = false;

            if (this.gameObject.layer != collision.gameObject.layer)
            {
                
                OnPlayerReceiveDamage?.Invoke(collision.gameObject.GetComponent<EnemyController>().Damage);
            }
            
        }

        if(collision.gameObject.tag == "tacho")
        {
            OnPlayerTakeTrush?.Invoke();
        }


        if(collision.gameObject.tag == "dead")
        {
            OnPlayerDeath?.Invoke(); 
        }

        if(collision.gameObject.tag == "coin")
        {
            OnPlayerTakeCoin?.Invoke(collision.gameObject.GetComponent<ItemController>().Points);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "heart")
        {
            OnPlayerTakeHeart?.Invoke(collision.gameObject.GetComponent<ItemController>().Points);
            Destroy(collision.gameObject);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Obstacle"))
        {
            enemieCollisionCount = Mathf.Max(0, enemieCollisionCount-1);
            if(enemieCollisionCount==0)
            {
                canChangueColor = true;
            }
            

        }
    }

    private void OnEnable()
    {
        OnPlayerReceiveDamage += AddLife;
        OnPlayerTakeCoin += AddPoints;
        OnPlayerTakeHeart += AddLife;
        
    }

    private void OnDisable()
    {
        OnPlayerReceiveDamage -= AddLife;
        OnPlayerTakeCoin -= AddPoints;
        OnPlayerTakeHeart -= AddLife;
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


    public void SetLife(int maxLife)
    {
        currentLife = maxLife;
    }

    public void AddLife(int pointLife)
    {

        currentLife = Mathf.Clamp(currentLife + pointLife, 0,maxLife);
        
    }

    public void AddPoints(int points)
    {
        currentPointsPlayer += points;
        OnPlayerAddPointsCoin?.Invoke();
    }





   

}
