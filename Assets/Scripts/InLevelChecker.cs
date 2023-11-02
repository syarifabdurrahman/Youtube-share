using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLevelChecker : MonoBehaviour
{
    public bool isRoomActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            CameraController.instance.ChangeTarget(transform);

            isRoomActive = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            CameraController.instance.ChangeTarget(transform);

            isRoomActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isRoomActive = false;
        }
    }
}
