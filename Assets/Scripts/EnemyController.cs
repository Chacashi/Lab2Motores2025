using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 abstract public  class EnemyController : MonoBehaviour
{
    [Header("Atributtes")]
    [SerializeField] protected int damage;

     public  int Damage => damage * -1;
    


}
