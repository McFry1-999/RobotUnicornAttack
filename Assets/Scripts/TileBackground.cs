using System;
using UnityEngine;
using UnityEngine.Rendering;

public class TileBackground : MonoBehaviour
{
    [SerializeField]

    private float speed = 0.2f;

    private Renderer rendererUser;

    private Vector2 offset = Vector2.zero;

    private bool isMoving = true;

    public bool IsMoving 
    {
        get => isMoving;
        set
        {
            isMoving = true;
        }
    }

    private void Start()
    {
        rendererUser = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (!isMoving) return;
        offset.x += speed * Time.deltaTime;
        rendererUser.material.mainTextureOffset = offset;
    }
}
