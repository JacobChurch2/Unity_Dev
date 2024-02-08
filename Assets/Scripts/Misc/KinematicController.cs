using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
    [SerializeField, Range(0, 40)] float speed = 1;
    [SerializeField] float maxDistance = 5;

    public float health = 100;

	void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        Vector3 force = direction * speed * Time.deltaTime;
        transform.localPosition += force;

        transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxDistance);

        Quaternion qyaw = Quaternion.AngleAxis(direction.x * 40, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(-direction.y * 40, Vector3.right);

        Quaternion rotation = qyaw * qpitch;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, 10 * Time.deltaTime);

        transform.localRotation = rotation;
    }
}
