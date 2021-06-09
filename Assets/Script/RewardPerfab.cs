using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPerfab : MonoBehaviour
{
    //颜色亮和暗两种金币
    public Button rewardButton;
    public Image rewardImageBlack;
    //杯数text
    public Text rankLever;

    //点击领取后将颜色亮一些的金币隐藏
    public void CloseRewardButton()
    {
        rewardButton.gameObject.SetActive(false);
    }
    
    //将颜色暗一些的金币隐藏
    public void CloseRewardImageBlack()
    {
        rewardImageBlack.gameObject.SetActive(false);
    }
    
    //领取金币的点击事件函数
    public void AddCoinSum()
    {
        CoinManager.Instance.AddCoin();
    }

}
