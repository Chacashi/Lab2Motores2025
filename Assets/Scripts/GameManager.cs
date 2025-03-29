using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField] private playerController player;
    [SerializeField] private enemysController enemy;

  
    private void Start()
    {
        
    }

    private void Update()
    {
        if (player.GetReceiveDamage())
        {
            player.SetLife(player.AddLife(enemy.GetDamage()));
            player.SetReceiveDamage(false);
        }
    }

   
    

    

 
}
