using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrOver : MonoBehaviour
{
    private bool isActive;
    public Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //// <summary>
    ///  ‰”Æ≈–∂œ
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GameOver")
        {
            Die();
            MainUIManagerC.Instance.ShowGamePanel(false);
        }
        if (collision.gameObject.tag == "Win")
        {
            MainUIManagerC.Instance.ShowGamePanel(true);
            isActive = false;
        }
    }
    /// <summary>
    ///  ß∞‹
    /// </summary>
    public void Die()
    {
        isActive = false;
        rb.isKinematic = true;
        rb.simulated = false;
    }
}
