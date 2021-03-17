using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPVisual : MonoBehaviour
{
    [SerializeField]
    private Sprite hearthSprite;

    private int hearths;
    private int maxHearths = 10;

    private void Start()
    {



        Vector2 HearthAnchoredPosition = new Vector2(0, 0);

        for (int i = 0; i < hearths; i++)
        {
            CreateHearthImage(HearthAnchoredPosition);
            HearthAnchoredPosition += new Vector2(1, 0);
        }

    }

    private void Update()
    {
        
    }



    private Image CreateHearthImage(Vector2 anchoredPosition)
    {
        //vytvori objekt
        GameObject hearthGameObject = new GameObject("Hearth", typeof(Image));
        //nastavi jako child transform pozice
        hearthGameObject.transform.parent = transform;
        hearthGameObject.transform.localPosition = Vector3.zero;

        hearthGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        hearthGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
        //nastavi sprite
        Image hearthImage = hearthGameObject.GetComponent<Image>();
        hearthImage.sprite = hearthSprite;

        return hearthImage;
    }
}
