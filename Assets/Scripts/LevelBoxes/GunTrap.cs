using System.Collections;
using UnityEngine;

public class GunTrap : MonoBehaviour
{
    [SerializeField] private Transform _gunTransform;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _cooldownFirstShoot;

    private void Start()
    {
        StartCoroutine(Cooldown(_cooldownFirstShoot));
    }

    private void Shoot()
    {
        _bullet.gameObject.SetActive(true);
        _bullet.transform.position = _gunTransform.position;
    }

    private IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        Shoot();
        StartCoroutine(Cooldown(_cooldown));
    }
}
