using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnelineGameTileObject : MonoBehaviour
{
    [SerializeField]
    public OnelineGame onelineGameManager;
    public Sprite tileSprite;
    public int indexX;
    public int indexY;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = tileSprite;
    }
    public void ChangeTileState(Sprite sprite)
    {
        tileSprite = sprite;
        gameObject.GetComponent<Image>().sprite = tileSprite;
    }

}
