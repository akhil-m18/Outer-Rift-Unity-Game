using UnityEngine;

public class KamikazeEnemy : MonoBehaviour
{
    public float speed = 3f;
    public float acceleration = 2f;

    private Transform player;
    private float currentSpeed;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        currentSpeed = speed;
    }

    void Update()
    {
        if (player == null)
            return;

        Vector3 direction = (player.position - transform.position).normalized;

        currentSpeed += acceleration * Time.deltaTime;

        transform.position += direction * currentSpeed * Time.deltaTime;
    }
}