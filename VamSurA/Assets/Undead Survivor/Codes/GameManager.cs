using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //정적 요소, 바로 메모리에 얹는다, 유니티에 나타나지 않는다, 다른 코드에서 바로 불러올 수 있다.

    public float gameTime;//인게임 실시간을 저장
    public float maxGameTime = 2 * 10f;//최대 시간(앞자리 숫자) * (몇 초) ex 5분: 5 * 60f, 20초: 2 * 10f

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
