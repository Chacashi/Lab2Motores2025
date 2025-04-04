using UnityEngine;

public class ItemController : MonoBehaviour
{
    [Header("Atributtes")]
    [SerializeField] private int points;

    public int Points => points;
}
