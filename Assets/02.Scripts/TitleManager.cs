using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public Button startBtn;

    void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("StageLevel1");
        });
    }
}
