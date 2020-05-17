using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Audio Clips", fileName = "AudioClips")]
public class AudioClipsScriptableObject : ScriptableObject
{
    [Header("Music")]
    public AudioClip inGameMusic = null;
    
    [Header("In Game")]
    public AudioClip gunShot = null;
    public AudioClip angryCharacter = null;
    public AudioClip key = null;
    public AudioClip door = null;
}