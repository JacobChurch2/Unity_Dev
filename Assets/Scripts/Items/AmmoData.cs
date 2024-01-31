using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
	RAYCAST,
	COLLIDER
}

[CreateAssetMenu(fileName = "Ammo", menuName = "Weapon/Ammo")]
public class AmmoData : ScriptableObject
{
	public AmmoType ammoType;
	public float lifetime;
	public float damage;
	public bool destroyOnImpact;
	public GameObject impactPrefab;

	[Header("Collider")]
	public float force;
	public ForceMode forceMode;
	public bool damageOverTime;
	public bool bounce;
	public bool rotateToVelocity;
	public bool impactOnExpired;

	[Header("Raycast")]
	public float distance;
	public LayerMask hitMask;
	
}
