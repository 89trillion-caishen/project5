using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//金币显示和更新的单例模式脚本
public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; set; }
    private int coinsum=4000;
    public Text coinSum;
    // Start is called before the first frame update
    void Start()
    {
        coinSum.text = coinsum.ToString();
    }
    
    
    //领取奖励后更新金币数
    public void addCoin()
    {
        coinsum += 100;
        coinSum.text = coinsum.ToString();
    }

    private void Awake()
    {
        Instance = this;
    }
}
