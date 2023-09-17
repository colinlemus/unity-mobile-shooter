using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public Vector3 moveDirection = new Vector3(1f, 0f, 0f);
    public float speed = 1.0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            other.transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
    }
}