using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // .. �����յ��� ������ ����
    public GameObject[] prefabs;//GameObject �ڿ� []�� ���̸� �迭(����Ʈ) ���°� ��

    // .. Ǯ ����� �ϴ� ����Ʈ��(�� ������ �� ����Ʈ�� �ϳ��� �߰��Ǿ� �� ���� ���ƾ� �Ѵ�.)
    List<GameObject>[] pools;

    void Awake()
    {
        //Ǯ �ʱ�ȭ
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ... ������ Ǯ�� ����ִ� (��Ȱ��ȭ ��) ���ӿ�����Ʈ ����
        
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf) //��Ȱ��ȭ �� ������Ʈ ã��
            {
                // ... �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ... �� ã������?
        if (!select)
        {
            // ... ���Ӱ� �����ϰ� select ������ �Ҵ�
            select = Instantiate(prefabs[index], transform); //����, (���� ������Ʈ, �ڱ��ڽ� ����), �ι�° ���ڴ� ���� �ʾƵ� ������ �׷��� �Ѵٸ� ���� ����
            pools[index].Add(select);
        }

        return select;
    }
}