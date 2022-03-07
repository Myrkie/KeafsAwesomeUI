using System.Collections;
using System.Linq;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace KeafsAwesomeUI
{
    internal class Toast
    {
        private static CanvasGroup leCanvasGroup;
        private static Text Msg;
        private static Text TitleText;
        private static readonly float DurationOnScreen = 2f; //duration of how long till fade off
        private static readonly float DurationOfFade = 2f; // how long should alpha of canvas group to turn from 0 to 1

        internal static void SetUp()
        {
            GameObject ToastBoi = Object.Instantiate(AssetManager._toastyboi, GameObject.Find("/UserInterface/UnscaledUI/HudContent").transform);
            ToastBoi.name = "ToastBoi";
            ToastBoi.SetLayerRecursive(19);
            ToastBoi.GetComponent<RectTransform>().anchoredPosition = new Vector3(1.6393f, -427.0597f, 0);

            leCanvasGroup = ToastBoi.AddComponent<CanvasGroup>();
            leCanvasGroup.alpha = 0f;

            TitleText = ToastBoi.transform.Find("ToastUITitle").GetComponent<Text>();
            TitleText.alignment = TextAnchor.MiddleCenter;

            GameObject Message = ToastBoi.transform.Find("ToastText").gameObject;
            Message.name = "Message";
            Msg = Message.GetComponent<Text>();
            Msg.alignment = TextAnchor.MiddleCenter;
            MelonCoroutines.Start(LoopDeLoopCheck());
            
        }

        private static IEnumerator LoopDeLoopCheck()
        {
            for (;;)
            {
                if (KeafUI.toastcontent.Count != 0)
                {
                    var toastvalues = KeafUI.toastcontent.First();
                    TitleText.text = toastvalues.Title;
                    Msg.text = toastvalues.Content;
                    KeafUI.toastcontent.Remove(toastvalues);
                    yield return Fade(leCanvasGroup, 0f, 1f, DurationOfFade);
                    yield return new WaitForSeconds(DurationOnScreen);
                    yield return Fade(leCanvasGroup, 1f, 0f, DurationOfFade);
                }

                yield return new WaitForEndOfFrame();
            }
        }

        private static IEnumerator Fade(CanvasGroup zeCanvasgroup, float startAlpha, float endAlpha, float fadeDuration)
        {
            float startTime = Time.time;
            float alpha = startAlpha;

            if (fadeDuration > 0f)
                while (alpha != endAlpha)
                {
                    alpha = Mathf.Lerp(startAlpha, endAlpha, (Time.time - startTime) / fadeDuration);
                    zeCanvasgroup.alpha = alpha;

                    yield return null;
                }

            zeCanvasgroup.alpha = endAlpha;
        }
    }
}