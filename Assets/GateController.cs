using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public bool isDisabled = false;
    public float minAlpha = 0.2f;
    public float alphaSmoothTime = 1f;

    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDisabled)
        {
            Array.ForEach(mesh.materials, mat =>
            {
                if (mat.color.a > minAlpha)
                {
                    SetAlpha(mat, mat.color.a - Time.deltaTime * alphaSmoothTime);
                }
            });
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void Disable()
    {
        isDisabled = true;
        mesh.enabled = false;
    }

    void SetAlpha(Material mat, float alpha)
    {
        Color color = mat.color;
        color.a = alpha;
        mat.color = color;
    }
}
