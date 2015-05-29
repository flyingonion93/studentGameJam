﻿using UnityEngine;
using System.Collections;

public class GameManager : osSingleton<GameManager> {

    protected GameManager () { }

    public GameManager _manager;

    #region Handlers
    public ManagerNavPoint _managerNavPoint;
    public ManagerNavPoint ManagerNavPoint {
        get { return _managerNavPoint; }
    }
    #endregion
}
