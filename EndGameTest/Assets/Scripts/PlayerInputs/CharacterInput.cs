using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{
    private IMovable movable = null;
    private IRotable rotable = null;
    private IShootable shootable = null;

    private Vector2 moveValue = Vector2.zero;
    private Vector2 aimValue = Vector2.zero;

    private void Awake()
    {
        movable = GetComponent<IMovable>();
        rotable = GetComponent<IRotable>();
        shootable = GetComponent<IShootable>();
    }

    private void FixedUpdate()
    {
        movable.Move(moveValue);
        rotable.Rotate(aimValue);
        shootable.Shoot(aimValue);
    }

    public void OnMove(InputAction.CallbackContext _context)
    {
        moveValue = _context.ReadValue<Vector2>();
    }

    public void OnAim(InputAction.CallbackContext _context)
    {
        aimValue = _context.ReadValue<Vector2>();
    }
}
