using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour, IDamagable
{
	[SerializeField] protected float health;
	[SerializeField] protected int points;
	[SerializeField] protected IntEvent scoreEvent;
					   
	[SerializeField] protected GameObject hitPrefab;
	[SerializeField] protected GameObject destroyPrefab;

    public void ApplyDamage(float damage)
	{
		health -= damage;
		if(health < 0)
		{
			scoreEvent?.RaiseEvent(points);
			AudioSource boom = GetComponent<AudioSource>();
			boom.Play();

			if(destroyPrefab != null)
			{
				Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
			}
            GetComponent<MeshRenderer>().enabled = false;
			GetComponent<Collider>().enabled = false;
            Destroy(gameObject,1);
		}
		else
		{
			if(hitPrefab != null)
			{
				Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
			}
		}
	}
}
