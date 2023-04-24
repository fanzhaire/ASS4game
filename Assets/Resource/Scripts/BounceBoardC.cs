using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBoardC : MonoBehaviour
{
    public float bouncePower = 10f;
    public float targetAngle = 45f;
    public LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsPlayer(other))
        {
            BouncePlayer(other);
        }
    }

    private bool IsPlayer(Collider2D other)
    {
        return ((1 << other.gameObject.layer) & playerLayer) != 0;
    }

    private void BouncePlayer(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 bounceDirection = Quaternion.Euler(0, 0, targetAngle) * Vector2.right;
            rb.velocity = bounceDirection * bouncePower;
        }
    }
}
