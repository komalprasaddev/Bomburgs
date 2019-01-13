using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileControllerScript))]
public class MapEditorScript : Editor { 

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TileControllerScript tiles = target as TileControllerScript;

        tiles.GenerateTiles();
    }

}
