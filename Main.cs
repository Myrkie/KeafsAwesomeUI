using System.Collections.Generic;
using MelonLoader;
using UnityEngine;

namespace KeafsAwesomeUI
{
    public class Main : MelonMod
    {
        public static List<ToastContent> toastcontent = new List<ToastContent>();


        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (buildIndex == -1 && GameObject.Find("/UserInterface/UnscaledUI/HudContent/Hud/ToastBoi") == false)
                Toast.SetUp();
        }
    }
}