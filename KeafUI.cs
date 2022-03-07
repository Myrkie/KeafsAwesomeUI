using System;
using System.Collections;
using System.Collections.Generic;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core;
using Object = UnityEngine.Object;

namespace KeafsAwesomeUI
{
    public class KeafUI : MelonMod
    {
        public static List<ToastContent> toastcontent = new List<ToastContent>() { new ToastContent
            { Title = "Keaf's Awesome UI Helper", Content = "Finished initializing Ui" }};

        public override void OnApplicationStart()
        {
            AssetManager.LoadAssetBundle();
        }
        private int _scenesLoaded;
        public override void OnSceneWasLoaded(int level, string name)
        {
            if (_scenesLoaded <= 2)
            {
                _scenesLoaded++;
                if (_scenesLoaded == 2)
                {
                    Toast.SetUp();
                }
            }
        }
    }
}