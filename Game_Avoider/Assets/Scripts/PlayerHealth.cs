
using UnityEngine;



public class PlayerHealth : MonoBehaviour
{
   [SerializeField] GameOverHandler gameOverHandler;

    
   

   public void Crash()
   {
       gameObject.SetActive(false);

       gameOverHandler.EndGame();
   }
}
