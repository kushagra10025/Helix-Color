using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public LevelGeneration levelGeneration;
    private void Start()
    {
        levelGeneration.LevelStartBasics();
    }
}
