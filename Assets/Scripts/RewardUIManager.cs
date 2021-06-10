using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardUIManager : MonoBehaviour
{
    //金币的UI Text
    [SerializeField] private Text coinSumText;
    //显示奖杯数的text
    [SerializeField] private Text trophySumText;
    //生成预制件的位置
    [SerializeField] private Transform contentTransform;
    //预制件
    [SerializeField] private RewardPerfab rewardBackGroud;
    private RewardPerfab[] rewardPerfab=new RewardPerfab[10];
    //打开奖励的buttton
    [SerializeField] private Button openButton;
    //段位名Text
    [SerializeField] private Text rankNameText;

    [SerializeField] private Image backGround;
    //杯数上限值
    private int trophySumMax = 6000;
    //4000分以上才有奖励
    private int trophySumMin = 4000;
    //num用于计数，计算总共生产多少个奖励
    private int num;
    
    /// <summary>
    /// 打开点击事件
    /// 激活页面
    /// 调用生成预制件函数
    /// </summary>
    public void OpenClick()
    {
        ShowCoinDiamond();
        RefreshRankLever();
        openButton.gameObject.SetActive(false);
        transform.gameObject.SetActive(true);
        CreatePrefab();
    }
    /// <summary>
    /// 领取奖励按钮点击事件
    /// 增加杯数
    /// 调用更新段位函数
    /// 调用更新奖励函数
    /// </summary>
    public void IncreaseTrophyClick()
    {
        if (CoinManager.Instance.GetTrophy() >= trophySumMax)
        {
            return;
        }
        CoinManager.Instance.ChangetrophySum(100);
        trophySumText.text = CoinManager.Instance.GetTrophy().ToString();
        RefreshRankLever();
        for (int i = 0; i < num; i++)
        {
            rewardPerfab[i].InitPerfab((i + 1) * 200 + trophySumMin);
        }
    }
    
    /// <summary>
    /// 刷新段位
    /// </summary>
    public void RefreshRankLever()
    {
        if (CoinManager.Instance.GetTrophy() >= trophySumMin)
        {
            rankNameText.text= "段位"+((CoinManager.Instance.GetTrophy() - trophySumMin)/1000+1);
        }
    }
    /// <summary>
    /// 生产奖励预制件
    /// 调用Init()方法，传递参数
    /// </summary>
    //生产奖励预制件
    public void CreatePrefab()
    {
        for (int i = 0; i < num; i++)
        {
            rewardPerfab[i] = Instantiate(rewardBackGroud, contentTransform);
            rewardPerfab[i].InitPerfab((i + 1) * 200 + trophySumMin);
        }
    }
    /// <summary>
    ///赛季更新
    /// 刷新4000分以上奖励
    /// 4000以上分数减半
    /// 调用预置体的初始化方法刷新奖励
    /// </summary>
    public void RefreshReward()
    {
        if (CoinManager.Instance.GetTrophy() > trophySumMin)
        {
            CoinManager.Instance.RefreshTrophySum();
        }
        trophySumText.text = CoinManager.Instance.GetTrophy().ToString();
        for (int i = 0; i < num; i++)
        {
            rewardPerfab[i].InitPerfab((i + 1) * 200 + trophySumMin);
        }
        RefreshRankLever();
    }
    /// <summary>
    /// 更新展示金币和杯数
    /// </summary>
    public void ShowCoinDiamond()
    {
        coinSumText.text = CoinManager.Instance.GetCoin().ToString();
        trophySumText.text = CoinManager.Instance.GetTrophy().ToString();
    }
    /// <summary>
    /// 计算需要的预制件个数
    /// 初始化杯数
    /// 初始化段位信息
    /// 初始化激活状态
    /// </summary>
    void Start()
    {
        num = (trophySumMax - trophySumMin) / 200;
        openButton.gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
