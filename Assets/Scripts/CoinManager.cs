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
    //金币的UI Text
    [SerializeField] private Text coinSumText;
    //public int trophySum = 6000;
    
    //初始化金币数
    void Start()
    {
        coinSumText.text = coinSum.ToString();
    }
    
    //领取奖励后更新金币数
    public void AddCoin()
    {
        coinSum += 100;
        coinSumText.text = coinSum.ToString();
    }

    private void Awake()
    {
        Instance = this;
    }
}
