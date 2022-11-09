using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class NikeShop : MonoBehaviour
{
    public void NikeShop_Open()
    {
        JSHandler.Instance.Call_NikeShop();
    }
}
