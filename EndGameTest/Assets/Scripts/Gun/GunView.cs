using UnityEngine;

public class GunView : MonoBehaviour
{
    private ParticleSystem m_MuzzleParticles = null;

    private void Awake()
    {
        m_MuzzleParticles = GetComponentInChildren<ParticleSystem>();
    }

    /// <summary>
    /// Activate "muzzle" particles
    /// </summary>
    public void ActivateMuzzleParticles() 
    {
        m_MuzzleParticles.Play();
    }

    /// <summary>
    /// Trigger shot sound
    /// </summary>
    public void PlayShotSound() 
    {
        AudioManager.instance.PlaySFx(AudioManager.instance.audioClips.gunShot, 1f, false);
    }
}
