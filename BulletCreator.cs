using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletCreator : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private WaitForSeconds _delayShooting;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private void Start()
    {
        _bulletPrefab = GetComponent<Rigidbody>();

        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.transform.up = direction;
            bullet.velocity = direction * _speed;

            yield return _delayShooting;
        }
    }
}