using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [field:SerializeField] public Transform[] path { get; private set; }
}
