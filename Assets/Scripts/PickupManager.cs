using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour {

	private void OnTriggerEnter(Collider c) {
		if (c.gameObject.name.Equals("GravityAbilityPickup"))
		{
			c.gameObject.SetActive(false);
		}
	}
}
