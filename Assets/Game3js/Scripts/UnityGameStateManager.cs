﻿using UnityEngine;

public abstract class UnityGameStateManager: MonoBehaviour
{
    public abstract void StartGame3js();
    public abstract void StopGame3jsSuccess(int score);
    public abstract void StopGame3jsFail();

}
