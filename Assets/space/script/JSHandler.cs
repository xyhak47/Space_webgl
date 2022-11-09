using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class JSHandler : MonoBehaviour
{
    public static JSHandler Instance = null;
    private void Awake()
    {
        Instance = this;
    }

    [DllImport("__Internal")]
    private static extern void InitJS();

    [DllImport("__Internal")]
    private static extern void NikeShop();

    private void Start()
    {
        InitJS();
    }


    //test
    public Text log;


    public void onReceiveFromJS(string msg)
    {
        log.text = "onReceiveFromJS = " + msg;
    }

    public void Call_NikeShop()
    {
        NikeShop();
    }

}
