using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class GameController : MonoBehaviour
{
    public PenguinBackAndForth penguinMovement;
    public GameUI gameUI;
    public GameObject menuUI;
    public TextMeshProUGUI startCountdownText;
    public Transform penguinStartPosition;
    public List<Transform> snowballStartPositions;
    public List<GameObject> snowballs;

    public void StartGameSequence()
    {
        StartCoroutine(StartCountdown());
        menuUI.SetActive(false);
    }

    private IEnumerator StartCountdown()
    {
        startCountdownText.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            startCountdownText.text = $"Game starting in {i}";
            yield return new WaitForSeconds(1f);
        }

        startCountdownText.text = "Start!";
        yield return new WaitForSeconds(1f);
        startCountdownText.gameObject.SetActive(false);

        gameUI.gameObject.SetActive(true);
        penguinMovement.StartMovement();
        gameUI.StartGameUI();
    }

    public void EndGame()
    {
        Debug.Log("yes the game ended");
        penguinMovement.StopMovement();

        
        penguinMovement.transform.position = penguinStartPosition.position;

        
        for (int i = 0; i < snowballs.Count; i++)
        {
            snowballs[i].transform.position = snowballStartPositions[i].position;
            snowballs[i].SetActive(true); 
        }

        
        gameUI.StopGameUI();

        
        menuUI.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
                                        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }
}
