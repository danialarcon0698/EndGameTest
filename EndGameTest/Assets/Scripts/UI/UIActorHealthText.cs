using UnityEngine;
using TMPro;

public class UIActorHealthText : MonoBehaviour
{
    [SerializeField] private ActorScriptableObject actorScriptable = null;

    private TextMeshProUGUI m_Text = null;

    private readonly string format = "HP: {0}";

    private void Awake()
    {
        m_Text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateText(actorScriptable.health);

        actorScriptable.OnTakeDamage += UpdateText;
    }

    /// <summary>
    /// Update Text depending on the format
    /// </summary>
    /// <param name="_health"></param>
    private void UpdateText(int _health)
    {
        m_Text.SetText(string.Format(format, _health));
    }
}
