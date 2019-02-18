﻿#region statement
/*************************************************************************************   
    * 作    者：       zouhunter
    * 时    间：       2018-04-29 11:58:11
    * 说    明：       
* ************************************************************************************/
#endregion
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using BridgeUI;

/// <summary>
/// MonoBehaiver
/// <summary>
public class LuaRuntime : UnityEngine.MonoBehaviour {
    public TextAsset luaScript;
    void OnGUI()
    {
        if (GUILayout.Button("Open LuaPanel01 Defult"))
        {
            UIFacade.Instence.Open("LuaPanel01");
        }

        if (GUILayout.Button("Open LuaPanel01 With String (load from string!)"))
        {
            UIFacade.Instence.Open("LuaPanel01", luaScript.text);
        }
        
        if(GUILayout.Button("Open LuaPanel02 Defult"))
        {
            UIFacade.Instence.Open("LuaPanel02");
        }
    }
}
