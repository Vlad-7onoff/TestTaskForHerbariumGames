using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform _level;

    private Transform[] _pathPoints;

    public Transform[] PathPoints => _pathPoints;

    private void Awake()
    {
        Box[] _boxes = _level.GetComponentsInChildren<Box>();
        _pathPoints = new Transform[_boxes.Length];

        for (int i = 0; i < _boxes.Length; i++)
            _pathPoints[i] = _boxes[i].PathPoint;
    }
}
