using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BlockController : MonoBehaviour {

    [Inject]
    public bool IsFree { get; set; }


    public class BlockFabrick : Factory<bool ,BlockController>
    {

    }
}
