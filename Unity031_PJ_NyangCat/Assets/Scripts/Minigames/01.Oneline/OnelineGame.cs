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
    private GameObject[] tileObjectArray;     //타일 오브젝트 배열
    [SerializeField]
    private GameObject tileMapObject;       //타일맵 오브젝트

    private float fRemainTime = 5.0f;       //제한시간 표시
    public float RemainTime { get { return fRemainTime; } set { fRemainTime = value; } }

    private int[,] iMapTile;
    private int[,] iMapOriginTile;
    private int[] iStartTile;           //시작 지점
    private int[] iNowTile;             //현재 지점

    private int iTileCount;             //통과한 타일 개수
    private int iTileNumber;            //총 통과 타일 개수

    //0 : 일반 타일 (통과 가능)
    //1 : 이미 지나간 타일
    //2 : 도착 지점
    //3 : 통과 불능 타일


    private void Awake()
    {
        iStartTile = new int[] { 0, 0 };            //이거 순서 y,x냐?
        iNowTile = new int[] { 0, 0 };
        //iMapTile = new int[4,6];
        //나중에는 이걸 여러개로 바꾸던지 파일에서 읽던지 수정할것.
        iMapTile = new int[,]{ { 0,0,3,3,3,3 },
                                { 3,0,3,0,0,2 },
                                { 3,0,3,0,0,3 },
                                { 3,0,0,0,0,3 }};
        iMapOriginTile = new int[,]{ { 0,0,3,3,3,3 },
                                { 3,0,3,0,0,2 },
                                { 3,0,3,0,0,3 },
                                { 3,0,0,0,0,3 }};

        tileObjectArray = new GameObject[6 * 4];

    }

    // Start is called before the first frame update
    void Start()
    {
        //그리드 레이아웃 ConstraintCount(=한줄에 몇개씩 출력시킬것인지) 수정
        tileMapObject.GetComponent<GridLayoutGroup>().constraintCount = 6;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Instantiate(tileObject).transform.SetParent(tileMapObject.transform,false);
                tileObjectArray[(i * 6) + j] = tileMapObject.transform.GetChild((i * 6) + j).gameObject;
                tileObjectArray[(i * 6) + j].GetComponent<OnelineGameTileObject>().ChangeTileState(SelectSprites(iMapTile[i, j]));
                tileObjectArray[(i * 6) + j].GetComponent<OnelineGameTileObject>().onelineGameManager = this;
                tileObjectArray[(i * 6) + j].GetComponent<OnelineGameTileObject>().indexX = j;
                tileObjectArray[(i * 6) + j].GetComponent<OnelineGameTileObject>().indexY = i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            if (iNowTile[1] > 0 || iNowTile[1] < 4)
            {
                if (iMapTile[iNowTile[1]-1, iNowTile[0]] == 0)
                {
                    iMapTile[iNowTile[1], iNowTile[0]] = 1;
                    iNowTile[1]--;
                } else if (iMapTile[iNowTile[1] - 1, iNowTile[0]] == 1)
                {
                    ResetArray(iMapTile, iMapOriginTile);
                    iNowTile = new int[]{0,0};
                }
                else if (iMapTile[iNowTile[1] - 1, iNowTile[0]] == 2)
                {
                    iNowTile[1]--;
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))            //여기서 옆으로 가던데요?
        {
            if (iNowTile[1] > -1 || iNowTile[1] < 3)
            {
                if (iMapTile[iNowTile[1] + 1, iNowTile[0]] == 0)
                {
                    iMapTile[iNowTile[1], iNowTile[0]] = 1;
                    iNowTile[1]++;
                }
                else if (iMapTile[iNowTile[1]+1, iNowTile[0]] == 1)
                {
                    ResetArray(iMapTile, iMapOriginTile);
                    iNowTile = new int[] { 0, 0 };
                }
                else if (iMapTile[iNowTile[1] + 1, iNowTile[0]] == 2)
                {
                    iNowTile[1]++;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (iNowTile[0] > 0 || iNowTile[0] < 6)
            {
                if (iMapTile[iNowTile[1], iNowTile[0]-1] == 0)
                {
                    iMapTile[iNowTile[1], iNowTile[0]] = 1;
                    iNowTile[0]--;
                }
                else if (iMapTile[iNowTile[1], iNowTile[0] - 1] == 1)
                {
                    ResetArray(iMapTile, iMapOriginTile);
                    iNowTile = new int[] { 0, 0 };
                }
                else if (iMapTile[iNowTile[1], iNowTile[0] - 1] == 2)
                {
                    iNowTile[0]--;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (iNowTile[0] > -1 || iNowTile[0] < 5)
            {
                if (iMapTile[iNowTile[1], iNowTile[0]+1] == 0)
                {
                    iMapTile[iNowTile[1], iNowTile[0]] = 1;
                    iNowTile[0]++;
                }
                else if (iMapTile[iNowTile[1], iNowTile[0]+1] == 1)
                {
                    ResetArray(iMapTile,iMapOriginTile);
                    iNowTile = new int[] { 0, 0 };
                }
                else if (iMapTile[iNowTile[1], iNowTile[0] + 1] == 2)
                {
                    iNowTile[0]++;
                }
            }
        }
        //Debug.Log("X :" + iNowTile[0] + ", Y:" + iNowTile[1]);


        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                tileObjectArray[(i * 6) + j].GetComponent<OnelineGameTileObject>().ChangeTileState(SelectSprites(iMapTile[i, j]));
            }
        }

        tileObjectArray[(iNowTile[1] * 6) + iNowTile[0]].GetComponent<OnelineGameTileObject>().ChangeTileState(SelectSprites(2));
    }




    Sprite SelectSprites(int index)
    {
        if (index < 0)
        {
            return DeniedTile;
        }

        if (index == 0) {
            return passableTile;
        }
        if (index == 1)
        {
            return passedTile;
        }
        if (index == 2)
        {
            return GoalTile;
        }
        if (index == 3)
        {
            return DeniedTile;
        }

        return DeniedTile;
    }

    private void ResetArray(int [,] Target, int[,] Origin)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                iMapTile[i, j] = iMapOriginTile[i, j];
            }
        }


    }

}
