# BeginnersCsharp

처음 배우는 C# 프로그래밍 — Unity로 만드는 2D 슈팅 게임 학습 프로젝트

C#과 Unity의 기본기(변수, 클래스, 상속/추상 클래스, 이벤트, 코루틴, 파일 입출력 등)를 하나씩 익혀가며 만든 미니 탑다운 슈팅 게임입니다. 커밋과 브랜치가 학습 단계별로 나뉘어 있어, 처음부터 순서대로 따라가면 하나의 게임이 완성되는 과정을 볼 수 있습니다.

자세한 설명은 [Wiki](../../wiki)에서 확인하세요.

## 게임 소개

플레이어를 조작해 사방에서 몰려오는 적을 총알로 처치하고, 필드에 떨어지는 아이템을 먹어 점수를 올리는 게임입니다. 최고 점수는 로컬에 저장되어 다음 플레이에도 유지됩니다.

## 조작법

| 키 | 동작 |
| --- | --- |
| `W` `A` `S` `D` | 이동 |
| `Space` | 총알 발사 |

## 주요 기능

- **플레이어 이동/공격** — WASD 이동, Space로 3연발 사격
- **적 스폰 & 이동 패턴** — `Enemy`를 상속한 `Enemy1`, `Enemy2`가 서로 다른 방향으로 이동
- **아이템 시스템** — 추상 클래스 `Item`을 상속하는 `Coin`, `SpeedUp` (일정 시간 후 반투명 처리 후 소멸)
- **이벤트 기반 처리** — `EventManager`의 `EnemyDieEvent`로 적 처치를 여러 매니저에 통지
- **점수 저장** — `BinaryFormatter`로 최고 점수를 `Application.persistentDataPath`에 저장/불러오기

## 프로젝트 구조

```
BeginnersGame/
└─ Assets/
   ├─ Scenes/          # 학습 단계별 씬 (272PlayerMove, 273PlayerAttack, 353Enemy, 471Item, 571GameManager, 582Event, 583EnemySpawn, 584SaveUserData ...)
   ├─ Scripts/
   │  ├─ Player.cs            # 플레이어 체력/피격 처리
   │  ├─ PlayerController.cs  # 이동, 사격 입력 처리
   │  ├─ Bullet.cs             # 총알 수명 관리
   │  ├─ Enemy/
   │  │  ├─ Enemy.cs           # 적 공통 로직 (체력, 피격, 사망 이벤트)
   │  │  ├─ Enemy1.cs / Enemy2.cs  # 이동 패턴별 하위 클래스
   │  ├─ Item/
   │  │  ├─ Item.cs            # 아이템 추상 클래스 + IEffect 인터페이스
   │  │  ├─ Coin.cs / SpeedUp.cs   # 코인, 속도 증가 아이템
   │  └─ Managers/
   │     ├─ GameManager.cs     # 게임 시작/점수/세이브·로드
   │     ├─ EventManager.cs    # 전역 이벤트(적 사망 등)
   │     ├─ SpawnManager.cs    # 적 랜덤 스폰
   │     └─ ItemManager.cs     # 아이템 랜덤 스폰
   ├─ Prefabs/
   └─ Settings/
```

## 실행 방법

1. [Unity Hub](https://unity.com/download)에서 **Unity 6000.1.2f1** (또는 호환 버전)을 설치합니다.
2. Unity Hub에서 `Add` → 이 저장소의 `BeginnersGame` 폴더를 선택해 프로젝트를 엽니다.
3. `Assets/Scenes` 폴더에서 원하는 씬을 열고 재생(▶) 버튼을 눌러 실행합니다.
   - 학습 흐름을 따라가려면 `272PlayerMove` → `273PlayerAttack` → `353Enemy` → `471Item` → `571GameManager` → `582Event` → `583EnemySpawn` → `584SaveUserData` 순서를 추천합니다.

## 더 알아보기

각 시스템(플레이어, 적, 아이템, 매니저, 세이브 데이터)에 대한 자세한 설명과 학습 로드맵은 [Wiki](../../wiki)에 정리되어 있습니다.
