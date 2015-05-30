using UnityEngine;
using System.Collections;

public class GameManager : osSingleton<GameManager> {

    protected GameManager () { }

    public GameManager _manager;

    #region Handlers
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

    public GUIManager _guiManager;

    public GUIManager Manager {
        get { return _guiManager; }
    }

    public TimeManager _timeManager;

    public TimeManager TimeManager {
        get { return _timeManager; }
    }

    public SoundManager _soundManager;
    public SoundManager SoundManager {
        get { return _soundManager; }
    }

    //public SceneManager _sceneManager;
    //public SceneManager SceneManager {
    //    get { return _sceneManager; }
    //}
    #endregion
}