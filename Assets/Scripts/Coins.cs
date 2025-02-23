using UnityEngine;

public class Coins : MonoBehaviour
{
    public float speed;
    public int scoreValue = 10;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
