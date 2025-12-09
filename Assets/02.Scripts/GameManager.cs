using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float timer = 60;

    public Button restartBtn;
    public Button resetBtn;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public GameObject stageClearPanel;

    void Start()
    {
        Time.timeScale = 1;

        restartBtn.onClick.AddListener(() =>
        {
            if (SceneManager.GetActiveScene().name == "StageLevel1")
                SceneManager.LoadScene("StageLevel1");
            else
                SceneManager.LoadScene("StageLevel2");
        });

        resetBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Title");
        });
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = ((int)timer).ToString();

        if(timer <= 0)
        {
            // 게임오버화면
            if(gameOverPanel.activeSelf == false)
            {
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
            }
        }
    }

    public void Restart()
    {
        // 현재 씬이 StageLevel1일 경우 StageLevel1씬을 로드합니다.
        if (SceneManager.GetActiveScene().name == "StageLevel1")
            SceneManager.LoadScene("StageLevel1");
        // 현재 씬이 StageLevel2일 경우 StageLevel2씬을 로드합니다.
        else
            SceneManager.LoadScene("StageLevel2");
    }

    public void Reset()
    {
        // Title 씬을 로드합니다.
        SceneManager.LoadScene("Title");
    }

    public void NextStage()
    {
        SceneManager.LoadScene("StageLevel2");
    }
}
