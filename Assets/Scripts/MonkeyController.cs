using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonkeyController : MonoBehaviour
{
    private MonkeySpawn _monkeySpawn;
    public float speed = 5f;
    private List<Transform> _needles;
    private Rigidbody _rb;
    private bool _isStopped = false;
    private Vector3 _needle;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _monkeySpawn = FindObjectOfType<MonkeySpawn>();
        _needles = _monkeySpawn.needles;
        _needle = _needles[Random.Range(0, _needles.Count)].position;
    }
    
    private void FixedUpdate()
    {
        if (!_isStopped)
        {
            Move();
        }
        CheckLength();
        LookAtObject();
    }

    private void Move()
    {
        Vector3 direction = (_needle - gameObject.transform.position).normalized;
        _rb.velocity = new Vector3(direction.x * speed, 0f, direction.z);
    }

    private void LookAtObject()
    {
        _needle.y = 0f;
        transform.LookAt(_needle, Vector3.up);
    }

    private void CheckLength()
    {
        float direction = (_needle - transform.position).magnitude;
        if (direction <= 4)
        {
            _isStopped = true;
            _rb.velocity = Vector3.zero;
        }
        else
        {
            _isStopped = false;
        }
    }
}
