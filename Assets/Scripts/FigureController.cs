using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FigureController {

    [Inject]
    GameConfig _gameConfig;

    [Inject]
    FieldController _fieldController;

    private int figureCount;

    public GameObject[] controllerFigures { get; private set; }

    public bool IsClear {get; set;}

    public void CreateFigure()
    {

        controllerFigures = new GameObject[_gameConfig.Figures.Length];

        for (int i = 0; i < _gameConfig.FigureCount; i++)
        {
            controllerFigures[i] = GameObject.Instantiate(_gameConfig.Figures[Random.Range(0, _gameConfig.Figures.Length)], _fieldController._fields[i].transform.position, Quaternion.identity);
            controllerFigures[i].transform.localScale = _gameConfig.StartFigureScale;

            for (int j = 0; j < controllerFigures[i].transform.childCount - 1; j++)
            {
                controllerFigures[i].transform.GetChild(j).gameObject.AddComponent<BoxCollider2D>();
                controllerFigures[i].transform.GetChild(j).transform.tag = "Figure";
            }

            GameObject pivot = controllerFigures[i].transform.Find("Pivot").gameObject;

            //Debug.Log(_fieldController._fields[i].transform.position);

            pivot.transform.parent.position = controllerFigures[i].transform.position - pivot.transform.localPosition / 1.5f;

            //Debug.Log(pivot.transform.position);

            figureCount++;
        }
    }
}
