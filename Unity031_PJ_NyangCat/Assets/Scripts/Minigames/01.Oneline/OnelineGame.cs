using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//한붓 그리기
public class OnelineGame : MonoBehaviour
{
    [SerializeField]
    private Sprite passableTile;            //통과 가능 타일
    [SerializeField]
    private Sprite passedTile;              //통과한 타일
    [SerializeField]
    private Sprite DeniedTile;              //통과 불능 타일
    [SerializeField]
    private Sprite GoalTile;                //도착 지점
    [SerializeField]
    private Sprite PlayerSprite;            //플레이어 현재 위치 표시
    [SerializeField]
    private GameObject tileObject;          //타일 오브젝트
    private GameObject tileObjectArray;     //타일 오브젝트 배열
    [SerializeField]
    private GameObject tileMapObject;       //타일맵 오브젝트

    private float fRemainTime = 5.0f;       //제한시간 표시
    public float RemainTime { get { return fRemainTime; }set { fRemainTime = value; } }

    private int[,] iMapTile;
    private int[] iStartTile;

    //0 : 일반 타일 (통과 가능)
    //1 : 이미 지나간 타일
    //2 : 도착 지점
    //3 : 통과 불능 타일
    

    private void Awake()
    {
        iStartTile = new int[] { 0, 0 };
        //iMapTile = new int[6, 4];
        //나중에는 이걸 여러개로 바꾸던지 파일에서 읽던지 수정할것.
        iMapTile = new int [,]{ { 0,0,3,3,3,3 },
                                { 3,0,3,0,0,2 },
                                { 3,0,3,0,0,3 },
                                { 3,0,0,0,0,3 }};
                

    }

    // Start is called before the first frame update
    void Start()
    {
        //그리드 레이아웃 ConstraintCount(=한줄에 몇개씩 출력시킬것인지) 수정
        tileMapObject.GetComponent<GridLayoutGroup>().constraintCount = 6;

        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {

            }
        }
    }
}
