using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private MenuPanel menuPanel;
    [SerializeField] private GamePanel gamePanel;

    public void Initialize()
    {
        HideAllPanels();
    }
    public void ShowMenuPanel()
    {
        HideAllPanels();
        menuPanel.gameObject.SetActive(true);
    }

    public void ShowGamePanel()
    {
        HideAllPanels();
        gamePanel.gameObject.SetActive(true);
    }
    private void HideAllPanels()
    {
        menuPanel.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(false);
    }
}