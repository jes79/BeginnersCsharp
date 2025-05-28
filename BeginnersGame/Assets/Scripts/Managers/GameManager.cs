using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public ItemManager itemManager;
    public GameObject Cover;
    public Text BestScoreText;
    public Text ScoreText;
    int score;

    UserData userData;

    void Start()
    {
        EventManager.EnemyDieEvent += OnEnemyDie;
        LoadUserData();
        BestScoreText.text = String.Format("Best Score : {0}", userData.BestScore);
    }

    public void OnClickStartButton()
    {
        Cover.SetActive(false);
        StartCoroutine(spawnManager.SpawnRandom());
        itemManager.SpawnRandom();
    }

    public void OnEnemyDie()
    {
        score++;
        ScoreText.text = String.Format("Score : {0}", score);
        if (userData.BestScore < score)
        {
            userData.BestScore = score;
            BestScoreText.text = String.Format("Best Score : {0}", userData.BestScore);
            SaveUserData();
        }
    }


    void SaveUserData()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/userdata.dat", FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, userData);
        file.Close();
    }

    void LoadUserData()
    {
        // 사용자 데이터 파일이 존재하는지 먼저 확인
        // 첫 실행이면 파일이 없을 수 있음
        if (File.Exists(Application.persistentDataPath + "/userdata.dat"))
        {
            // 파일이 존재하는 경우: 기존 데이터 로드

            // 파일을 읽기 전용으로 열기
            FileStream file = new FileStream(Application.persistentDataPath + "/userdata.dat", FileMode.Open);

            // 바이너리 데이터를 객체로 변환하기 위한 포맷터
            BinaryFormatter bf = new BinaryFormatter();

            // 파일에서 바이너리 데이터를 읽어와서 UserData 객체로 역직렬화
            userData = (UserData)bf.Deserialize(file);

            // 파일 스트림 닫기
            file.Close();

            // Debug.Log("기존 데이터 로드 완료 - 최고 점수: " + userData.BestScore);
        }
        else
        {
            // 파일이 존재하지 않는 경우: 새로운 데이터 생성
            // 첫 게임 실행 시 또는 데이터 파일 삭제 시
            userData = new UserData();

            // Debug.Log("새로운 사용자 데이터 생성");
        }
    }
}

[Serializable]
class UserData
{
    public int BestScore;
}





/*
=== 전체 동작 흐름 요약 ===

1. 게임 시작 (Start 함수)
   → 이벤트 구독 → 데이터 로드 → UI 초기화

2. 플레이어가 게임 시작 버튼 클릭
   → 커버 제거 → 적/아이템 스폰 시작 → 점수 초기화

3. 게임 플레이 중 적 처치
   → 점수 증가 → UI 업데이트 → 최고 점수 확인 → 필요시 저장

4. 게임 종료 후 재시작
   → 저장된 최고 점수가 유지됨
*/