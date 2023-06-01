using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CompleteCkecker : PassABoxChecker
{
    [SerializeField] protected GameLoop gameLoop;
    [SerializeField] protected GameOver gameOver;
    [SerializeField] private bool isTest;

    protected override void ResetValue()
    {
        base.ResetValue();
        isTest = false;
    }

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
        var ballRotating = TwoBall.Instance.GetBallRotating();
        var targetBox = BoxHolder.Instance.BoxHolderTargetBox.TargetBox;
        if (!IsPassABox(ballRotating, targetBox) && !isTest)
        {
            gameOver.OverGame();
            return;
        }

        gameLoop.LoopGame(ballRotating, targetBox);
    }
}