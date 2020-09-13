using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    private Animator _animator;
    private PlayerMover _playerMover;
    private PlayerInput _playerInput;

    public UnityAction Died;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _playerMover.GoOutMap += Die;
    }

    private void OnDisable()
    {
        _playerMover.GoOutMap -= Die;
    }

    public void Init(Path path, int indexSpawnPosition, Joystick joystick)
    {
        _playerMover.Init(path.PathPoints, indexSpawnPosition);
        _playerInput.InitJoystick(joystick);
    }

    public void Die()
    {
        _animator.enabled = false;
        _playerInput.enabled = false;
        Died?.Invoke();
    }
}
