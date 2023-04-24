using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BToWFAN : MonoBehaviour
{
    private bool isWhite = false; // Set initial color to black
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Toggle color between black and white
            isWhite = !isWhite;
            if (isWhite)
            {
                spriteRenderer.color = Color.white;
            }
            else
            {
                spriteRenderer.color = Color.black;
            }
        }
    }
}
