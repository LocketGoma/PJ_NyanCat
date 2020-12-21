using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 1. 게임 장르 : 미니게임천국 스타일 (퍼즐형)
 2. 예상 플레이 타임 : 5분
 3. 스토리 : 달로 쫒겨난 고양이들의 지구 침공
 4. 기반 : 유플로리아같이 냥이들을 지구로 보내서 뿅뿅
 5. 미니게임 : 약 5~7개 정도의 미니게임 (5~10초짜리)들이 무작위 인카운터로 등장.
               해결시 보상, 특정 회수 이상 실패 시 패널티
 6. 엔딩 : 약 2~3종류 (배드, 노멀, 굿)
            배드 - 냥이들은 패배했습니다..
            노멀 - 앗 꿈이었자나 (TNR 엔딩)
            굿  - 집냥이가 되어서 쓰담쓰담받는 엔딩
 7. 예상 개발기간 : 최대 1달
 
 
 */

/*
 점령 가능시간까지 단 5일! 이라고 표시해두고 상단에 05:00 띄워놓고 시작
맨 아래 바에는 점령도를 표시
 
 
 */

public class MasterManager : MonoBehaviour
{
    public static MasterManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
