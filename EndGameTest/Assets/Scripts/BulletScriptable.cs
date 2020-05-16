using UnityEngine;

[CreateAssetMenu(menuName = "Bullet Data", fileName = "Bullet")]
public class BulletScriptable : ScriptableObject
{
    public int damage = 1;

    public float speed = 2f;
}