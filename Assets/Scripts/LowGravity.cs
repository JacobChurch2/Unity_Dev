using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LowGravity : MonoBehaviour
{
	[SerializeField] float gravity = 1;
	private float normalMass;
	private bool entered = false;

	private void OnTriggerStay(Collider other)
	{
		if (!entered && other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
		{
			normalMass = rb.mass;
			rb.mass = gravity/normalMass;
			entered = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
		{
    		rb.mass = normalMass;
			entered = false;
		}
	}
}
