using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Texture2D cursorTexture;

    private Vector2 cursorHotspot;

    [SerializeField]
    private Text getReadyText;

    [SerializeField]
    private GameObject resultsPanel;

    [SerializeField]
    private Text scoreText, targetHitText, shotsFiredtext, accuracyText;

    public static int score, targethit;

    private float shotsFired;

    private float accuracy;

    private int targetAmount;

    private Vector2 targetRandomPosition;

    private void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture,cursorHotspot, CursorMode.Auto);

        getReadyText.gameObject.SetActive(false);

        targetAmount = 50;
        score = 0;
        shotsFired = 0;
        targethit = 0;
        accuracy = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shotsFired += 1f;
        }
    }

    private IEnumerable Getready()
    {
        for (int i = 3; i >=1; i--)
        {
            getReadyText.text = "Get Ready!\n"+ i.ToString();
            yield return new WaitForSeconds(1f);
        }

        getReadyText.text = "Go!\n";
        yield return new WaitForSeconds(1f);

        StartCoroutine("SpawnTargets");
    }

    private IEnumerable SpawnTargets()
    {
        getReadyText.gameObject.SetActive (false);
        score = 0;
        shotsFired = 0;
        targethit=0;
        accuracy = 0;

        for (int i = targetAmount; i >=0; i--)
        {
            targetRandomPosition = new Vector2(Random.Range(-7f, 7f), Random.Range(-4f, 4f));
            Instantiate(target, targetRandomPosition, Quaternion.identity);

            yield return new WaitForSeconds(1f);
        }

        resultsPanel.SetActive (true);
        scoreText.text = "Score: " + score;
        targetHitText.text = "Targets Hit: " + targethit + "/" + targetAmount;
        shotsFiredtext.text = "Shots fired: " + shotsFired;
        accuracy = targethit / shotsFired * 100f;
        accuracyText.text = "Accuracy: " + accuracy.ToString("N2") + "%";
    }

    public void StartgetReadyCoroutine()
    {
        resultsPanel.SetActive (false);
        getReadyText.gameObject .SetActive (true);
        StartCoroutine("GetReady!");
    }
}
