﻿#region statement
/*************************************************************************************   
    * 作    者：       zouhunter
    * 时    间：       2018-07-09 07:34:53
    * 说    明：       
* ************************************************************************************/
#endregion
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using BridgeUI;
using BridgeUI.Control;
using System.Linq;

/// <summary>
/// MonoBehaiver
/// <summary>
public class ToolsPanel : ViewBaseComponent
{
    [SerializeField]
    private ToolContainer toolContainer;
    [SerializeField]
    private InputField surchField;
    private GameObject current;
    [SerializeField]
    private List<ToolData> toolDatas;
    
    public static void CollectTreeLeaf<T>(T root, ref List<T> leafs) where T : ModelTree
    {
        if (leafs == null) leafs = new List<T>();
        if ((root.childern == null || root.childern.Length == 0) && !leafs.Contains(root) )
        {
            leafs.Add(root);
        }
        else
        {
            foreach (var child in root.childern)
            {
                CollectTreeLeaf(child as T, ref leafs);
            }
        }
    }

    private void OnFliterChanged(string arg0)
    {
        if (string.IsNullOrEmpty(arg0))
        {
            toolContainer.tools = toolDatas;
        }
        else
        {
            var worpData = toolDatas.Where(x => x.title.Contains(arg0)).ToList();
            toolContainer.tools = worpData;
        }
    }

    protected override void OnInitialize()
    {
        surchField.onEndEdit.AddListener(OnFliterChanged);
        toolContainer.Initialize(this);
        OnFliterChanged(null);
    }

    protected override void OnRecover()
    {
        toolContainer.Recover();
    }
}
