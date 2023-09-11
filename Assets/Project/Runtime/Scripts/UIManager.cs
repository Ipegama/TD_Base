using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private bool isHoveringOverUI = false;

    public void SetHoveringState(bool state)
    {
        isHoveringOverUI = state;
    }

    public bool IsHoveringOverUI()
    {
        return isHoveringOverUI;
    }

}
