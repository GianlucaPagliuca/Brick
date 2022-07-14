using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI scoreText;
    public GameObject brick;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        SetupBricks();
    }

    public void UpdateScore(int ammount)
    {
        score += ammount;
    }

    private void SetupBricks()
    {
        for (int i = 2; i <= 3; i++)
        {
            for (int j = -7; j <= 7; j++)
            {
                Instantiate(brick, new Vector3(j + 0.5f, i + 0.5f), new Quaternion(0, 0, 0, 0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
