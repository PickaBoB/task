using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody _rb;
    private float streinght = 35f;
    public List<ParticleSystem> particles;
    [SerializeField] private bool OnGround;

    void Start()
    {
        foreach (ParticleSystem element in particles)
        {
            element.Stop();
        }
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Movement();
        StartParticleSystem();
    }

    private void Movement()
    {
        transform.position = new Vector3(0f, transform.position.y, transform.position.z + Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(transform.up * streinght * Time.deltaTime,ForceMode.Impulse);
            OnGround= true;
        }
        else OnGround= false;
    }
    private void StartParticleSystem()
    {
        while (OnGround)
        {
            foreach (ParticleSystem element in particles)
            {
                element.Play();
            }
        }
        if (!OnGround)
        {
            foreach (ParticleSystem element in particles)
            {
                element.Stop();
            }
        }
    }
}
