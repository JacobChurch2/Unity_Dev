using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammo : Interactable
{
	[SerializeField] protected AmmoData ammoData;

	public override void OnInteractStart(GameObject gameObject)
	{
		// apply damage if game object is damagable
		if (!ammoData.damageOverTime && gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
		{
			damagable.ApplyDamage(ammoData.damage);
		}

		// create impact prefab
		if (ammoData.impactPrefab != null)
		{
			Instantiate(ammoData.impactPrefab, transform.position, transform.rotation);
		}

		// destroy game object
		if (ammoData.destroyOnImpact)
		{
			Destroy(gameObject);
		}
	}

	public override void OnInteractActive(GameObject gameObject)
	{
		// apply damage if game object is damagable
		if (ammoData.damageOverTime && gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
		{
			damagable.ApplyDamage(ammoData.damage * Time.deltaTime);
		}
	}

	public override void OnInteractEnd(GameObject gameObject)
	{
		//
	}

	public void OnDamage(GameObject target)
	{
		// apply damage if game object has health
		if (target.TryGetComponent<IDamagable>(out IDamagable damagable))
		{
			damagable.ApplyDamage(ammoData.damage * ((ammoData.damageOverTime) ? Time.deltaTime : 1));
		}

		// create impact prefab
		if (ammoData.impactPrefab != null)
		{
			Instantiate(ammoData.impactPrefab, transform.position, transform.rotation);
		}

		// destroy game object
		if (ammoData.destroyOnImpact)
		{
			Destroy(gameObject);
		}
	}
}
