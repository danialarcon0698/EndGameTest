using UnityEngine;

public class House : MonoBehaviour
{
    public bool HasKey { get; set; } = false;
    public bool IsInHouse { get; private set; } = false;

    /// <summary>
    /// Set is in house bool value
    /// </summary>
    /// <param name="_isInHouse"></param>
    public void SetIsInHouse(bool _isInHouse)
    {
        IsInHouse = _isInHouse;
    }
}
