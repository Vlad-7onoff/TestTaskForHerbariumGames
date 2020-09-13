using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;
    private bool _readyToMove = true;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _playerMover.ReadyToMove += ActivateReadiness;
    }

    private void OnDisable()
    {
        _playerMover.ReadyToMove -= ActivateReadiness;
    }

    private void MoveLeft()
    {
        if (_readyToMove)
        {
            _playerMover.MoveLeft();
            _readyToMove = false;
        }
    }

    private void MoveRight()
    {
        if (_readyToMove)
        {
            _playerMover.MoveRight();
            _readyToMove = false;
        }
    }

    private void ActivateReadiness()
    {
        _readyToMove = true;
    }

    public void InitJoystick(Joystick joystick)
    {
        joystick.ClickedToMoveLeft += MoveLeft;
        joystick.ClickedToMoveRight += MoveRight;
    }
}
