using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target; //플레이어 위치

    bool isLive; //살아있는지

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;//몬스터가 플레이어에게 향하는 방향
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;//몬스터와 플레이어 충돌 시 틩겨져 나가는 상황 방지
    }

    void LateUpdate()
    {
        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x; //각 몬스터 자신의 상황에 맞추어 플레이어 바라보기
    }

    void OnEnable()//스크립트 활성화 싴 호출되는 함수
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();//타겟 초기화
        isLive = true;
        health = maxHealth;//적 부활 시 체력 재설정
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];//애니메이션은 스폰 데이터에 지정된 번호의 적의 애니메이션으로 지정한다.
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))//충돌 시 누군지 검사
            return;

        health -= collision.GetComponent<Bullet>().damage;

        if (health > 0) {
            // .. Live, Hit Action
        }
	    
	    else {
		    Dead();
	    }
    }
    
    void Dead()
    {
	    gameObject.SetActive(false);
    }
}
