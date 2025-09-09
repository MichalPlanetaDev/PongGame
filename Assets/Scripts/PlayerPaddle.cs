using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public float speed = 8f;
    private float clampY = 4.5f;

    private void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            move = 1f;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            move = -1f;

        Vector3 nextPos = transform.position + Vector3.up * move * speed * Time.deltaTime;

        nextPos.y = Mathf.Clamp(nextPos.y, -clampY, clampY);

        transform.position = nextPos;
    }
}