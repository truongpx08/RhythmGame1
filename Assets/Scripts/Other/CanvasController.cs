using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class CanvasController : Singleton<CanvasController>
{
    public GameObject losePanel;

    [Button]
    public void OnClickInputButton()
    {
        // Player.Instance.OnTouch();
    }

    [Button]
    public void OnClickPlayButton()
    {
        losePanel.SetActive(false);
        PlayController.Instance.OnPlay();
    }
}