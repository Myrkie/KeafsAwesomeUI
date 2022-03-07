using System.IO;
using System.Reflection;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace KeafsAwesomeUI
{
    public static class AssetManager
    {
        internal static GameObject _toastyboi;
        private static AssetBundle _assetBundle;

        internal static void LoadAssetBundle()
        {
            using (var stream = Assembly.GetExecutingAssembly()
                       .GetManifestResourceStream("KeafsAwesomeUI.EmbeddedResources.toastnotifications.toastyboi"))
                if (stream != null)
                    using (var tempStream = new MemoryStream((int) stream.Length))
                    {
                        stream.CopyTo(tempStream);

                        _assetBundle = AssetBundle.LoadFromMemory_Internal(tempStream.ToArray(), 0);
                        _assetBundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    }

            _toastyboi = _assetBundle
                .LoadAsset("assets/toasts menu/ToastNotification.prefab", Il2CppType.Of<GameObject>())
                .Cast<GameObject>();
            _toastyboi.hideFlags |= HideFlags.DontUnloadUnusedAsset;

        }

        // yoinked from https://github.com/loukylor/VRC-Mods/tree/main/PlayerList
        public static void SetLayerRecursive(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            foreach (var child in gameObject.transform)
                SetLayerRecursive(child.Cast<Transform>().gameObject, layer);
        }

    }
}