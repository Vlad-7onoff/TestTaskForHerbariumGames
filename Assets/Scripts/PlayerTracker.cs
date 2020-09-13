using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private float _xOffset;

    private Transform _player;

    private void Update()
    {
        transform.position = new Vector3(_player.position.x - _xOffset, transform.position.y, transform.position.z);
    }

    public void SetPlayerTransform(Transform playerTransform)
    {
        _player = playerTransform;
    }
}
