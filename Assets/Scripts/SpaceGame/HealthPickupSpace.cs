using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupSpace : MonoBehaviour
{
	[SerializeField] float health;
	[SerializeField] GameObject pickupPrefab;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out PlayerShip player))
		{
			player.ApplyHealth(health);
			if(pickupPrefab != null) Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
