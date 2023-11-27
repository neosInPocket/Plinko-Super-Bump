using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameTools
{
    public static Vector2 GetScreenSize()
    {
    	return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}
