using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCamera : MonoBehaviour
{       
    public float offsetY = 0.0f;

    public float CameraSpeed = 10.0f;
    private float playerPosition = 0f;
    public GameObject player;

    private void Update()
    {
        playerPosition = (float)(player.transform.position.y + 5.0f);
        if (playerPosition + 0.4 >= offsetY+10.0f)
        {
            UpScreen();
        } else if(playerPosition < offsetY - 0.4) {
            DownScreen();
        }
    }

    public void UpScreen()
    {
        offsetY += 10.0f;

        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = new Vector3(0, offsetY, -10f);
    }
    public void DownScreen()
    {
        offsetY -= 10f;

        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = new Vector3(0, offsetY, -10f);
    }
}
