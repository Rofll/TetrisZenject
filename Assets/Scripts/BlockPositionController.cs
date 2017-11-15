using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BlockPositionController {

    [Inject]
    GameConfig _gameConfig;

    private int _posCounterX;
    private int _posCounterY;

    public Vector3 GetNewPos()
    {
        _posCounterX++;
        _posCounterY++;

        return _gameConfig.StartPosBlockMesh + new Vector3(_posCounterX * _gameConfig.DistanceBetweenBlocks, _posCounterY * _gameConfig.DistanceBetweenBlocks, 0);
    }

    public void Reset()
    {
        _posCounterX = 0;
        _posCounterY = 0;
    }

}
