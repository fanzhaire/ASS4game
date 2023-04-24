using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerColor : MonoBehaviour
{
    //-----
    /// <summary>
    /// 白转黑地板墙集合
    /// </summary>
    public WToBC[] WToBs;
    /// <summary>
    /// 黑转白地板墙集合
    /// </summary>
    public BToWC[] BToWs;
    /// <summary>
    /// 是否激活可运行
    /// </summary>
    public bool isActive = true;
    /// <summary>
    /// 地板墙颜色_1
    /// </summary>
    public Color32 changeColor_2;
    /// <summary>
    /// 地板墙颜色_2
    /// </summary>
    public Color32 changeColor_1;
    private bool isWhite;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.S))
        {
            ToggleColor();
        }
    }
    /// <summary>
    /// 修改小球以及地板墙颜色
    /// </summary>
    private void ToggleColor()
    {
        if (isWhite)
        {
            spriteRenderer.color = changeColor_2;
            isWhite = false;

        }
        else
        {
            spriteRenderer.color = changeColor_1;
            isWhite = true;

        }
        for (int i = 0; i < WToBs.Length; i++)
        {
            WToBs[i].ChangeHideAndShow();
        }
        for (int i = 0; i < BToWs.Length; i++)
        {
            BToWs[i].ChangeHideAndShow();
        }

    }
}
