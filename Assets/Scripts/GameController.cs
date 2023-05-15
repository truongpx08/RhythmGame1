using System;
using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    private new Camera camera;
   [SerializeField] private GameConfig config;

   private void Start()
   {
       // Distributed
       HoopController.Instance.Init(config);
       ObjectController.Instance.Init(config);
   }

   [Button]
    public void Play()
    {
        ObjectController.Instance.OnPlay();
        HoopController.Instance.OnPlay();
    }
}

[Serializable]
public class GameConfig
{
    public float maxSpeed, minSpeed, requiteSpacing, requiteDistance, hoopSpacing;
    public int  hoopAmount;
    public bool isIncreaseSpeed;
}