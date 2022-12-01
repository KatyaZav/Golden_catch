using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Statistics 
{
    public static int GameCount { get; private set; }
    public static int LosePoints { get; private set;}
    
    /// <summary>
    /// End game and update record
    /// </summary>
    public static void EndGame()
    {
        if (GameCount > YG.YandexGame.savesData.RecordCount)
        {
            YG.YandexGame.savesData.RecordCount = GameCount;
            YG.YandexGame.SaveProgress();

            YG.YandexGame.NewLeaderboardScores("TopRecordCountPlayers", YG.YandexGame.savesData.RecordCount);
        }
        Debug.Log(YG.YandexGame.savesData.RecordCount);
        
        GameCount = 0;
        LosePoints = 0;
    } 

    public static Action<int> UpdateGameCount;
    public static void AddCount(int count)
    {
        GameCount += count;
        Debug.Log(GameCount);
        UpdateGameCount?.Invoke(count);
    }


    public static Action LosedPoint;
    public static void AddLosePoints()
    {
        LosePoints += 1;
        LosedPoint?.Invoke();
    }
}
