using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainterOfKnifeIcons : MonoBehaviour
{
    [SerializeField]
    private KnifeCounter _knifeCounter;
    [SerializeField]
    private Image _knifeIcon;
    [SerializeField]
    private List<Image> knifeIconCell = new List<Image>();

    //private void Start()
    //{
    //    DrawMaxKnifes();
    //}

    public void DrawUsedKnifeIcon()
    {
        knifeIconCell[_knifeCounter._usedKnifeCount].color = Color.gray;

    }

    public void DrawMaxKnifes()
    {
        foreach (Image knifeIcon in knifeIconCell)
        {
            knifeIcon.color = Color.white;
            knifeIcon.gameObject.SetActive(false);
        }
        for (int i = 0; i < _knifeCounter._maxKnifeCount; i++)
        {
            knifeIconCell[i].gameObject.SetActive(true);
            knifeIconCell[i].sprite = _knifeIcon.sprite;
        }
    }


}
