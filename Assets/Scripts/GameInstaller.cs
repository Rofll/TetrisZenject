using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller {

    [Inject]
    private GameConfig _gameConfig;

    public override void InstallBindings()
    {
        Container.Bind<FigurePositionController>().AsSingle();
        Container.Bind<BlockPositionController>().AsSingle();
        Container.Bind<FigureController>().AsSingle();
        Container.Bind<FieldController>().AsSingle();
        Container.Bind<TouchController>().AsSingle();

        Container.BindFactory<bool, BlockController, BlockController.BlockFabrick>().FromNewComponentOnNewPrefab(_gameConfig.BlockPrefab);
    }
}
