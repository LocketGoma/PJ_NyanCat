using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncountPostControl : MonoBehaviour
{

    public GameObject mGameObject;      //부모 오브젝트
    [Range(-5.0f,10.0f)]
    public float fPinRange;

    float fCX, fCY;
    Vector3 vCore;

    // Start is called before the first frame update
    void Start()
    {
        if (mGameObject == null)
        {
            mGameObject = gameObject.GetComponentInParent<GameObject>();
        }

        fCX = mGameObject.transform.position.x;
        fCY = mGameObject.transform.position.y;
        vCore = new Vector3(fCX, fCY, 0);

        this.gameObject.transform.position = new Vector3(gameObject.transform.position.x + Mathf.Cos(gameObject.transform.rotation.eulerAngles.x) * fPinRange, gameObject.transform.position.y - Mathf.Sin(gameObject.transform.rotation.eulerAngles.x) * fPinRange);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.RotateAround(vCore, Vector3.forward, mGameObject.GetComponent<SpinObject>().fSpinSpeed * Time.deltaTime);



    }
}
