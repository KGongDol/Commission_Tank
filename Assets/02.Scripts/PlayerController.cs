using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject[] hpImg;
    public GameObject itemUIPrefab;
    public Transform itemContainer;

    int health = 3;
    int itemCount = 0;
    private void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene("StageLevel1");
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            itemCount++;
            Instantiate(itemUIPrefab, itemContainer);
            other.gameObject.SetActive(false);
            NextState();
        }
    }

    void NextState()
    {
        if(itemCount >= 5)
        {
            if(SceneManager.GetActiveScene().name == "StageLevel1")
                SceneManager.LoadScene("StageLevel2");
            else
                SceneManager.LoadScene("Title");
        }
    }
}