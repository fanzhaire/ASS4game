using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEnableCheckBlack : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private PlayerController1 playerController;
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>(); 
        Collider2D collider2D = GetComponent<Collider2D>();
        playerController = FindObjectOfType<PlayerController1>();
    }

    // Update is called once per frame
    void Update()
    {
    
    if(spriteRenderer != null && playerController != null){
        if(playerController.Switched == true){
             GetComponent<Collider2D>().enabled = true;
             spriteRenderer.enabled = true;
        }else{
           GetComponent<Collider2D>().enabled = false;
           spriteRenderer.enabled = false; 
        }
    }
    }
    
}
