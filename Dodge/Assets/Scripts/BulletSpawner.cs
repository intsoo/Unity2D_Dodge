using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;  // 생성할 bullet의 원본 프리팹
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;  // bullet을 쏠 위치
    private float spawnRate;  // bullet 생성(spawn) 주기

    private float timeAfterSpawn;  // time after latest spawn

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;  // 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;  // shot the bullet where the player is at.
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;  // 누적

        if(timeAfterSpawn >= spawnRate) {
            timeAfterSpawn = 0f;  // reset

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);  // 정면 방향이 타겟을 향하도록

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);  // random rate for each spawn
        }
    }
}
