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

    private GameObject Prefab1;
    private GameObject Prefab2;
    private GameObject Prefab3;
    private GameObject Prefab4;
    private GameObject Prefab5;
    private GameObject Prefab6;
    private GameObject Prefab7;
    private GameObject Prefab8;
    
    private int coinsum=4000;

    private int trophySum=6000;
    GameObject newGameObject;
    //关闭点击事件
    public void closeClick()
    {
        openButton.SetActive(true);
        backGround.SetActive(false);
    }
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
    //刷新赛季
    public void refresh()
    {
        //杯数减半
        
        // 重新生生成预置件
    }
    
    //生产奖励预制件
    public void createPrefab()
    {
        int j = 0;
        for (int i = 0; i < 31; i++)
        {
            newGameObject = Instantiate(rewardBackGroud, ContentTransform);
            RewardPerfab r = newGameObject.GetComponent<RewardPerfab>();
            r.rankLever.text = (i * 200).ToString();
            if (i > 20)
            {
                if (i == 21)
                {
                    Prefab1 = newGameObject;
                }
                if (i == 22)
                {
                    Prefab2 = newGameObject;
                }
                if (i == 23)
                {
                    Prefab3 = newGameObject;
                }
                if (i == 24)
                {
                    Prefab4 = newGameObject;
                }
                if (i == 26)
                {
                    Prefab5 = newGameObject;
                }
                if (i == 27)
                {
                    Prefab6 = newGameObject;
                }
                if (i == 28)
                {
                    Prefab7 = newGameObject;
                }
                if (i == 29)
                {
                    Prefab8 = newGameObject;
                }
            }
            if (j == 5)
            {
                r.closeRewardButton();
                r.closeRewardButtonBackGround();
                j = 0;
            }
            if (i * 200 > trophySum)
            {
                r.closeRewardButton();
            }
            j++;
        }
    }
    public void refreshPrefab()
    {
        if (trophySum > 4000)
        {
            trophySum /= 2;
        }
        trophy.text = trophySum.ToString();
        RewardPerfab r = Prefab1.GetComponent<RewardPerfab>();
        r.rewardImage.SetActive(true);
        r= Prefab2.GetComponent<RewardPerfab>();
        r.rewardImage.SetActive(true);
        r= Prefab3.GetComponent<RewardPerfab>();
        r.rewardImage.SetActive(true);
        r= Prefab4.GetComponent<RewardPerfab>();
        r.rewardImage.SetActive(true);
        r= Prefab5.GetComponent<RewardPerfab>();
        r.rewardImage.SetActive(true);
        r= Prefab6.GetComponent<RewardPerfab>();
        r.rewardImage.SetActive(true);
        r= Prefab7.GetComponent<RewardPerfab>();
        r.rewardImage.SetActive(true);
        r= Prefab8.GetComponent<RewardPerfab>();
        r.rewardImage.SetActive(true);
    }
    void Start()
    {
        //初始化杯数
        trophy.text = trophySum.ToString();

        openButton.SetActive(true);
        backGround.SetActive(false);
    }

    // Update is called once per frame
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
