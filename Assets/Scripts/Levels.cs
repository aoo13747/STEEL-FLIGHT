using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Levels
{
    public int scoreToUnlock;
    public Wave wave;
    public bool endGame;

    [HideInInspector]
    public bool isUnlock = false;
}
