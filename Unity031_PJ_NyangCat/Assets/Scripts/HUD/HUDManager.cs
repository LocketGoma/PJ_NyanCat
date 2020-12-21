using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//메인 하단 UI임
public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;
    [Header("BackGround")]              //바뀔수도 있으니?
    public GameObject backGroundObject;

    [Header("Bars")]                    //근데 게이지를 몇개쓸거임?
    public GameObject NyanStatusA;
    public GameObject NyanStatusB;
    public GameObject NyanStatusC;
    public GameObject NyanStatusNameA;  //텍스트 (게이지 별 이름)
    public GameObject NyanStatusNameB;
    public GameObject NyanStatusNameC;


    public bool isEnable;
    public bool IsEnableHUD { get { return isEnable; } set { isEnable = value; } }

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
