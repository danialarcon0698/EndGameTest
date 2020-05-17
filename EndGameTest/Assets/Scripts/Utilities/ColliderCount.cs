using UnityEngine;
using UnityEngine.Events;

public class ColliderCount : MonoBehaviour
{
    private int numberOfThingsInCollider = 0;

    [SerializeField] private UnityEvent OnNothingInCollider = null;

    /// <summary>
    /// Increase the things in collider by 1
    /// </summary>
    /// <param name="_other"></param>
    private void OnTriggerEnter(Collider _other)
    {
        numberOfThingsInCollider += 1;
    }

    /// <summary>
    /// Decrease number of things in collider and send event if it is 0
    /// </summary>
    /// <param name="_other"></param>
    private void OnTriggerExit(Collider _other)
    {
        numberOfThingsInCollider = (numberOfThingsInCollider > 0) ? numberOfThingsInCollider -= 1 : numberOfThingsInCollider = 0;

        if (numberOfThingsInCollider <= 0)
        {
            OnNothingInCollider?.Invoke();
        }
    }
}
