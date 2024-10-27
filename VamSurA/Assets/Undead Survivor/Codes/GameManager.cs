using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //���� ���, �ٷ� �޸𸮿� ��´�, ����Ƽ�� ��Ÿ���� �ʴ´�, �ٸ� �ڵ忡�� �ٷ� �ҷ��� �� �ִ�.

    public float gameTime;//�ΰ��� �ǽð��� ����
    public float maxGameTime = 2 * 10f;//�ִ� �ð�(���ڸ� ����) * (�� ��) ex 5��: 5 * 60f, 20��: 2 * 10f

    public PoolManager pool;
    public Player player;
    
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}
