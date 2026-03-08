using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}

