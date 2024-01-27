using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
	[SerializeField] float rate = 1;
	[SerializeField] Vector3 amplitude = Vector3.one;

	float time = 0;
	Vector3 origin = Vector3.zero;

	private void Start()
	{
		origin = transform.position;
	}

	void Update()
	{
		time += Time.deltaTime * rate;

		Vector3 offset = Vector3.zero;
		offset.x = Mathf.PerlinNoise(time, 1) * amplitude.x;
		offset.y = Mathf.PerlinNoise(1, time) * amplitude.y;
		offset.z = Mathf.PerlinNoise(time, time) * amplitude.z;

		transform.position = origin + offset;
	}
}
