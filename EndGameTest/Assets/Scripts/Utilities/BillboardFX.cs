using UnityEngine;

public class BillboardFX : MonoBehaviour
{
    [SerializeField] private Transform camTransform = null;

    private Quaternion originalRotation = Quaternion.identity;

    /// <summary>
    /// Make the transform always look to the camera
    /// </summary>
    private void Update()
    {
        transform.rotation = camTransform.rotation * originalRotation;
    }
}