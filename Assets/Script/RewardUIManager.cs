using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardUIManager : MonoBehaviour
{
    //显示奖杯数的text
    [SerializeField] private Text trophySumText;
    //生成预制件的位置
    [SerializeField] private Transform ContentTransform;
    //预制件
    [SerializeField] private GameObject rewardBackGroud;
    //打开奖励的buttton
    [SerializeField] private Button openButton;
    //段位名Text
    [SerializeField] private Text rankNameText;
    
    //存放4000分以上预制件脚本对象
    private RewardPerfab[] rewardPerfab=new RewardPerfab[10];
    //现在杯数
    private int trophySum=6000;
    //杯数上限值
    private int trophySumMax = 6000;
    //4000分以上才有奖励
    private int trophySumMin = 4000;
    //num用于计数，计算总共生产多少个奖励
    private int num;
    private GameObject newGameObject;
    
    /// <summary>
    /// 打开点击事件
    /// 激活页面
    /// 调用生成预制件函数
    /// </summary>
    public void OpenClick()
    {
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
        if (trophySum >= trophySumMax)
        {
            return;
        }
        trophySum += 100;
        trophySumText.text = trophySum.ToString();
        RefreshRankLever();
        AddTrophyRefreshReward();
    }

    public void RefreshRankLever()
    {
        if (trophySum >= trophySumMin)
        {
            rankNameText.text = "段位一";
        }
        if (trophySum >= (trophySumMin+1000))
        {
            rankNameText.text = "段位二";
        }
    }
    /// <summary>
    /// 生产奖励预制件
    /// num用于计数，计算总共生产多少个奖励
    /// j用于计数，当i*200到达整千数时隐藏奖励
    /// </summary>
    //生产奖励预制件
    public void CreatePrefab()
    {
        num = (trophySumMax - trophySumMin) / 200;
        for (int i = 0,j = 1; i < num; i++,j++)
        {
            newGameObject = Instantiate(rewardBackGroud, ContentTransform);
            RewardPerfab rewardPerfabObject = newGameObject.GetComponent<RewardPerfab>();
            rewardPerfabObject.rankLever.text = ((i + 1) * 200 + trophySumMin).ToString();
            rewardPerfab[i] = rewardPerfabObject;
            if (j == 5)
            {
                rewardPerfabObject.CloseRewardButton();
                rewardPerfabObject.CloseRewardImageBlack();
                j = 0;
            }
            if (i * 200 > trophySum)
            {
                rewardPerfabObject.CloseRewardButton();
            }
        }
    }
    /// <summary>
    ///赛季更新
    /// 刷新4000分以上奖励
    /// 4000以上分数减半
    /// </summary>
    public void RefreshReward()
    {
        if (trophySum > trophySumMin)
        {
            trophySum = trophySumMin + (trophySum - trophySumMin) / 2;
        }
        trophySumText.text = trophySum.ToString();
        for (int i = 0; i < num; i++)
        {
            int conventTrophySum = 200 * (i + 1) + trophySumMin;
            //如果为整千数不刷新奖励
            if (conventTrophySum == 5000 || conventTrophySum == 6000)
            {
                continue;
            }
            if (trophySum >= conventTrophySum)
            {
                rewardPerfab[i].rewardButton.gameObject.SetActive(true);
            }
            else
            {
                rewardPerfab[i].rewardButton.gameObject.SetActive(false);
            }
        }

        RefreshRankLever();
    }
    /// <summary>
    /// 增加杯数刷新奖励
    /// </summary>
    public void AddTrophyRefreshReward()
    {
        for (int i = 0; i < num; i++)
        {
            int conventTrophySum = 200 * (i + 1) + trophySumMin;
            //如果为整千数不刷新奖励
            if (conventTrophySum == 5000 || conventTrophySum == 6000)
            {
                continue;
            }
            if (trophySum >= conventTrophySum)
            {
                rewardPerfab[i].rewardButton.gameObject.SetActive(true);
            }
        }
    }
    /// <summary>
    /// 初始化杯数
    /// 初始化激活状态
    /// </summary>
    void Start()
    {
        RefreshRankLever();
        trophySumText.text = trophySum.ToString();
        openButton.gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
