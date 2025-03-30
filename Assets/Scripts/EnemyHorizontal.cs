using UnityEngine;

public class EnemyHorizontal : EnemyMobile
{
    [Header("Raycast")]
    [SerializeField] private Transform objectDirection;
    [SerializeField] private float distanceRay;
    [SerializeField] private LayerMask layerRay;
    [SerializeField] private Color collision;
    [SerializeField] private Color notCollision;
    RaycastHit2D hit;

    protected override void FixedUpdate()
    {
  
                _compRigidbody2d.linearVelocity = new Vector2(speed, _compRigidbody2d.linearVelocity.y);


                hit = Physics2D.Raycast(objectDirection.position, Vector2.down, distanceRay, layerRay);
                if (hit.collider != null)
                {
                    Debug.DrawRay(objectDirection.position, hit.distance * Vector2.down, collision);
                }
                else
                {
                    Debug.DrawRay(objectDirection.position, distanceRay * Vector2.down, notCollision);
                    speed *= -1;
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

                }
    }
}
