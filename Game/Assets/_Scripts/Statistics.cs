using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class Statistics 
{  
    public static int GameCount { get; private set; }
    public static int LosePoints { get; private set;}

    public static int GoldPower;

    /// <summary>
    /// Проверка на то, что после поражения была использована реклама для второй жизни.
    /// </summary>
    public static bool HelpVideoEndGet = false;
    
    /// <summary>
    /// End game and update record
    /// </summary>
    public static void EndGame()
    {
        if (GameCount > 5)
            YG.YandexGame.savesData.isGetGold = true;

        if (!YG.YandexGame.savesData.isWasGame)
            YG.YandexGame.savesData.isWasGame = true;

        if (GameCount > YG.YandexGame.savesData.RecordCount)
        {
            YG.YandexGame.savesData.RecordCount = GameCount;
            YG.YandexGame.SaveProgress();

            YG.YandexGame.NewLeaderboardScores("TopRecordCountPlayers", YG.YandexGame.savesData.RecordCount);
        }
        //Debug.Log(YG.YandexGame.savesData.RecordCount);
        
        GameCount = 0;
        LosePoints = 0;
    } 

    public static Action<int> UpdateGameCount;
    public static void AddCount(int power, int count)
    {
        if (power > 0)
            GameCount += power;
        
        //Debug.Log(GameCount);
        UpdateGameCount?.Invoke(count);
    }


    public static Action LosedPoint;
    public static void AddLosePoints()
    {
        LosePoints += 1;
        LosedPoint?.Invoke();
    }
}
