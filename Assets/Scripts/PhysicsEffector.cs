using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEffector : MonoBehaviour
{
	[SerializeField] Transform direction;
	[SerializeField] float force = 1;
	[SerializeField] bool oneTime = true;

	private void OnTriggerEnter(Collider other)
	{
		if (oneTime && other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
		{
			rb.AddForce(direction.up * force, ForceMode.VelocityChange);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
		{
			rb.AddForce(direction.up * force);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (oneTime && other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
		{
			rb.AddForce(direction.up * force, ForceMode.VelocityChange);
		}
	}
}
