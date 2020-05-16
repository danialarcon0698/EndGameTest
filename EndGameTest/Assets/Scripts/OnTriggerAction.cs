using UnityEngine;
using UnityEngine.Events;

public class OnTriggerAction : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTriggerEnterEvent = null;
    [SerializeField] private UnityEvent OnTriggerExitEvent = null;
    
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExitEvent?.Invoke();
    }
}
