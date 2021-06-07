using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject currentBall;

    public int playerOneScore;
    public int playerTwoScore;

    [SerializeField] private TMP_Text _playerOneScoreText, _playerTwoScoreText;


    public void ResetBoard()
    {
        currentBall.transform.position = Vector2.zero;
        currentBall.GetComponent<Ball>().NewBall();
    }

    public void AddPoint(int player)
    {
        if (player == 1)
        {
            playerTwoScore++;
            _playerTwoScoreText.text = playerTwoScore.ToString();
        }
        else
        {
            playerOneScore++;
            _playerOneScoreText.text = playerOneScore.ToString();
        }

    }
}
