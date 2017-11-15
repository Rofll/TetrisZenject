using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FieldController {

    [Inject]
    private BlockController.BlockFabrick _blockFabrick;

    [Inject]
    private GameConfig _gameConfig;

    public BlockController[] _fields { get; private set; }
    private int FieldCount = 0;

    public void BuildFields()
    {
        _fields = new BlockController[_gameConfig.FigureCount];

        for (int i = 0; i < _gameConfig.FigureCount; i++)
        {
            _fields[i] = _blockFabrick.Create(true);
            _fields[i].transform.position = _gameConfig.StartPosField + new Vector3(FieldCount * _gameConfig.DistanceBetweenFields, 0, 0);
            _fields[i].transform.localScale = _gameConfig.FieldScale;
            _fields[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            //_fields[i].gameObject.AddComponent<BoxCollider2D>();

            FieldCount++;
        }
    }
}
