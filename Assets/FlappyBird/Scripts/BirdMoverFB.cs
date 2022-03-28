using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMoverFB : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    //[SerializeField] private float _speed;
    [SerializeField] private float _flyForce = 10;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rb;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private void Start()
    {
        transform.position = _startPosition;
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.zero;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        Restart();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            _rb.velocity = new Vector2(0, 0);
            transform.rotation = _maxRotation;
            _rb.AddForce(Vector2.up * _flyForce, ForceMode2D.Force);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
    public void Restart()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rb.velocity = Vector2.zero;
    }
}
