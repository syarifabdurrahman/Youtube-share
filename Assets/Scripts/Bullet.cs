using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public float force;
    public float delayTodeath;
    public float steer = 10f;

    private Rigidbody2D rb2d;
    private float timer;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player");

        BulletMovement();
    }

    private void Update()
    {
        BulletMovement();

        timer += Time.deltaTime;

        if(timer > delayTodeath )
        {
            Destroy(gameObject);
        }
    }

    private void BulletMovement()
    {
        rb2d.velocity = transform.up * force * Time.deltaTime * 10;
        Vector3 direction = (target.transform.position - transform.position).normalized;
        float rotationSteer = Vector3.Cross(transform.up, direction).z;
        rb2d.angularVelocity = rotationSteer * steer * 10f;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
        }
    }
}
