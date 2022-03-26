using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler :  MonoBehaviour
{

    public UnityEvent OnTouched;

    public void InputHandler()
    {
        if (!KnifeHitDetector.isGameOver)
            OnTouched?.Invoke();
    }

}

