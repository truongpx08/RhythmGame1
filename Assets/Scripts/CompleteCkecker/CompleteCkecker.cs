﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CompleteCkecker : TruongMonoBehaviour
{
    [SerializeField] protected GameLoop gameLoop;
    [SerializeField] protected GameOver gameOver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadGameLoop();
        LoadGameOver();
    }

    private void LoadGameLoop()
    {
        gameLoop = transform.Find("GameLoop").GetComponent<GameLoop>();
    }

    private void LoadGameOver()
    {
        gameOver = transform.Find("GameOver").GetComponent<GameOver>();
    }

    private void Update()
    {
        if (!InputManager.Instance.IsKeyDown) return;
        CheckComplete();
    }

    protected void CheckComplete()
    {
        var twoBall = TwoBall.Instance;
        var ballRotating = twoBall.Ball1.BallAutoRotateAroundCenter.IsRotating ? twoBall.Ball1 : twoBall.Ball2;
        var targetBox = BoxHolder.Instance.BoxHolderSetTargetBox.TargetBox;
        if (IsPassABox(ballRotating, targetBox))
        {
            gameLoop.LoopGame(ballRotating, targetBox);
        }
        else
        {
            gameOver.OverGame();
        }
    }

    protected bool IsPassABox(Ball ballRotating, Box targetBox)
    {
        Vector3 ballPosition = ballRotating.transform.position;
        Vector3 boxPosition = targetBox.transform.position;
        return Vector3.Distance(ballPosition, boxPosition) < PlayController.Instance.Config.distanceLimit;
    }
}