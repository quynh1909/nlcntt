using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject winTitle;
    public GameObject loseTitle;

    private void Awake()
    {
        winTitle.SetActive(false);
        loseTitle.SetActive(false);
    }

    public void ShowResult(bool isWin)
    {
        winTitle.SetActive(isWin);
        loseTitle.SetActive(!isWin);
    }
}
