using UnityEngine;

public class Door : MonoBehaviour
{
    private House m_House = null;

    private BoxCollider m_Collider = null;

    private DoorView doorView = null;

    private void Awake()
    {
        doorView = GetComponentInChildren<DoorView>();
        m_Collider = GetComponent<BoxCollider>();
        m_House = GetComponentInParent<House>();
    }

    /// <summary>
    /// Verify if the key has been taken
    /// </summary>
    /// <param name="_collision"></param>
    private void OnCollisionEnter(Collision _collision)
    {
        if (m_House.HasKey)
        {
            Unlock();
        }
        else 
        {
            Debug.LogWarning("Should get the key first");
        }
    }

    /// <summary>
    /// Make the collider trigger and start opening animation
    /// </summary>
    private void Unlock() 
    {
        m_Collider.isTrigger = true;
        doorView.OpeningAnimation();
    }
}
