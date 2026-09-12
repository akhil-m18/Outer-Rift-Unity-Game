using UnityEngine;

public class KamikazeExplosion : MonoBehaviour
{
    public GameObject explosionPrefab;

    private bool exploded = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (exploded)
            return;

        if (other.CompareTag("Player"))
        {
            exploded = true;

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}