using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerColor : MonoBehaviour
{
    //-----
    /// <summary>
    /// ��ת�ڵذ�ǽ����
    /// </summary>
    public WToBC[] WToBs;
    /// <summary>
    /// ��ת�׵ذ�ǽ����
    /// </summary>
    public BToWC[] BToWs;
    /// <summary>
    /// �Ƿ񼤻������
    /// </summary>
    public bool isActive = true;
    /// <summary>
    /// �ذ�ǽ��ɫ_1
    /// </summary>
    public Color32 changeColor_2;
    /// <summary>
    /// �ذ�ǽ��ɫ_2
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
    /// �޸�С���Լ��ذ�ǽ��ɫ
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
