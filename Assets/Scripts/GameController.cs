using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour {

    [Inject]
    private FigurePositionController _figurePositionController;

    [Inject]
    private UIController _uIController;

    [Inject]
    private GameConfig _gameConfig;

    [Inject]
    private BlockController.BlockFabrick _blockFabrick;

    [Inject]
    private FigureController _figureController;

    [Inject]
    private FieldController _fieldController;

    [Inject]
    private TouchController _touchController;

    private void Start()
    {
        _uIController.HideGamePanel();
        CreateMesh();
        _fieldController.BuildFields();
        CreateFigures();
    }

    private void Update()
    {
        _touchController.MoveObjects();
    }

    public void Restart()
    {
        _uIController.HideGamePanel();
        CreateMesh();
    }

    private void CreateMesh()
    {
        float x = _gameConfig.StartPosBlockMesh.x;
        float y = _gameConfig.StartPosBlockMesh.y;

        for (int i = 0; i < _gameConfig.MeshY; i++)
        {
            for (int j = 0; j < _gameConfig.MeshX; j++)
            {
                var block = _blockFabrick.Create(true);
                block.transform.position = new Vector3(x, y, 0);
                block.transform.localScale = _gameConfig.MeshBlockScale;
                x += _gameConfig.DistanceBetweenBlocks;
                block.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                block.gameObject.AddComponent<BoxCollider2D>();
                block.transform.tag = "Block";
            }

            y += _gameConfig.DistanceBetweenBlocks;
            x = _gameConfig.StartPosBlockMesh.x; ;
        }
    }

    private void CreateFigures()
    {
        _figureController.CreateFigure();
    }
}
