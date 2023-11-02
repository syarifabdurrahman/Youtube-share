using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [Header("Camera Settings")]
    public float cameraMoveSpeed;
    public Transform target;

    public float gameSceneWidth;
    Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;

        instance = this;
    }

    private void Start()
    {
        AdjustCamera();

        ChangeTarget(target);
    }

    private void AdjustCamera()
    {
        float pixelUnit = gameSceneWidth / Screen.width;

        float desiredHeight = .5f * pixelUnit * Screen.height;

        mainCam.orthographicSize = desiredHeight;
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x,
                target.position.y + 1, transform.position.z),
                cameraMoveSpeed * Time.deltaTime);
    }

}
