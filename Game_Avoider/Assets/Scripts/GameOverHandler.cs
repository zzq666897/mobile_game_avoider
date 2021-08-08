using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
[SerializeField] private TMP_Text GameoverText;
//[SerializeField] private GameObject scoreUI;

[SerializeField] private ScoreSystem scoreSystem;
[SerializeField] private GameObject GameOverDisplay;
[SerializeField] private Asteroid_Manager asteroid_Manager;
[SerializeField] private GameObject player;
[SerializeField] private Button continueButton;


   public void PlayAgain()
   {
     SceneManager.LoadScene(1);
   }

   public void MainMenu()
   {
      SceneManager.LoadScene(0);
   }


   public void EndGame()
   {
       asteroid_Manager.enabled = false;

       GameoverText.text = "Your Score is " + scoreSystem.FinalScore().ToString();

       scoreSystem.enabled = false;

       //scoreUI.SetActive(false);

       GameOverDisplay.SetActive(true);


   }


   public void ContinueButton ()
   {
      adManager.Instance.showAd(this);
      continueButton.interactable = false;
   }
   
   public void ContinueGame()
   {
     scoreSystem.continueTimer();
      
      player.SetActive(true);
      player.transform.position = Vector3.zero;
      player.GetComponent<Rigidbody>().velocity = Vector3.zero;
     
     
     asteroid_Manager.enabled = true;

     GameOverDisplay.SetActive(false);

    


   }

}
