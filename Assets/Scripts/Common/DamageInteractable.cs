using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInteractable : Interactable
{
	[SerializeField] Action action;
	[SerializeField] float damage = 1;
	[SerializeField] bool damageOverTime = false;

	private void Start()
	{
		if (action != null)
		{
			action.onEnter += OnInteractStart;
			action.onStay += OnInteractActive;
		}
	}

	public override void OnInteractStart(GameObject interactor)
	{
		// apply damage one time when interact is started
		if (!damageOverTime && interactor.TryGetComponent(out IDamagable damagable))
		{
			damagable.ApplyDamage(damage);
		}
	}

	public override void OnInteractActive(GameObject interactor)
	{
		// apply damage over time, while interact is active
		if (damageOverTime && interactor.TryGetComponent(out IDamagable damagable))
		{
			damagable.ApplyDamage(damage * Time.deltaTime);
		}
	}

	public override void OnInteractEnd(GameObject interactor)
	{
		//
	}
}
