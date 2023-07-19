using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isDead = false;

    public Text scoreText;
    public int score = 0;


    private void Awake()
    {
        //�̱��� ���� instance�� ��� �ִ°�?
        if (instance == null)
        {
            //instance�� ��� �ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
            instance = this;
        }
        else
        {
            //instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���

            //���� �� �� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�
            //�̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int newScore)
    {
        if (!isDead)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }
}