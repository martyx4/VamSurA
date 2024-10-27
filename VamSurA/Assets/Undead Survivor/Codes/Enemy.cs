using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target; //�÷��̾� ��ġ

    bool isLive; //����ִ���

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

        Vector2 dirVec = target.position - rigid.position;//���Ͱ� �÷��̾�� ���ϴ� ����
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;//���Ϳ� �÷��̾� �浹 �� ������ ������ ��Ȳ ����
    }

    void LateUpdate()
    {
        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x; //�� ���� �ڽ��� ��Ȳ�� ���߾� �÷��̾� �ٶ󺸱�
    }

    void OnEnable()//��ũ��Ʈ Ȱ��ȭ �� ȣ��Ǵ� �Լ�
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();//Ÿ�� �ʱ�ȭ
        isLive = true;
        health = maxHealth;//�� ��Ȱ �� ü�� �缳��
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];//�ִϸ��̼��� ���� �����Ϳ� ������ ��ȣ�� ���� �ִϸ��̼����� �����Ѵ�.
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))//�浹 �� ������ �˻�
            return;

        collision.GetComponent<Bullet>().damage
    }*/
}
