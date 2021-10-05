using System.Collections;
using System.Collections.Generic;
using MelonLoader;
using UnityEngine;

namespace KeafsAwesomeUI
{
    public class KeafUI : MelonMod
    {
        public static List<ToastContent> toastcontent = new List<ToastContent>() { new ToastContent
            { Title = "Keaf's Awesome UI Helper", Content = "Finished initializing Ui" }};

        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(WaitForLocalPlayer());
        }
        private IEnumerator WaitForLocalPlayer()
        {
            while (VRCPlayer.field_Internal_Static_VRCPlayer_0 == null)
                yield return null;
            Toast.SetUp();
        }
    }
}