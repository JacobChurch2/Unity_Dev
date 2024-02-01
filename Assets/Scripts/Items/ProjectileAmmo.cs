using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileAmmo : Ammo
{
	private void Start()
	{
		if (ammoData.force != 0) GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * ammoData.force, ammoData.forceMode);
		Destroy(gameObject, ammoData.lifetime);
	}
}
