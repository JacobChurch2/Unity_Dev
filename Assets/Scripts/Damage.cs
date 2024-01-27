using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 1;
    [SerializeField] bool oneTime = true;
    [SerializeField] bool solid;

    private void OnTriggerEnter(Collider other)
    {
        if(oneTime && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.TakeDamage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!oneTime && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.TakeDamage(damage * Time.deltaTime);
        }
    }

	private void OnCollisionEnter(Collision other)
	{
		if (solid && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
		{
			damagable.TakeDamage(damage);
		}
	}
}

public interface IDamagable
{ 
    void TakeDamage(float damage);
}

