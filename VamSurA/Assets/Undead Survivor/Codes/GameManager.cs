using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //���� ���, �ٷ� �޸𸮿� ��´�, ����Ƽ�� ��Ÿ���� �ʴ´�, �ٸ� �ڵ忡�� �ٷ� �ҷ��� �� �ִ�.
    [Header("# Game Control")]
    public float gameTime;//�ΰ��� �ǽð��� ����
    public float maxGameTime = 2 * 10f;//�ִ� �ð�(���ڸ� ����) * (�� ��) ex 5��: 5 * 60f, 20��: 2 * 10f
    [Header("# Player Info")]
    public int health;
    public int maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450 };
    public PoolManager pool;
    public Player player;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        health = maxHealth;
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