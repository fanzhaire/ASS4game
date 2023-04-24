using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WToBC : MonoBehaviour
{
    private bool isWhite = false; // Set initial color to black
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private Renderer controlledObjectRenderer;
    private Collider2D controlledObjectCollider;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        controlledObjectRenderer = this.GetComponent<Renderer>();
        controlledObjectCollider = this.GetComponent<Collider2D>();
        controlledObjectRenderer.enabled = false;
        controlledObjectCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    // Toggle color between black and white
        //    isWhite = !isWhite;
        //    if (isWhite)
        //    {
        //        spriteRenderer.color = Color.white;
        //    }
        //    else
        //    {
        //        spriteRenderer.color = Color.black;
        //    }
        //}
    }
    public void ChangeHideAndShow()
    {
        controlledObjectRenderer.enabled = !controlledObjectRenderer.enabled;
        controlledObjectCollider.enabled = !controlledObjectCollider.enabled;
    }
}
