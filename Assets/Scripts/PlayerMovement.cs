using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving = false;
    public Vector3 originPos, targetPos;
    public float timeToMove = .1f;

    private void Update()
    {
        CharacterMove();
    }

    private void CharacterMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (!isMoving)
        {
            if (verticalInput > 0.1f)
            {
                StartCoroutine(MoveChar(Vector3.up));
            }
            else if (verticalInput < -0.1f)
            {
                StartCoroutine(MoveChar(Vector3.down));
            }
            else if (horizontalInput > 0.1f)
            {
                StartCoroutine(MoveChar(Vector3.right));
            }
            else if (horizontalInput < -0.1f)
            {
                StartCoroutine(MoveChar(Vector3.left));
            }
        }
    }

    public IEnumerator MoveChar(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        originPos = transform.position;
        targetPos = originPos + direction;


        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }
}
