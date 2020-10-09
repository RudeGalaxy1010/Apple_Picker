using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Score = 0;
    public Text ScoreText;
    public List<Basket> Baskets = new List<Basket>();

    private Basket _currentBasket;

    private void Start()
    {
        _currentBasket = Baskets[0];
        _currentBasket.SetActive();

        AddPoints(0);
    }

    public void DestroBasket()
    {
        if (_currentBasket != null)
        {
            Baskets.Remove(_currentBasket);
            Destroy(_currentBasket.gameObject);
        }

        if (Baskets.Count > 0)
        {
            _currentBasket = Baskets[0];
            _currentBasket.SetActive();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddPoints(int points)
    {
        if (points >= 0)
        {
            Score += points;
            ScoreText.text = Score.ToString();
        }
    }
}
