using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Animator animator;
	private void OnTriggerEnter(Collider other)
	{
		animator.SetTrigger("Start");
	}
}
