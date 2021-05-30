﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksGeneration : MonoBehaviour
{
    [SerializeField] public Vector3 startPos;
    [SerializeField] public GameObject prefabBrick;
    [SerializeField] public float offsetPerBrick;

    private int maxTamX;
    private int maxTamZ;
    private float scaleXBricks;
    private float scaleZBricks;
    private List<Color> colors;
    void Start()
    {
        maxTamX = 9;
        maxTamZ = 6;
        scaleXBricks = prefabBrick.transform.localScale.x + offsetPerBrick;
        scaleZBricks = prefabBrick.transform.localScale.z + offsetPerBrick;
        colors = new List<Color>();
        colors.Add(Color.white);
        colors.Add(Color.red);
        colors.Add(Color.blue);
        colors.Add(Color.magenta);
        colors.Add(Color.yellow);
        colors.Add(Color.green);

        MeshRenderer auxRender;
        for (int i = 0; i < maxTamZ; i++)
        {
            for (int j = 0; j < maxTamX; j++)
            {
                Vector3 posNewBrick = new Vector3(startPos.x + (j * scaleXBricks), 0, startPos.z - (i * scaleZBricks));
                GameObject go = Instantiate(prefabBrick, posNewBrick, Quaternion.identity, transform);
                auxRender = go.GetComponent<MeshRenderer>();
                auxRender.material.color = colors[i];
            }
        }
    }

    void Update()
    {
        
    }
}
