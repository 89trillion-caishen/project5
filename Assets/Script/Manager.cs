using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text trophy;
    public Transform ContentTransform;
    public GameObject rewardBackGroud;
    public GameObject backGround;
    public GameObject openButton;
    public Text rankname;
    private GameObject[] Prefab=new GameObject[10];
    private int trophySum=6000;
    GameObject newGameObject;
    //打开点击事件
    public void openClick()
    {
        openButton.SetActive(false);
        backGround.SetActive(true);
        createPrefab();
    }
    //领取奖励按钮点击事件
    //增加杯数
    public void increaseTrophyClick()
    {
        if (trophySum == 6000)
        {
            return;
        }
        trophySum += 100;
        trophy.text = trophySum.ToString();
    }

    //生产奖励预制件
    public void createPrefab()
    {
        int j = 0;
        for (int i = 0; i < 31; i++)
        {
            newGameObject = Instantiate(rewardBackGroud, ContentTransform);
            RewardPerfab rewardPerfabObject = newGameObject.GetComponent<RewardPerfab>();
            rewardPerfabObject.rankLever.text = (i * 200).ToString();
            if (i > 20)
            {
                Prefab[i - 21] = newGameObject;
            }
            if (j == 5)
            {
                rewardPerfabObject.closeRewardButton();
                rewardPerfabObject.closeRewardButtonBackGround();
                j = 0;
            }
            if (i * 200 > trophySum)
            {
                rewardPerfabObject.closeRewardButton();
            }
            j++;
        }
    }
    
    //赛季更新，刷新4000分以上奖励
    public void refreshPrefab()
    {
        if (trophySum > 4000)
        {
            trophySum /= 2;
        }
        trophy.text = trophySum.ToString();
        RewardPerfab rewardPerfabObject = new RewardPerfab();
        for (int i = 0; i < 10; i++)
        {
            if (i == 4||i==9) continue; 
            rewardPerfabObject = Prefab[i].GetComponent<RewardPerfab>();
            rewardPerfabObject.rewardImage.SetActive(true);
        }
    }
    void Start()
    {
        //初始化杯数
        trophy.text = trophySum.ToString();
        //初始化激活状态
        openButton.SetActive(true);
        backGround.SetActive(false);
    }
    //更新段位信息
    void Update()
    {
        if (trophySum >= 4000)
        {
            if(trophySum<5000)
            {
                rankname.text = "段位一";
            }
            else
            {
                rankname.text = "段位二";
            }
        }
        else
        {
            rankname.text = "";
        }
    }
}
