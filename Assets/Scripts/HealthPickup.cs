using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HealthPickup : MonoBehaviour
{
	[SerializeField] GameObject pickupPrefab = null;
	[SerializeField] float healAmount = 5;

	private void OnCollisionEnter(Collision collision)
	{
		print(collision.gameObject.name);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out Player player))
		{
			player.Heal(healAmount);

			AudioSource audio = GetComponent<AudioSource>();

			audio.Play();
		}

		Instantiate(pickupPrefab, transform.position, Quaternion.identity);
		GetComponent<MeshRenderer>().enabled = false;
		//gameObject.SetActive(false);
		Destroy(gameObject, 1);
	}
}
