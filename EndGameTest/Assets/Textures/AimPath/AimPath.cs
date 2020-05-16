using UnityEngine;

public class AimPath : MonoBehaviour
{
    private LineRenderer m_LineRenderer;
    
    private void Awake()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        SetPositionKeys();
    }

    private void SetPositionKeys()
    {
        m_LineRenderer.SetPosition(1, Vector3.forward * 6f);
    }

    //private void Update()
    //{
    //    if (m_Player.CanMove && m_Player.HasBomb)
    //    {
    //        aimNormalized = m_Player.InputAiming.normalized;
    //        if (aimNormalized != Vector2.zero)
    //        {
    //            if (!m_LineRenderer.enabled)
    //            {
    //                m_LineRenderer.enabled = true;
    //            }
    //            targetRotation = Mathf.Atan2(aimNormalized.x, aimNormalized.y) * Mathf.Rad2Deg;
    //            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVel, m_Player.TurnSmooth);
    //        }
    //        else
    //        {
    //            if (m_LineRenderer.enabled)
    //            {
    //                m_LineRenderer.enabled = false;
    //            }
    //        } 
    //    }
    //    else
    //    {
    //        if (m_LineRenderer.enabled)
    //        {
    //            m_LineRenderer.enabled = false;
    //        }
    //    }
    //}
}