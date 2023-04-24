
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerSize : MonoBehaviour
{
    private bool isChangeSizeSmall;
    private bool isChangeSizeBig;
    public int jumpForce;
    private Rigidbody2D rb;
    private bool isGrounded;
    public float checkRadius=0.5f;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, checkRadius, groundLayer);
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
          if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleSizeBig();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ToggleSizeSmall();
        }
    }
    /// <summary>
    /// 放大小球
    /// </summary>
    private void ToggleSizeBig()
    {
        //再次按下则恢复为正常大小
        if (isChangeSizeBig)
        {
            ToggleSizeNormal();
            isChangeSizeBig = false;
            isChangeSizeSmall = false;
        }
        else
        {
            isChangeSizeBig = true;
            isChangeSizeSmall = false;
           
            jumpForce = 10;
            // moveSpeed = 2;
        }
    }
    /// <summary>
    /// 缩小小球
    /// </summary>
    private void ToggleSizeSmall()
    {
        //再次按下则恢复为正常大小
        if (isChangeSizeSmall)
        {
            ToggleSizeNormal();
            isChangeSizeSmall = false;
            isChangeSizeBig = false;
        }
        else
        {
            isChangeSizeBig = false;
            isChangeSizeSmall = true;
           
            jumpForce = 2;
        }
        // moveSpeed = 7;
    }
    /// <summary>
    /// 切换为正常大小
    /// </summary>
    private void ToggleSizeNormal()
    {
       
        jumpForce = 7;
        //  moveSpeed = 5;
    }
}
