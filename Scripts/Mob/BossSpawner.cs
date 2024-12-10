using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject bossPrefab;

    public bool playOnStart = true;
    public float startFactor = 1f;
    public float additiveFactor = 0.1f;
    public float delayPerSpawnGroup = 3f;

    private int spawnedCount = 0; // 스폰된 프리팹 수를 추적하는 변수
    private bool bossSpawned = false; // 보스가 스폰되었는지 여부

    private void Start()
    {
        if (playOnStart)
            Play();
    }

    public void Play()
    {
        StartCoroutine(Process());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Process()
    {
        var factor = startFactor;
        var wfs = new WaitForSeconds(delayPerSpawnGroup);

        while (true)
        {
            yield return wfs;

            yield return StartCoroutine(SpawnProcess(factor));

            factor += additiveFactor;
        }
    }

    private IEnumerator SpawnProcess(float factor)
    {
        var count = Random.Range(factor, factor * 2f);

        for (int i = 0; i < count; i++)
        {
            Spawn();
            spawnedCount++; // 스폰된 카운트를 증가시킴

            // 30번 스폰된 경우 보스 프리팹을 생성
            if (spawnedCount >= 30 && !bossSpawned)
            {
                SpawnBoss();
                bossSpawned = true; // 보스가 이미 스폰되었음을 표시
                spawnedCount = 0; // 카운트를 초기화
            }

            if (Random.value < 0.2f)
                yield return new WaitForSeconds(Random.Range(0.01f, 0.02f));
        }
    }

    private void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation, transform);
    }

    private void SpawnBoss()
    {
        Instantiate(bossPrefab, transform.position, transform.rotation, transform);
    }
}
