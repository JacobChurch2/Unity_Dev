using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField][Range(1, 20)][Tooltip("Force to move object")] public float force;

    public Rigidbody rb;

    private void Awake()
    {
        print("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Start");
        //rb = GetComponent<RigidBody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * force, ForceMode.VelocityChange);
        }
    }
}
