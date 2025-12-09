using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameManager gameMgr;

    public GameObject[] hpImg;
    public GameObject itemUIPrefab;
    public Transform itemContainer;

    int health = 3;
    int itemCount = 0;
    private void Update()
    {
        if(health <= 0)
        {
            Time.timeScale = 0;
            gameMgr.gameOverPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void GetDamage()
    {
        health--;

        for(int i =0; i < hpImg.Length; i++)
        {
            hpImg[i].SetActive(false);

            if (i < health)
                hpImg[i].SetActive(true);
        }
    }

    // 플레이어의 충돌체에 다른 오브젝트가 감지되면 호출
    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 아이템에 닿았을 경우
        if(other.tag == "Item")
        {
            // 아이템 증가
            itemCount++;
            // 별모양 아이콘 생성
            Instantiate(itemUIPrefab, itemContainer);
            // 아이템을 획득했으므로 필드에서 아이템의 모습을 감추기
            other.gameObject.SetActive(false);
            // 다음 스테이지로 넘어갈 수 있는지 검사
            NextStage();
        }
    }

    // 다음 스테이지로 넘어갈 수 있는지 조건을 검사합니다.
    void NextStage()
    {
        // 플레이어가 획득한 아이템이 5개 이상일 경우
        if(itemCount >= 5)
        {
            // 스테이지 클리어 화면을 켭니다.
            gameMgr.stageClearPanel.SetActive(true);
            // 게임을 일시정지 합니다.
            Time.timeScale = 0;
        }
    }
}