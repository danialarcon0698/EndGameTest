using UnityEngine;
using TMPro;

public class UIActorName : MonoBehaviour
{
    [SerializeField] private ActorScriptableObject actorScriptableObject = null;

    private TextMeshProUGUI m_Text = null;

    private void Awake()
    {
        m_Text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        m_Text.SetText(actorScriptableObject.playerName);
    }
}
