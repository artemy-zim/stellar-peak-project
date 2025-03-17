using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

public class PlayerView : MonoBehaviour, IDestroyable, ISpawnable
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private AudioSource _spawnAudio;
    [SerializeField] private float _knockbackDuration;

    [SerializeField] private UnityEvent _onDestroyed;
    [SerializeField] private UnityEvent _onHit;

    private Vector3 _knockbackVelocity;
    private float _knockbackTime;

    public event Action Damaged;

    private void Update()
    {
        if (_knockbackTime > 0)
        {
            _controller.Move(_knockbackVelocity * Time.deltaTime);
            _knockbackTime -= Time.deltaTime;
        }
    }

    public void Hit(Vector3 hitForce, Vector3 hitPoint)
    {
        Damaged?.Invoke();
        _onHit?.Invoke();

        ApplyKnockback(hitForce, hitPoint);
    }

    public void Destroy()
    {
        _onDestroyed?.Invoke();
    }

    public void OnSpawn()
    {
        _spawnAudio.Play();
    }

    private void ApplyKnockback(Vector3 hitForce, Vector3 hitPoint)
    {
        Vector3 direction = (transform.position - hitPoint).normalized; 
        direction.y = 0; 

        _knockbackVelocity = direction * hitForce.magnitude; 
        _knockbackTime = _knockbackDuration;
    }
}
