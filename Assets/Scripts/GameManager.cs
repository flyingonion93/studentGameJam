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

    public LifeManager _lifeManager;
    public LifeManager LifeManager {
        get { return _lifeManager; }
    }

    public ShieldManager _shieldManager;
    public ShieldManager ShieldManager {
        get { return _shieldManager; }
    }

    public Squire _squire;
    public Squire Squire {
        get { return _squire; }
    }

    public Knight _knight;
    public Knight Knight {
        get { return _knight; }
    }

    public Shield _shield;

    public Shield Shield {
        get { return _shield; }
    }
    #endregion
}