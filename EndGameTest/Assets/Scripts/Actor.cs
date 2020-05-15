using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField] protected ActorScriptableObject actor = null;

    protected Rigidbody m_Rigidbody = null;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        OnAwake();
    }

    protected abstract void OnAwake();
}
