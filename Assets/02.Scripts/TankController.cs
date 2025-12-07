using UnityEngine;
using UnityEngine.AI;

public class TankController : MonoBehaviour
{
    public Transform shotPos;
    NavMeshAgent agent;
    public Transform playerTr;
    public GameObject bulletPrefab;

    public float shotCoolTime = 3.0f;
    float shotTimer = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        shotTimer = shotCoolTime;
    }

    void Update()
    {
        agent.SetDestination(playerTr.position);

        if (shotTimer > 0)
            shotTimer -= Time.deltaTime;
        else
            ShotBullet();
    }

    void ShotBullet()
    {
        shotTimer = shotCoolTime;

        GameObject go = Instantiate(bulletPrefab);
        go.transform.position = shotPos.position;
        Vector3 forwardDir = playerTr.position - transform.position;
        forwardDir.y = 0;
        go.transform.forward = forwardDir;
    }

    // 플레이어에 부딪히면 밀어내기
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Player")
            return;
        Vector3 dir =  playerTr.position - transform.position;
        dir.y = 0;
        CharacterController charCtrl = playerTr.GetComponent<CharacterController>();
        charCtrl.Move(dir);
        PlayerController playerCtrl = playerTr.GetComponent<PlayerController>();
        playerCtrl.GetDamage();
    }
}