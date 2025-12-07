using UnityEngine;

public class TurretCtrl : MonoBehaviour
{
    public Transform targetTr;
    void Update()
    {
        Vector3 dir = targetTr.position - transform.position;
        transform.forward = dir;
        transform.eulerAngles = new Vector3(-180f, transform.eulerAngles.y, 0);
    }
}