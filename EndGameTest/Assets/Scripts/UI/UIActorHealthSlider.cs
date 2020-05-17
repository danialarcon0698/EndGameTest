using UnityEngine;
using UnityEngine.UI;

public class UIActorHealthSlider : MonoBehaviour
{
    [SerializeField] private ActorScriptableObject actorScriptable = null;

    private Slider m_HealthSlider = null;

    private void Awake()
    {
        m_HealthSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        m_HealthSlider.maxValue = actorScriptable.health;
        UpdateSlider(actorScriptable.health);

        actorScriptable.OnTakeDamage += UpdateSlider;
    }

    /// <summary>
    /// Update slider value
    /// </summary>
    /// <param name="_health"></param>
    private void UpdateSlider(int _health) 
    {
        m_HealthSlider.value = _health;
    }
}
