using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [Header("Player Settings")]
    [SerializeField] private float speed = 10;
    [SerializeField] private float bounceMultiplier = .8f;
    [SerializeField] private float rotatingSpeed = 4;
    public float maxVelocityForFullBounce;
    public float minBounceMultiplier;
    public float maxBounceMultiplier;

    public bool hasColided = false;
    private Vector2 collisionNormal;

    private void Update()
    {
        if (GameController.instance.isStarting && !GameController.instance.isPaused)
        {

            rb.bodyType = RigidbodyType2D.Dynamic;

            Movement();

            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x < Screen.width / 2)
                {
                    TurnLeft();
                }

                if (Input.mousePosition.x > Screen.width / 2)
                {
                    TurnRight();
                }
            }

        }
        else
        {
            if (GameController.instance.isPaused)
            {
                rb.bodyType = RigidbodyType2D.Static;
            }

            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BounceSurface")
        {
            print("Bertumbuk");

            hasColided = true;

            //kalkulasi impact dari perputaran player
            collisionNormal = collision.contacts[0].normal;
            float impactVelocity = collision.relativeVelocity.magnitude;
            float normalizedImpactVelocity = Mathf.Clamp01(impactVelocity / maxVelocityForFullBounce);

            float bounceMultiplierCalculation = Mathf.Lerp(minBounceMultiplier, maxBounceMultiplier, normalizedImpactVelocity);
            ApplyBounceEffect(bounceMultiplierCalculation);
        }
    }

    private float ApplyBounceEffect(float bounceMultiplierCalculation)
    {
        bounceMultiplier = bounceMultiplierCalculation;
        hasColided = false;

        return bounceMultiplier;
    }

    public void Movement()
    {
        if (!hasColided)
            rb.velocity = rb.velocity.normalized * (speed * bounceMultiplier);
    }

    public void TurnLeft()
    {
        rb.angularVelocity += rotatingSpeed;
    }

    public void TurnRight()
    {
        rb.angularVelocity -= rotatingSpeed;
    }
}
