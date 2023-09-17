using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalRange = 2.0f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0.0f, 0.0f);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Limit the X position between -2 and 2
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -horizontalRange, horizontalRange);
        transform.position = currentPosition;
    }
}