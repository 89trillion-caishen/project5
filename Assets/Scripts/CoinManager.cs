using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//金币显示和更新的单例模式脚本
public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; set; }
    //初始金币数
    private int coinSum=4000;
    //现在杯数
    private int trophySum=6000;
    //4000分以上才有奖励
    private int trophySumMin = 4000;
    /// <summary>
    /// 内部调用更新coinSum方法
    /// </summary>
    /// <param name="num"></param>
    private void SetCoin(int num)
    {
        coinSum += num;
    }
    /// <summary>
    /// 外部调用更新SetCoin方法
    /// </summary>
    /// <param name="changeNum"></param>
    public void AddCoin(int addNum)
    {
        SetCoin(addNum);
    }
    /// <summary>
    /// 外部获取trophySum方法
    /// </summary>
    /// <returns></returns>
    public int GetCoin()
    {
        return coinSum;
    }
    /// <summary>
    /// 外部获取trophySum方法
    /// </summary>
    /// <returns></returns>
    public int GetTrophy()
    {
        return trophySum;
    }
    /// <summary>
    /// 外部调用更新trophySum方法
    /// </summary>
    /// <param name="changeNum"></param>
    public void ChangetrophySum(int changeNum)
    {
        SetTrophySum(changeNum);
    }
    /// <summary>
    /// 内部调用更新trophySum方法
    /// </summary>
    /// <param name="num"></param>
    private void SetTrophySum(int num)
    {
        trophySum += num;
    }
    
    /// <summary>
    /// 刷新赛季4000分以上部分减半
    /// </summary>
    public void RefreshTrophySum()
    {
        trophySum = (trophySum - trophySumMin) / 2 + trophySumMin;
    }
    
    private void Awake()
    {
        Instance = this;
    }
}
