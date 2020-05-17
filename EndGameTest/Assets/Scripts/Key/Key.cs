using UnityEngine;

public class Key : MonoBehaviour
{
    /// <summary>
    /// Play key sound when it has been taken
    /// </summary>
    public void PlayKeySound() 
    {
        AudioManager.instance.PlaySFx(AudioManager.instance.audioClips.key, 1f, false);
    }
}
