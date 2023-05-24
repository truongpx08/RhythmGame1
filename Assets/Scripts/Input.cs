using UnityEngine;

public class Input : MonoBehaviour
{
    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayController.Instance.isPlaying)
                CanvasController.Instance.OnClickInputButton();
            else
                CanvasController.Instance.OnClickPlayButton();
        }
    }
}