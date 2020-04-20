using UnityEngine;
using UnityEngine.UI;
public class StartScreenButtons : MonoBehaviour
{
    [SerializeField] private Button meatGameButton = null;
    [SerializeField] private Button junkGameButton = null;
    [SerializeField] private Button vegGameButton = null;
    [SerializeField] private Button optionsButton = null;
    [SerializeField] private Button exitButton = null;

    private void Start()
    {
        meatGameButton.onClick.AddListener(GameManager.Instance.sceneController.LoadCarnivoreGame);
        junkGameButton.onClick.AddListener(GameManager.Instance.sceneController.LoadJunkFoodGame);
        vegGameButton.onClick.AddListener(GameManager.Instance.sceneController.LoadVegetarianGame);
        exitButton.onClick.AddListener(GameManager.Instance.Quit);
    }
}
