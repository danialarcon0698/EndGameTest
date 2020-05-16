using Boo.Lang;
using System;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [Tooltip("Initial bulllets to instantiate")]
    [SerializeField] private int initialBullets = 20;

    private List<Bullet> bullets = null;

    private void Awake()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < initialBullets; i++)
        {

        }
    }
}
