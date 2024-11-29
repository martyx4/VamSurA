# VamSurA

* 화면은 Full HD(1920x1080)에 최적화 되어 있음(이는 또한 모바일이 아닌 컴퓨터용 개발임을 의미함)
* 씬을 불러오려면 Scenes\SampleScene 실행
* 영상 보고 코드 옮겨 적을 시 필요한 정보는 꼭 주석을 달아 놓기를

12 만들기
*\n == 줄 바꾸기

기존 Canvas/LevelUp은 ItemGroup으로 이름 변경
ItemGroup 앵커 최대로 꽉찬 화면 설정
Control Child Size: 자식 오브젝트를 부모의 크기에 맞게 자동 변경
버티컬 레이아웃 그룹: 컨트롤 차일드 사이즈 위드, 하이트 체크
스페이싱 '1'로 설정
레프트, 라이트, 바텀: 5
톱: 25
//ItemGroup/Item 3, 4 비활성화
item 0/icon에서 앵커 최대화에서 좌측 선택
Text Level도 마찬가지
icon의 위치 (6, 3)으로 조정
Text Level은 (6, -10)
Text Level 복사, 이름 Text Name으로 변경, 폰트 사이즈 7 변경
Alignment 첫번째 것 좌측으로 변경, (27, 6)
텍스트: '아이템 이름'
Text Name 복사, 'Text Desc'로 이름 변경, 폰트크기: 5
텍스트: '아이템 설명\n아이템 설명' (27, -7)
Text Level 텍스트 색상: 478E7C
Text Desc 텍스트 색상: 3C9689
item 1 ~ 4 삭제, item 0 4번 복사 후 이름 정렬순으로 재설정
Item.cs에 들어가는 Data 순서에 맞게 매치시키기
item 3, 4 비활성화
ItemData.cs에서 public string itemName; 아래 새로운 줄에 [TextArea] 입력
TextArea: 인스펙터에 텍스트를 여러 줄 넣을 수 있게하는 속성
Item 0(데이터 형식)에 Item Desc = '데미지 {0}% 증가\n회전체 {1}개 추가'
Item 1에 Item Desc = '데미지 {0}% 증가\n관통력 {1}개 추가'
Item 2에 Item Desc = '연사속도 {0}% 증가'
Item 3에 Item Desc = '이동속도 {0}% 증가'
Item 4에 Item Desc = '생명력 전체 회복'
