using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpriteProperties
{
    public string SortingLayerName;
    public int SortingLayerOrder;
    public int SortingLayerIndex;
}

[ExecuteInEditMode]
public class MeshPlatform : MonoBehaviour
{
    public SpriteProperties Props;

    void Start()
    {
        
    }
    
    void Update()
    {
        Renderer renderer = GetComponent<MeshRenderer>().GetComponent<Renderer>();
        renderer.sortingLayerName = Props.SortingLayerName;
        renderer.sortingOrder = Props.SortingLayerOrder;
    }
}
