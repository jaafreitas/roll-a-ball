using UnityEngine;

public class Walls : MonoBehaviour
{
    private GameObject wallFolder;

    void CreateWall(string name, int px, int pz, float sx, float sz)
    {
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.name = name;
        wall.transform.SetParent(wallFolder.transform);
        wall.transform.localPosition = new Vector3(px, 0, pz);
        wall.transform.localScale = new Vector3(sx, 2.0f, sz);
    }

    void Start()
    {
        wallFolder = new GameObject();
        wallFolder.name = "Walls";

        CreateWall("North Wall", 0, 10, 20.5f, 0.5f);
        CreateWall("South Wall", 0, -10, 20.5f, 0.5f);
        CreateWall("East Wall", 10, 0, 0.5f, 20.5f);
        CreateWall("West Wall", -10, 0, 0.5f, 20.5f);
    }
}
