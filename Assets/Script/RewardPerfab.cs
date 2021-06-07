using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPerfab : MonoBehaviour
{
    public GameObject rewardImage;
    public GameObject rewardImage2;
    public Text rankLever;
    private int trophySum = 6000;
    
    //点击领取后将颜色亮一些的金币隐藏
    public void closeRewardButton()
    {
        rewardImage.SetActive(false);
    }
    
    //将颜色暗一些的金币隐藏
    public void closeRewardButtonBackGround()
    {
        rewardImage2.SetActive(false);
    }
    
    //领取金币的点击事件函数
    public void addCoinSum()
    {
        CoinManager.Instance.addCoin();
    }
    // Start is called before the first frame update

}
