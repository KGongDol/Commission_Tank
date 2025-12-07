using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed = 100.0f;
    
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
