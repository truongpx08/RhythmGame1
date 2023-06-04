using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAddBoxesToLevelPool : BoxLevelPoolAbstract
{
    public void AddBoxesToLevelPool()
    {
        boxLevelPool._BoxLevelPool.Clear();
        for (int index = 0; index < 15; index++)
        {
            switch (index)
            {
                case 0:
                case 3:
                case 4:
                    AddBoxToPool(BoxName.ReverseBox);
                    break;
                case 1:
                    AddBoxToPool(BoxName.SpeedUpBox);
                    break;
                case 2:
                    AddBoxToPool(BoxName.SpeedDownBox);
                    break;
                case 5:
                    AddBoxToPool(BoxName.LockBox);
                    break;
                default:
                    AddBoxToPool(BoxName.NormalBox);
                    break;
            }
        }
    }


    protected void AddBoxToPool(string boxName)
    {
        if (CanAddBox(boxName))
            boxLevelPool._BoxLevelPool.Add(boxName);
    }

    protected bool CanAddBox(string targetBox)
    {
        var value = false;
        switch (targetBox)
        {
            case BoxName.NormalBox:
                value = true;
                break;
            case BoxName.ReverseBox:
                value = true;
                break;
            case BoxName.SpeedUpBox:
                value = TwoBall.Instance.TwoBallAbilities.TwoBallSpeedUp.Amount < 3;
                break;
            case BoxName.SpeedDownBox:
                value = TwoBall.Instance.TwoBallAbilities.TwoBallSpeedUp.Amount >
                        TwoBall.Instance.TwoBallAbilities.TwoBallSpeedDown.Amount &&
                        TwoBall.Instance.TwoBallAbilities.TwoBallSpeedDown.Amount < 3;
                break;
            case BoxName.LockBox:
                value = true;
                break;
        }

        return value;
    }
}