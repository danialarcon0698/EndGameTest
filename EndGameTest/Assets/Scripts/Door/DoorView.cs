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
    /// Start door opening.
    /// </summary>
    public void OpeningAnimation()
    {
        AudioManager.instance.PlaySFx(AudioManager.instance.audioClips.door, 1f, false);
        m_Animator.SetBool(isOpenHash, true);
    }
}
