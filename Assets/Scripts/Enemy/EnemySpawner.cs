
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public static List<Enemy> enemies;
    public static int wave = 0;

    public float advanceRateSeconds;
    public float advanceDistance;
    public float spawnSpacing;
    public int waveSize;
    public GameObject enemyPrefab;
    public Sprite[] sprites;

    private float advanceTimer;

    private void Start () {

        enemies = new List<Enemy>();
        wave = 0;
    }

    private void Update () {

        if (PlayerDeath.isDead) return;

        if (enemies.Count == 0 && wave != 0) Advance();

        advanceTimer -= Time.deltaTime;
        if (advanceTimer < 0) advanceTimer = advanceRateSeconds; else return;

        Advance();
    }

    private void Advance () {

        foreach (Enemy enemy in enemies)
            enemy.transform.Translate(Vector3.down * advanceDistance);

        for (int i = -waveSize / 2; i < waveSize / 2; ++i) {

            Vector3 position = transform.position + new Vector3(i * spawnSpacing, 0, 0);
            GameObject enemy = Instantiate(enemyPrefab, position, transform.rotation);
            enemy.GetComponent<SpriteRenderer>().color = new Color(
                Random.Range(100, 255) / 255f,
                Random.Range(100, 255) / 255f,
                Random.Range(100, 255) / 255f
            );
            enemy.GetComponent<SpriteRenderer>().sprite
                = sprites[Random.Range(0, sprites.Length)];
        }

        if (advanceRateSeconds > 0.8f)
            advanceRateSeconds -= 0.05f;

        wave++;
    }
}
