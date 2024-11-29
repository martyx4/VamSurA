using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // .. 프리팹들을 보관할 변수
    public GameObject[] prefabs;//GameObject 뒤에 []를 붙이면 배열(리스트) 형태가 됨

    // .. 풀 담당을 하는 리스트들(위 변수와 이 리스트는 하나씩 추가되어 그 수가 같아야 한다.)
    List<GameObject>[] pools;

    void Awake()
    {
        //풀 초기화
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ... 선택한 풀에 놀고있는 (비활성화 된) 게임오브젝트 접근
        
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf) //비활성화 된 오브젝트 찾기
            {
                // ... 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ... 못 찾았으면?
        if (!select)
        {
            // ... 새롭게 생성하고 select 변수에 할당
            select = Instantiate(prefabs[index], transform); //복제, (원본 오브젝트, 자기자신 복제), 두번째 인자는 넣지 않아도 되지만 그렇게 한다면 무한 증식
            pools[index].Add(select);
        }

        return select;
    }
}