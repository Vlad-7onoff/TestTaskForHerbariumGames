using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Animator _animator;
    private int _currentPoint;
    private Transform[] _points;

    public UnityAction ReadyToMove;
    public UnityAction GoOutMap;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _animator.SetBool("Walk", false);
            _animator.SetBool("WalkBackwards", false);
            ReadyToMove?.Invoke();
        }
    }

    public void MoveRight()
    {
        if (InIsRange(_currentPoint + 1))
        {
            _currentPoint++;
            _animator.SetBool("Walk", true);
        }
        else
        {
            GoOutMap?.Invoke();
        }
    }

    public void MoveLeft()
    {
        if (InIsRange(_currentPoint - 1))
        {
            _currentPoint--;
            _animator.SetBool("WalkBackwards", true);
        }
        else
        {
            GoOutMap?.Invoke();
        }
    }

    public void Init(Transform[] pathPoints, int currentPoint)
    {
        _points = pathPoints;
        _currentPoint = currentPoint;
    }

    private bool InIsRange(int point) => (point >= 0 && point < _points.Length);
}
