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
using System;
using BridgeUI.Model;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using BridgeUI.Binding;

namespace BridgeUI
{
    [PanelParent]
    public class PanelBase : PanelCore, IBindingContext
    {
        private Binding.PropertyBinder _binder;
        protected virtual Binding.PropertyBinder Binder
        {
            get
            {
                if (_binder == null)
                {
                    _binder = new Binding.PropertyBinder(this);
                }
                return _binder;
            }
        }
        [SerializeField, Attributes.DefultViewModel]
        private Binding.ViewModel _viewModel;
        private Binding.ViewModel _defultViewModel;
        protected Binding.ViewModel defultViewModel
        {
            get
            {
                if (_defultViewModel == null)
                {
                    _defultViewModel = ScriptableObject.CreateInstance<ViewModel>();
                }
                return _defultViewModel;
            }
        }
        public Binding.ViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
                OnViewModelChanged(_viewModel);
            }
        }

        protected override void Awake()
        {
            base.Awake();
            InitComponents();
            PropBindings();
            if (_viewModel != null){
                OnViewModelChanged(_viewModel);
            }
        }
        protected override void Start()
        {
            base.Start();
            if (bridge != null){
                bridge.OnCreatePanel(this);
            }
            AppendComponentsByType();
            OnOpenInternal();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            Binder.Unbind();
        }

        protected virtual void InitComponents() { }

        protected virtual void PropBindings() { }

        public virtual void OnViewModelChanged(Binding.ViewModel newValue)
        {
            Binder.Unbind();
            Binder.Bind(newValue);
        }

        protected override void HandleData(object data)
        {
            base.HandleData(data);

            if (data is Binding.ViewModel)
            {
                ViewModel = data as Binding.ViewModel;
            }
            else if (data is IDictionary)
            {
                var currentViewModel = ViewModel == null ? defultViewModel : ViewModel;
                LoadPropDictionary(currentViewModel, data as IDictionary);
                ViewModel = currentViewModel;
            }
        }
        protected virtual void LoadPropDictionary(ViewModel viewModel, IDictionary dataDic)
        {
            var keys = dataDic.Keys;
            foreach (var key in keys)
            {
                var value = dataDic[key];
                if (value != null)
                {
                    var prop = viewModel.GetBindablePropertySelfty(key.ToString(), value.GetType());
                    if (prop != null)
                    {
                        prop.ValueBoxed = value;
                    }
                }
            }
        }
    }
}