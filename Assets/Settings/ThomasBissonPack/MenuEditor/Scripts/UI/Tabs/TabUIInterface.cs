using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TabUIInterface{

    [MenuItem("GameObject/UI/ThomasBisson Tab", false, 0)]
    static void Init()
    {
        GameObject.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Settings/ThomasBissonPack/MenuEditor/Prefabs/UI/TabBackground.prefab", typeof(GameObject)), Selection.activeGameObject.transform);
    }

}
