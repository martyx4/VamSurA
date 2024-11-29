using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
//MonoBehaviour : 게임 로직 구성에 필요한 것들을 가진 클래스
{
    public Vector2 inputVec; //Vector2: 변수 타입, X와 Y를 가짐
    public float speed;
    public Scanner scanner;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake() //Awake는 시작 시 한번만 실행되는 생명주기
    {
        rigid = GetComponent<Rigidbody2D>(); //오브젝트에서 함수를 가져와 정의(초기화), <가져올 컴포넌트 이름>
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    //Update : 하나의 프레임마다 한번씩 호출되는 생명주기 함수
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal"); //Input은 유니티로 입력되는 모든 것을 관리하는 함수, Horizontal 의 버튼 매핑 받기
        inputVec.y = Input.GetAxisRaw("Vertical"); //Vertical의 버튼 매핑 받기
        //GetAxisRaw는 이동을 더욱 명확하게 해주는 코드
        //Edit -> Project Settings -> Input Manager: 물리적인 입력을 지정된 버튼으로 연결하는 역할
        //Horazontal - Positive: + 방향, Negative: - 방향
        //위 두 코드는 매 프레임 마다 입력되는 값을 inputVec이라는 변수에 입력하는 코드
        //Axis는 1과 -1 사이의 값만 있음(0: 입력 안하고 있음, 나머지:입력 중)
    }

    void FixedUpdate()
    {
        //이동 방법
        /*// 1. 힘을 준다
        rigid.AddForce(inputVec); //inputVec 방향으로 힘을 준다.

        // 2. 속도 제어
        rigid.velocity = inputVec; //이동 속도를 inputVec으로 정한다.*/

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;//임시로 값 저장,  normalized: 모든 이동을 1로 통일, fixedDeltaTime: 물리 프레임 하나가 소비한 시간

        // 3. 위치 이동(순간이동), 현재 위치도 더해주어야 작동
        rigid.MovePosition(rigid.position + nextVec); //rigid.position: 현재 위치, inputVec: 이동 값
    }

    void LateUpdate()//프레임이 종료 되기 전 실행되는 함수
    {
        anim.SetFloat("Speed", inputVec.magnitude); //"파라미터 이름", 백터2의 순수한 크기, 애니메이션 파라미터 변경 코드

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0; //캐릭터 이미지 좌/우 반전, 비교 연산자를 활용할 시 그 조건의 성립 여부가 bool 형식으로 입력됨
        }
    }
}
