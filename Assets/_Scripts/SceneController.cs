using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void LoadGame()
    {
        GameManager.Instance.gameOver = false;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void LoadVegetarianGame()
    {
        GameManager.Instance.gameMode = TargetType.Diet.Vegetarian;
        LoadGame();
    }

    public void LoadJunkFoodGame()
    {
        GameManager.Instance.gameMode = TargetType.Diet.Garbage;
        LoadGame();
    }

    public void LoadCarnivoreGame()
    {
        GameManager.Instance.gameMode = TargetType.Diet.Meat;
        LoadGame();
    }
    
    public void LoadStart()
    {
        SceneManager.LoadScene("Start Screen", LoadSceneMode.Single);
    }
    
    
}
