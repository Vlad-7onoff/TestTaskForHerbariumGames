using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;
    [SerializeField] private float _deactivateTime;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _cooldownFirstShoot;

    private void Start()
    {
        StartCoroutine(Cooldown(_cooldownFirstShoot));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.Die();
        }
    }
    private void ActivateTrap()
    {
        transform.position = _positions[1].position;
    }

    private IEnumerator Cooldown(float time)
    {
        StartCoroutine(DeactivateTrap());
        yield return new WaitForSeconds(time);
        ActivateTrap();
        StartCoroutine(Cooldown(_cooldown));
    }

    private IEnumerator DeactivateTrap()
    {
        yield return new WaitForSeconds(_deactivateTime);
        transform.position = _positions[0].position;
    }
}