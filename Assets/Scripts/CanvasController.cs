using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class CanvasController : Singleton<CanvasController>
{
    public GameObject losePanel;

    public void OnClickInputButton()
    {
        ObjectController.Instance.OnTouch();
    }

    [Button]
    public void OnClickPlayButton()
    {
        losePanel.SetActive(false);
        GameController.Instance.Play();
    }
}