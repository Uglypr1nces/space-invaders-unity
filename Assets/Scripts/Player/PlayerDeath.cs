
using System;

using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public static bool isDead = false;

    private void Start () {

        isDead = false;
    }

	public int hitPoints;
	public string[] killingTags;
    public GameObject objectToSpawnOnDestroy;
    public GameObject objectToSpawnOnDamage;
	public GameObject gameOverMenu;

	private void OnCollisionEnter2D (Collision2D collision) {

		bool damageTaken = false;

		if (killingTags.Length == 0) damageTaken = true;
		else if (Array.IndexOf(killingTags, collision.collider.tag) > -1)
			damageTaken = true;

		if (damageTaken) {

			hitPoints--;

			if (hitPoints <= 0) {

				Instantiate(objectToSpawnOnDestroy, transform.position, transform.rotation);

                isDead = true;
                gameOverMenu.SetActive(true);

                Destroy(gameObject);

            } else
                Instantiate(objectToSpawnOnDamage, transform.position, transform.rotation);
		}
	}
}