using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VideoPlayerUIInterface {

    [MenuItem("GameObject/UI/ThomasBisson VideoPlayer", false, 0)]
    static void Init()
    {
        GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Settings/ThomasBissonPack/MenuEditor/Prefabs/UI/VideoPlayerBackground.prefab", typeof(GameObject)), Selection.activeGameObject.transform);
    }
}
