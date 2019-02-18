﻿using UnityEngine;
using NodeGraph.DataModel;
using BridgeUI.Model;
using BridgeUI.CodeGen;
using System.Collections.Generic;
namespace BridgeUI.Graph
{
    public abstract class PanelNodeBase : Node, IPanelInfoHolder
    {
        public int selected;
        public int instenceID;
        public string assetName;
        public int style = 1;
        public List<string> nodedescribe = new List<string>();
        public GenCodeRule rule;
        public List<ComponentItem> components = new List<ComponentItem>();
        public NodeInfo nodeInfo = new NodeInfo();
        public NodeInfo Info
        {
            get
            {
                return nodeInfo;
            }
        }
    }
}