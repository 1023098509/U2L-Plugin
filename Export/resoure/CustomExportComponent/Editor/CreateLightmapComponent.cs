using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateLightmapComponent
{
    [MenuItem("LayaAir3D 3.0/CreateLightmapComponent")]
    static void Create()
    {
        var lightmaps = LightmapSettings.lightmaps;

        var containerGo = GameObject.Find("lightmapContainer");
        if (containerGo == null)
        {
            containerGo = new GameObject("lightmapContainer");
        }

        if (!containerGo.TryGetComponent<LightmapContainer>(out var container))
        {
            container = containerGo.AddComponent<LightmapContainer>();
        }

        container.lightmapColorTextures.Clear();
        foreach (var item in lightmaps)
        {
            container.lightmapColorTextures.Add(item.lightmapColor);
        }


        LightmapInfo[] lightmapInfos = UnityEngine.Object.FindObjectsOfType<LightmapInfo>();
        foreach (LightmapInfo lightmapInfo in lightmapInfos)
        {
            lightmapInfo.index = -1;
            lightmapInfo.offset = Vector4.zero;
        }

        MeshRenderer[] meshRenderers = UnityEngine.Object.FindObjectsOfType<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            if (meshRenderer.lightmapIndex != -1)
            {
                var go = meshRenderer.gameObject;
                if (!go.TryGetComponent<LightmapInfo>(out var info))
                {
                    info = go.AddComponent<LightmapInfo>();
                }

                info.index = meshRenderer.lightmapIndex;
                info.offset = meshRenderer.lightmapScaleOffset;
            }
        }

    }


}
