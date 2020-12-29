using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [Header("TargetObject")]
    public GameObject targetObject;

    [Header("TargetSpeed")]
    [SerializeField]
    public float fSpinSpeed;            //스핀 스피드하고 타임하고 그게 그거 아니야?
    [SerializeField]
    public float fSpinTime;             //아... 그냥 두개 상호보완시키자...    
    private float fOriginSpinSpeed;     //원본 속도         
    private float fOriginSpinTime;      //원본 시간 
    [SerializeField]
    private float fNowSpinDegree;
    public float FSpinTime { get { return FSpinTime; } set { FSpinTime = value; } }
    public float FSpinSpeed { get { return fSpinSpeed; } set { fSpinSpeed = value; } }


    public enum eSwitchSpin { left, right };
    public eSwitchSpin eSpin = eSwitchSpin.left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpeedCalibrator();

        fNowSpinDegree += fSpinSpeed * Time.deltaTime;

        fNowSpinDegree %= 360;

        if(eSpin == eSwitchSpin.left)
            targetObject.transform.Rotate(0,0, fSpinSpeed * Time.deltaTime);

        if (eSpin == eSwitchSpin.right)
            targetObject.transform.Rotate(0, 0, -fSpinSpeed * Time.deltaTime);
        //targetObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -fNowSpinDegree));

    }

    void SpeedCalibrator()
    {
        if (EqualFloat(fSpinSpeed, fOriginSpinSpeed) != true)
        {
            Debug.Log("SpinSpeed : Original -> " + fOriginSpinSpeed + " Now -> " + fSpinSpeed);

            fOriginSpinSpeed = fSpinSpeed;

            fSpinTime = 360 / fSpinSpeed;                  //그냥 이러면 되는거 아님?            

            //fOriginSpinTime = fSpinTime;

        }
        else if(EqualFloat(fSpinTime, fOriginSpinTime) != true)
        {
            Debug.Log("Spintime : Original -> " + fOriginSpinTime + " Now -> " + fSpinTime);
            
            fOriginSpinTime = fSpinTime;

            fSpinSpeed = (1/fSpinTime) * 360;                  //그냥 이러면 되는거 아님?   

            //fOriginSpinSpeed = fSpinSpeed;
        }
        

    }

    bool EqualFloat(float fA, float fB)
    {
        return (Mathf.Abs(fA - fB) < 0.01f);
    }

}
