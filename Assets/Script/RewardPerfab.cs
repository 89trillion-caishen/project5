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
    private Manager M = new Manager();
    public void closeRewardButton()
    {
        rewardImage.SetActive(false);
    }
    public void closeRewardButtonBackGround()
    {
        rewardImage2.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
