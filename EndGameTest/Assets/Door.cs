using UnityEngine;

public class Door : MonoBehaviour
{
    private int isOpenHash = Animator.StringToHash("IsOpen");

    private Animator m_Animator = null;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void OpenDoor() 
    {
        m_Animator.SetBool(isOpenHash, true);
    }
}
