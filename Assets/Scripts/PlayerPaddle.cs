using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public float speed = 8f;

    private void Update()
    {
        float move = 0f;

        // Allow player to play W/S and Arrow keys
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            move = 1f;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            move = -1f;

        transform.Translate(Vector2.up * move * speed * Time.deltaTime);
    }
}