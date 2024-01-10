using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
        print(collision.gameObject.name);
	}

	private void OnTriggerEnter(Collider other)
	{
        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
	}
}
