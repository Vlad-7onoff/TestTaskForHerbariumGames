using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    public UnityAction ClickedToMoveLeft;
    public UnityAction ClickedToMoveRight;

    public void MoveLeft()
    {
        ClickedToMoveLeft?.Invoke();
    }

    public void MoveRight()
    {
        ClickedToMoveRight?.Invoke();
    }
}
