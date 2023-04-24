using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
/// <summary>
/// UI����ű�
/// </summary>
public class MainUIManagerC : MonoBehaviour
{
    /// <summary>
    /// ����
    /// </summary>
    public static MainUIManagerC Instance;
    /// <summary>
    /// �̳�ҳ��
    /// </summary>
    public Transform tutorialPanel;
    /// <summary>
    /// ��ʱ
    /// </summary>
    public Text timeTxt;
    /// <summary>
    /// ��Ϸ����ҳ��
    /// </summary>
    public Transform gameOverPanel;
    /// <summary>
    /// �˳���ť
    /// </summary>
    public Button exitBtn;
    /// <summary>
    /// ���水ť
    /// </summary>
    public Button restartBtn;
    /// <summary>
    /// ���ؽ̳�ҳ���ʱ��
    /// </summary>
    public float hideTutorialTime;
    /// <summary>
    /// ��ʱ-��
    /// </summary>
    private int second;
    /// <summary>
    /// ��ʱ-��
    /// </summary>
    private int min;
    /// <summary>
    /// �Ƿ�ʼ/������ʱ
    /// </summary>
    private bool isCutTime=true;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        exitBtn.onClick.AddListener(ExitGame);
        restartBtn.onClick.AddListener(RestartGame);
        Invoke("HideTutorial", hideTutorialTime);
        StartCoroutine(Timer());
    }
    /// <summary>
    /// ��Ӯ������ʾ
    /// </summary>
    /// <param name="isWin"></param>
    public void ShowGamePanel(bool isWin)
    {
        if (isWin)
        {
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = "You Win";
        }
        else
        {
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Game Over";
           
        }
        //ֹͣ��ʱ
        isCutTime = false;
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 1;
        gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameOverPanel.GetComponent<CanvasGroup>().interactable = true;
    }

    /// <summary>
    /// �˳���Ϸ
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// ����
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
    /// <summary>
    /// ���ؽ̳�ҳ��
    /// </summary>
    public void HideTutorial()
    {
        tutorialPanel.gameObject.SetActive(false);
    }
    /// <summary>
    /// ��ʱЭ��
    /// </summary>
    /// <returns></returns>
    IEnumerator Timer()
    {
        while (isCutTime)
        {
            yield return new WaitForSeconds(1.0f);
            second++;
            if (second >= 60)
            {
                second = 0;
                min++;
            }
            timeTxt.text = min + ":M-" + second + ":S";
        }
    }
}
