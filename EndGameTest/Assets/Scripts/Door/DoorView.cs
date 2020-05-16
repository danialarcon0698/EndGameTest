using UnityEngine;

public class DoorView : MonoBehaviour
{
    private int isOpenHash = Animator.StringToHash("IsOpen");
    private Animator m_Animator = null;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Start door opening animation.
    /// </summary>
    public void OpeningAnimation()
    {
        m_Animator.SetBool(isOpenHash, true);
    }
}
