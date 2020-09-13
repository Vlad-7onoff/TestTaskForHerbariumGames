using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Transform _pathPoint;

    public Transform PathPoint => _pathPoint;
}
