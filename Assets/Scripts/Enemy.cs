using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject _prefabBullet;

    public Transform firePoint;
    public float delayShoot;
    public float radius;

    private float timer;
    private float firstDelay;
    private float distance;

    private void Start()
    {
        firstDelay = delayShoot;
        player = GameObject.FindGameObjectWithTag("Player");

        delayShoot = 1;
    }


    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < radius)
        {
            Vector2 dir = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion qto = Quaternion.AngleAxis(angle, Vector3.forward);
            Quaternion qto2 = Quaternion.Euler(qto.eulerAngles.x,
                qto.eulerAngles.y,
                qto.eulerAngles.z + 90);

            transform.rotation = Quaternion.Slerp(transform.rotation, qto2, 100);

            Vector3 rotateDirFirePoint = qto2 * new Vector3(0, -.5f, 0);
            Vector3 newPos = transform.position + rotateDirFirePoint * 3;

            firePoint.position = newPos;

            timer += Time.deltaTime;

            if (timer > delayShoot)
            {
                timer = 0;

                ShootBullet();
            }
        }
    }

    private void ShootBullet()
    {
        Instantiate(_prefabBullet, firePoint.position, Quaternion.identity);

        delayShoot = firstDelay;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
