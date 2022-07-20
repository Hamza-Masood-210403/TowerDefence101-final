using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float time_Between_Waves = 5f;
    private float countdown = 2f;

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0) {
            SpawnWave();
            countdown = time_Between_Waves;   
        }

        countdown -= Time.deltaTime;
    }

    void SpawnWave() {
        Debug.Log("Wave Incoming!");
    }
}
