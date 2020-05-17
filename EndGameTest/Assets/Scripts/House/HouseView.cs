using UnityEngine;

public class HouseView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer roof = null;
    [SerializeField] private SpriteRenderer front = null;
    [SerializeField] private SpriteRenderer back = null;

    private House m_House = null;

    private void Awake()
    {
        m_House = GetComponent<House>();
    }

    /// <summary>
    /// If player is not in the house, reset all sprites by activating them
    /// </summary>
    public void CheckIfCanActiveHouse()
    {
        if (!m_House.IsInHouse)
        {
            SetActiveBack(true);
            SetActiveRoof(true);
            SetActiveFront(true);
        }
    }

    /// <summary>
    /// Set is in house bool value to true and manage corresponding sprites
    /// </summary>
    public void EnterHouse() 
    {
        SetActiveBack(true);
        SetActiveRoof(false);
    }

    /// <summary>
    /// Set front sprite renderer enable value
    /// </summary>
    /// <param name="_value"></param>
    public void SetActiveFront(bool _value) 
    {
        front.enabled = _value;
    }

    /// <summary>
    /// Set back sprite renderer enable value
    /// </summary>
    /// <param name="_value"></param>
    public void SetActiveBack(bool _value) 
    {
        back.enabled = _value;
    }

    /// <summary>
    /// Set roof sprite renderer enable value
    /// </summary>
    /// <param name="_value"></param>
    public void SetActiveRoof(bool _value) 
    {
        roof.enabled = _value;
    }
}
