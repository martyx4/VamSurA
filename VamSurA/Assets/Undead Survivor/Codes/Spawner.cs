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
        timer += Time.deltaTime;//�����Ӹ��� �ð� ���ϱ�
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1); //�ð��� ���߾� ������ �ö�, FloorToInt: ���� ��ȯ �� ������ ������ ����, CeilToInt: ���� ��ȯ �� �ø��� ������ ����

        if (timer > spawnData[level].spawnTime)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;//�� ��ġ ��������Ʈ�� ����
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

//����ȭ(Serialization): ��ü�� ���� Ȥ�� �����ϱ� ���� ��ȯ, ���⼱ ����Ƽ �ν����Ϳ� SpawnData�� ǥ���ϱ����� ���
[System.Serializable]//����Ʈ�� �Ӽ� �� �Ӽ��� ���ϴ� ���ȣ
public class SpawnData //�� �� ���� ����, �ν����Ϳ��� �� ���� ���� ������ �� ����
{
    public float spawnTime;//�� �����ֱ�
    public int spriteType;//�� ����(����, �ذ� ��)
    public int health;//�� ü��
    public float speed;//�� �ӵ�
}