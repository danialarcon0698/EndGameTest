using UnityEngine;

public class BillboardFX : MonoBehaviour
{
    [SerializeField] private Transform camTransform = null;

    private Quaternion originalRotation = Quaternion.identity;

    private void Update()
    {
        transform.rotation = camTransform.rotation * originalRotation;
    }
}