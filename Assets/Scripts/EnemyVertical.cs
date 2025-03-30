using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyVertical : EnemyMobile
{
    protected override void FixedUpdate()
    {
   
      _compRigidbody2d.linearVelocity = new Vector2(_compRigidbody2d.linearVelocity.x, speed);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            speed *= -1;
        }
    }
}
