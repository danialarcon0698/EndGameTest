using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterAction : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTriggerEnterEvent = null;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent?.Invoke();
    }
}
