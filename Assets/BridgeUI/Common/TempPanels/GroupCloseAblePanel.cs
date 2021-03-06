﻿#region statement
/*************************************************************************************   
    * 作    者：       zouhunter
    * 时    间：       2018-02-06 11:27:06
    * 说    明：       
* ************************************************************************************/
#endregion
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Sprites;
using UnityEngine.Scripting;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.Assertions.Must;
using UnityEngine.Assertions.Comparers;
using System.Collections;
using BridgeUI.Binding;
using System;

namespace BridgeUI
{
    /// <summary>
    /// 组面板[包含容器]
    /// </summary>
    public class GroupCloseAblePanel : GroupPanel
    {
        [SerializeField]
        protected Button m_close;

        protected override void OnInitialize()
        {
            if (m_close != null)
                m_close.onClick.AddListener(Close);
        }
        protected override void OnRecover()
        {
            if (m_close != null)
                m_close.onClick.RemoveListener(Close);
        }
    }
}