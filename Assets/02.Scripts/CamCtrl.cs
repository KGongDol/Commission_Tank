using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    public Transform playerTr;
    Vector3 tarPos;

    public Vector3 camAngle;
    public float distance = 5;
    public float wheelSensitive = 10;

    void Update()
    {
        MoveCam();
        ControlDistance();
        CalcTarPos();
    }

    void CalcTarPos()
    {
        // 캐릭터를 기준으로 45도 각도
        Vector3 dir = Vector3.back * distance;
        float angle = camAngle.x;
        tarPos = playerTr.position + (Vector3.up*10) + Quaternion.AngleAxis(angle, Vector3.right) * dir;
    }

    void ControlDistance()
    {
        float input = -Input.GetAxis("Mouse ScrollWheel") * wheelSensitive;
        distance += input;
        distance = Mathf.Clamp(distance, 20, 200);
    }

    void MoveCam()
    {
        transform.position = Vector3.Slerp(transform.position, tarPos, 1 * Time.deltaTime);
    }
}
