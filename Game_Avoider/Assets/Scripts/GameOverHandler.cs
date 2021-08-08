using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
[SerializeField] private TMP_Text GameoverText;
//[SerializeField] private GameObject scoreUI;

[SerializeField] private ScoreSystem scoreSystem;
[SerializeField] private GameObject GameOverDisplay;
[SerializeField] private Asteroid_Manager asteroid_Manager;

   public void PlayAgain()
   {
     SceneManager.LoadScene(1);
   }

   public void MainMenu()
   {
      SceneManager.LoadScene(0);
   }

   public void ContinueGame()
   {
    
   }

   public void EndGame()
   {
       asteroid_Manager.enabled = false;

       GameoverText.text = "Your Score is " + scoreSystem.FinalScore().ToString();

       scoreSystem.enabled = false;

       //scoreUI.SetActive(false);

       GameOverDisplay.SetActive(true);


   }
}
