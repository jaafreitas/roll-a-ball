﻿using UnityEngine;

public class Scene : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject player;
    private Vector3 mainCameraOffset;

    void Start()
    {
        Camera();
        Ground();
        Walls();
        PickUps();
        Player();
    }

    void LateUpdate()
    {
        mainCamera.transform.position = player.transform.position + mainCameraOffset;
    }

    void Ground()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.localScale = new Vector3(2, 1, 2);

        Renderer rend = ground.GetComponent<MeshRenderer>();
        rend.material.color = new Color32(0, 32, 64, 255);
    }

    void Walls()
    {
        gameObject.AddComponent<Walls>();
    }

    void PickUps()
    {
        gameObject.AddComponent<PickUps>();
    }

    void Player()
    {
        player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        player.name = "Player";
        player.tag = Game.Tag.Player;
        player.AddComponent<Player>();
        mainCameraOffset = mainCamera.transform.position - player.transform.position;
    }

    void Camera()
    {
        mainCamera = new GameObject();
        mainCamera.name = "Main Camera";
        mainCamera.transform.localPosition = new Vector3(0, 10, -10);
        mainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);
        mainCamera.AddComponent<Camera>();
    }
}
