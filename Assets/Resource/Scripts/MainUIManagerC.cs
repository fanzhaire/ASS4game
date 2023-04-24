using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
/// <summary>
/// UI管理脚本
/// </summary>
public class MainUIManagerC : MonoBehaviour
{
    /// <summary>
    /// 单例
    /// </summary>
    public static MainUIManagerC Instance;
    /// <summary>
    /// 教程页面
    /// </summary>
    public Transform tutorialPanel;
    /// <summary>
    /// 计时
    /// </summary>
    public Text timeTxt;
    /// <summary>
    /// 游戏结束页面
    /// </summary>
    public Transform gameOverPanel;
    /// <summary>
    /// 退出按钮
    /// </summary>
    public Button exitBtn;
    /// <summary>
    /// 重玩按钮
    /// </summary>
    public Button restartBtn;
    /// <summary>
    /// 隐藏教程页面的时间
    /// </summary>
    public float hideTutorialTime;
    /// <summary>
    /// 计时-分
    /// </summary>
    private int second;
    /// <summary>
    /// 计时-秒
    /// </summary>
    private int min;
    /// <summary>
    /// 是否开始/结束计时
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
    /// 输赢界面显示
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
        //停止计时
        isCutTime = false;
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 1;
        gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameOverPanel.GetComponent<CanvasGroup>().interactable = true;
    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// 重玩
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
    /// <summary>
    /// 隐藏教程页面
    /// </summary>
    public void HideTutorial()
    {
        tutorialPanel.gameObject.SetActive(false);
    }
    /// <summary>
    /// 计时协程
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
