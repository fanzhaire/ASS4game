using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionDetector : MonoBehaviour
{   
    private SpriteRenderer spriteRenderer;
    private PlayerController1 playerController;
    //小球接触地面判断
    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer=GetComponent<SpriteRenderer>(); 
        playerController = FindObjectOfType<PlayerController1>();
        if (collision.gameObject.CompareTag("SPGround"))
        {
            TriggerEffect();
        }
        
    }
    //小球停留地面判断
    private void OnCollisionStay2D(Collision2D collision)
    {
        spriteRenderer=GetComponent<SpriteRenderer>(); 
        playerController = FindObjectOfType<PlayerController1>();
        if (collision.gameObject.CompareTag("SPGround"))
        {
            TriggerEffect();
        }
        
    }

    //小球不同颜色碰到地面会加速或者减速
    private void TriggerEffect()
    {
        if(playerController.Switched == true){
            playerController.moveSpeed = 10f;
            playerController.jumpForce = 6f;
        }else if(playerController.Switched == false){
            playerController.moveSpeed = 3f;
            playerController.jumpForce = 12f;
        }
        Debug.Log("Speed and jump change");
    }
}
