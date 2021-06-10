using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPerfab : MonoBehaviour
{
    //颜色亮和暗两种金币
    [SerializeField] private Button rewardButton;
    [SerializeField] private Image rewardImageBlack;
    //杯数text
    [SerializeField] private Text rankLever;
    //点击领取后将颜色亮一些的金币隐藏
    /// <summary>
    /// 初始化预制件信息，生成预制体，刷新赛季和增加杯数调用
    /// 根据传入的杯数判断是否能够领取奖励
    /// </summary>
    /// <param name="trophy"></param>
    public void InitPerfab(int trophy)
    {
        rankLever.text = trophy.ToString();
        rewardButton.gameObject.SetActive(true);
        rewardImageBlack.gameObject.SetActive(true);
        if (trophy % 1000 == 0)
        {
            CloseRewardImageBlack();
            CloseRewardButton();
        }
        if (CoinManager.Instance.GetTrophy() < trophy)
        {
            CloseRewardButton();
        }
    }
    
    //点击领取后将颜色亮一些的金币隐藏
    private void CloseRewardButton()
    {
        rewardButton.gameObject.SetActive(false);
    }
    //将颜色暗一些的金币隐藏
    private void CloseRewardImageBlack()
    {
        rewardImageBlack.gameObject.SetActive(false);
    }
    //领取金币的点击事件函数
    public void AddCoinSum()
    {
        CoinManager.Instance.AddCoin(100);
        GameObject.Find("backGround").GetComponent<RewardUIManager>().ShowCoinDiamond();
    }

}
