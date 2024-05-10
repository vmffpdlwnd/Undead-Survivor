using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage instance;
    public Player player;

    private void Awake()
    {
        instance = this;
    }
}
