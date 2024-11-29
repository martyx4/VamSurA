using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    int level;
    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;//프레임마다 시간 더하기
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1); //시간에 맞추어 레벨이 올라감, FloorToInt: 정수 변환 시 버림의 형식을 취함, CeilToInt: 정수 변환 시 올림의 형식을 취함

        if (timer > spawnData[level].spawnTime)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;//적 위치 스폰포인트로 지정
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

//직렬화(Serialization): 개체를 저장 혹은 전송하기 위해 변환, 여기선 유니티 인스펙터에 SpawnData를 표시하기위해 사용
[System.Serializable]//리스트와 속성 중 속성을 뜻하는 대괄호
public class SpawnData //각 적 사전 설정, 인스펙터에서 각 적을 따로 설정할 수 있음
{
    public float spawnTime;//적 생성주기
    public int spriteType;//적 종류(좀비, 해골 등)
    public int health;//적 체력
    public float speed;//적 속도
}