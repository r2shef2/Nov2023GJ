using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool isRotated;

    public Transform[] snapPoints;
    public Transform[] altSnapPoints;
    public int currentSnapPoint;

    public float positionSmoothTime = 0.3f;
    public float rotationSmoothTime = 1.5f;
    private Vector3 velocity = Vector3.zero;

    public MeshRenderer divider;
    public float minAlpha = 0.2f;
    public float maxAlpha = 1f;
    public float alphaSmoothTime = 1f;

    void Start()
    {
        currentSnapPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Transform target = isRotated ? altSnapPoints[currentSnapPoint] : snapPoints[currentSnapPoint];

        Vector3 targetPosition = target.position;
        Quaternion targetRotation = target.rotation;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, positionSmoothTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmoothTime);

        if (isRotated && divider.material.color.a > minAlpha)
        {
            SetAlpha(divider.material.color.a - Time.deltaTime * alphaSmoothTime);
        }
        else if (!isRotated && divider.material.color.a < maxAlpha)
        {
            SetAlpha(divider.material.color.a + Time.deltaTime * alphaSmoothTime);
        }
    }

    void SetAlpha(float alpha)
    {
        // Here you assign a color to the referenced material,
        // changing the color of your renderer
        Color color = divider.material.color;
        color.a = alpha;
        divider.material.color = color;
    }

    public void RotateCamera(bool rotate)
    {
        isRotated = rotate;
    }

    public void MoveLevel(int level)
    {
        currentSnapPoint = level;
    }
}
