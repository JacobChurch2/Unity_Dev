using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;
    
	private void OnCollisionEnter(Collision collision)
	{
        print(collision.gameObject.name);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.TryGetComponent(out Player player))
		{
			player.AddPoints(10);

			AudioSource audio = GetComponent<AudioSource>();
			
			audio.Play();
		}

        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
		//gameObject.SetActive(false);
		GetComponent<MeshRenderer>().enabled = false;
		Destroy(gameObject, 1);
	}
}
