
using System;

using UnityEngine;

public class Mortality : MonoBehaviour {

	public int hitPoints;
	public string[] killingTags;
	public GameObject objectToSpawnOnDestroy;

	private void OnCollisionEnter2D (Collision2D collision) {

		bool damageTaken = false;

		if (killingTags.Length == 0) damageTaken = true;
		else if (Array.IndexOf(killingTags, collision.collider.tag) > -1)
			damageTaken = true;

		if (damageTaken) {

			hitPoints--;

			if (hitPoints <= 0) {

				if (objectToSpawnOnDestroy != null)
					Instantiate(objectToSpawnOnDestroy, transform.position, transform.rotation);

				Destroy(gameObject);
			}
		}
	}
}
