using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, Time, Health }
    public InfoType type;

    Text myText;
    Slider mySlider;

    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();  
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManage.instance.exp;
                float maxExp = GameManage.instance.nextExp[GameManage.instance.level];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                myText.text = string.Format("LV. {0:F0}", GameManage.instance.level); 
                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManage.instance.kill);
                break;
            case InfoType.Time:
                float remainTime = GameManage.instance.maxGameTime - GameManage.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            case InfoType.Health:
                float curHealth = GameManage.instance.health;
                float maxHealth = GameManage.instance.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;
        }
    }
}
