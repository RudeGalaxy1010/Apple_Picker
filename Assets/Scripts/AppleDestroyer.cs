using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AppleDestroyer : MonoBehaviour
{
    public GameManager GameManager;
    public int AppleCounter = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Apple apple))
        {
            Destroy(collision.gameObject);
            AppleCounter++;

            if (AppleCounter > 2)
            {
                GameManager.DestroBasket();
                AppleCounter = 0;
            }
        }
    }
}
