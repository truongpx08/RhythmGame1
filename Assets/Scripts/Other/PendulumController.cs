using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float amplitude = 45.0f;
    public float period = 2.0f;
    private float angle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        angle = amplitude * Mathf.Sin(Time.time * 2 * Mathf.PI / period);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
