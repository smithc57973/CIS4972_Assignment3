using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int chance;
    public PlayerController pc;
    public Color currentColor;

    public abstract void UpdateData(Color c);

    public Color RandomColor()
    {
        int r = Random.Range(0, 3);
        switch (r)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.green;
            case 2:
                return Color.blue;
            default:
                return Color.red;
        }

    }
}
