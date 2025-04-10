using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

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

    [Header("Changue Color")]
    [SerializeField] private Color[] arrayColors = new Color[3];
    [SerializeField] private int currentColorPosition = 0;
    private int currentLayer = 7;
    private float directionColor;

    
    [Header("Sprite")]
    private SpriteRenderer _compSpriteRenderer;

    [Header("Points")]
    [SerializeField] private int currentPointsPlayer;
    public int CurrentPointsPlayer => currentPointsPlayer;

    public static event Action OnPlayerDeath;
    public static event Action OnPlayerTakeTrush;
    public static event Action OnPlayerReceiveDamage;
    public static event Action OnPlayerTakeCoin;
    public static event Action OnPlayerTakeHeart;
    public static event Action<int> OnColorLayerChangue;

    private void Awake()
    {
        _compRigidbody2d = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
       SetLife(maxLife);
        canChangueColor = true;

        _compSpriteRenderer.color = arrayColors[currentColorPosition];
        this.gameObject.layer = currentLayer;
        OnColorLayerChangue?.Invoke(currentLayer);
    }

    private void Update()
    {
       
      

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


        
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<float>();
        CheckDirectionSprite(horizontal);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
      
        if(context.phase != InputActionPhase.Performed ) return;
        canJump = true;
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
                isDoubleJump = false;
                canJump = false;
            }
        }
    }

    public void OnChangueColor(InputAction.CallbackContext context)
    {
        if(!canChangueColor) return;
        if(context.phase != InputActionPhase.Performed) return;
        directionColor = context.ReadValue<float>();
        if (directionColor > 0)
        {
            currentColorPosition++;
            currentLayer++;
           
            if (currentColorPosition >= arrayColors.Length)
            {
                currentColorPosition = 0;
                currentLayer = 7;
                _compSpriteRenderer.color = arrayColors[currentColorPosition];
                this.gameObject.layer = currentLayer;
                OnColorLayerChangue?.Invoke(currentLayer);

            }
            else
            {
                _compSpriteRenderer.color = arrayColors[currentColorPosition];
                this.gameObject.layer = currentLayer;
                OnColorLayerChangue?.Invoke(currentLayer);
            }
            
        }
        if(directionColor < 0)
        {
            currentColorPosition--;
            currentLayer--;
            
            if (currentColorPosition < 0)
            {
                currentColorPosition = arrayColors.Length-1;
                currentLayer = 9;
                _compSpriteRenderer.color = arrayColors[currentColorPosition];
                this.gameObject.layer = currentLayer;
                OnColorLayerChangue?.Invoke(currentLayer);

            }
            else
            {
                _compSpriteRenderer.color = arrayColors[currentColorPosition];
                this.gameObject.layer = currentLayer;
                OnColorLayerChangue?.Invoke(currentLayer);
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
                AddLife(collision.gameObject.GetComponent<EnemyController>().Damage);   
                OnPlayerReceiveDamage?.Invoke();
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
            AddPoints(collision.gameObject.GetComponent<ItemController>().Points);
            OnPlayerTakeCoin?.Invoke();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "heart")
        {
            AddLife(collision.gameObject.GetComponent<ItemController>().Points);
            OnPlayerTakeHeart?.Invoke();
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
        
    }





   

}
