using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FigurePositionController {

    [Inject]
    GameConfig _gameConfig;

    private int _posCounter;

    public Vector3 GetNewPos()
    {
        _posCounter++;
        return _gameConfig.StartPosFigure + new Vector3(_posCounter * _gameConfig.DistanceBetweenFigures, 0, 0);
    }

    public void Reset()
    {
        _posCounter = 0;
    }
}
