using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Basket : MonoBehaviour
{
    private bool _isActive = false;
    private GameManager _gameManager;

    public void SetActive()
    {
        GetComponent<Collider2D>().enabled = true;
        _gameManager = FindObjectOfType<GameManager>();
        _isActive = true;
    }

    private void Update()
    {
        if (_isActive)
        {
            var mouseXPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            transform.position = new Vector3(Mathf.Clamp(mouseXPosition, -7.5f, 7.5f), transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isActive)
        {
            if (collision.gameObject.TryGetComponent(out Apple apple))
            {
                Destroy(collision.gameObject);
                _gameManager.AddPoints(1);
            }
        }
    }
}
