using UnityEngine;

public class ItemController : MonoBehaviour
{
    float speed = 100.0f;
    float upSpeed = 2.0f;
    bool isUp = true;

    float startY = 0;

    private void Start()
    {
        startY = transform.position.y;
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
        Move();
    }

    void Move()
    {
        if(isUp)
        {
            transform.position += Vector3.up * upSpeed * Time.deltaTime;

            if((transform.position.y - startY) > 2.0f)
            {
                isUp = false;
            }
        }
        else
        {
            transform.position -= Vector3.up * upSpeed * Time.deltaTime;

            if((startY - transform.position.y) > 2.0f)
            {
                isUp = true;
            }
        }
    }
}
