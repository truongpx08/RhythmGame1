using Pixelplacement;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] protected bool isKeyDown;
    public bool IsKeyDown => isKeyDown;

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     // if (PlayController.Instance.isPlaying)
        //     //     CanvasController.Instance.OnClickInputButton();
        //     // else
        //     //     CanvasController.Instance.OnClickPlayButton();
        // }

        isKeyDown = Input.GetKeyDown(KeyCode.Space);
    }
}