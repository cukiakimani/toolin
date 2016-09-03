#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

[ExecuteInEditMode]
public class GridTilingTool : MonoBehaviour
{
    public float Width;
    public float Height;
    public Color Color = Color.white;
    public bool DrawGrid;
    public bool Snap;

    void Start()
    { 
        if (!Application.isPlaying)
        {
            SceneView.onSceneGUIDelegate -= GridUpdate;
            SceneView.onSceneGUIDelegate += GridUpdate;
        }
    }

    void OnEnable()
    { 
        if (!Application.isPlaying)
        {
            SceneView.onSceneGUIDelegate -= GridUpdate;
            SceneView.onSceneGUIDelegate += GridUpdate;
        }
    }

    void GridUpdate(SceneView sceneView)
    {
        Event e = Event.current;

        if (!Snap)
            return;

        if (e.type == EventType.MouseUp)
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
	                switch (Tools.current)
	                {
	                    case Tool.Move:
	                        SnapObject(obj.transform);
	                        break;
	                }
            }
        }
    }

    void SnapObject(Transform t)
    {
            t.position = SnapVector(t.position);
    }

    public Vector3 SnapVector(Vector3 snapVector)
    {
        var x1 = Mathf.Floor(snapVector.x / Width) * Width;
        var x2 = Mathf.Ceil(snapVector.x / Width) * Width;

        var y1 = Mathf.Floor(snapVector.y / Height) * Height;
        var y2 = Mathf.Ceil(snapVector.y / Height) * Height;

        var x = Mathf.Abs(snapVector.x - x1) < Mathf.Abs(snapVector.x - x2) ? x1 : x2;
        var y = Mathf.Abs(snapVector.y - y1) < Mathf.Abs(snapVector.y - y2) ? y1 : y2;

        return new Vector3(x, y, snapVector.z);
    }

    void OnDestroy()
    {
        if (!Application.isPlaying)
            SceneView.onSceneGUIDelegate -= GridUpdate;
    }

    void OnDrawGizmos()
    {
        if (!DrawGrid || Application.isPlaying)
            return;

        Vector3 pos = Camera.current.transform.position;
        Gizmos.color = Color;
        
        for (float y = pos.y - 80000.0f; y < pos.y + 80000.0f; y += Height)
        {
            Gizmos.DrawLine(new Vector3(-1000000.0f, Mathf.Floor(y / Height) * Height, 0.0f),
                new Vector3(1000000.0f, Mathf.Floor(y / Height) * Height, 0.0f));
        }
    
        for (float x = pos.x - 120000.0f; x < pos.x + 120000.0f; x += Width)
        {
            Gizmos.DrawLine(new Vector3(Mathf.Floor(x / Width) * Width, -1000000.0f, 0.0f),
                new Vector3(Mathf.Floor(x / Width) * Width, 1000000.0f, 0.0f));
        }
    }
}
#endif