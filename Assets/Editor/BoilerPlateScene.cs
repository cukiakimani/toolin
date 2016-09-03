using UnityEngine;
using UnityEditor;
 
public class BoilerPlateScene
{
    [MenuItem("Tools/Set Up Boilerplate Scene")]
    private static void NewMenuOption()
    {
        var gamemanager = Resources.Load("GameManager") as GameObject;
        GameObject.Instantiate(gamemanager);
    }
}