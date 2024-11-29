using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) //Area 태그가 아니라면(!) 실행 안함(return)
            return;
        
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);//거리 구하기, Abs: 절댓값(음수 방지)
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1; //조건이 어떤 상태라면? (참 시 주는 값 : 거짓 시 주는 값)
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag) //태그가 어떤 상태인지(태그가 뭔지)
        {
            case "Ground":
                if (diffX > diffY)// X축 거리차이가 Y축 거리차이보다 크다
                {
                    transform.Translate(Vector3.right * dirX * 40);//지정된 값 만큼 현재위치에서 이동, 이동량 대입
                }
                else if (diffX < diffY)// Y축 거리차이가 X축 거리차이보다 크다
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;

            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-1f, 1f), Random.Range(-3f, 3f), 0f));//플레이어 맞은편에서 등장
                }
                break;
        }
    }
}
