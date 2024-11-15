using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private ChickenFactory chicken_factory;
    private GameObject currentChicken;

    public float totalChickens;
    public float totalProfit;
    public float multiplier;

    [SerializeField] Text totalChickenText;
    [SerializeField] Text totalProfitText;

    private float totalKeyPresses = 0;

    private float timeSinceLastInput = 0;
    private float continuousInputTime = 0;
    bool multiplierActive = false;

    public float aliveChickens = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        currentChicken = chicken_factory.nice_chicken;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"continue input: {continuousInputTime}");
        Debug.Log($"Total Key Presses: {totalKeyPresses}");

        if (Input.anyKeyDown)
        {
            currentChicken = chicken_factory.getChickenType();
            Instantiate(currentChicken);
            totalKeyPresses += 1;
            timeSinceLastInput = 0;
            continuousInputTime += (Time.deltaTime * 100);
        }

        timeSinceLastInput += Time.deltaTime;

        if (timeSinceLastInput >= 1)
        {
            multiplierActive = false;
            continuousInputTime = 0;
        }

        if(continuousInputTime >= 10)
        {
            multiplierActive = true;
        }

        

        if(multiplierActive == false)
        {
            totalProfit += totalChickens;
        }
        else if(multiplierActive == true && totalKeyPresses > 200)
        {
            multiplier = 1 + (continuousInputTime / 100);
            totalProfit += totalChickens * multiplier;
            Debug.Log($"multiplier: {multiplier}");
        }

        totalProfitText.text = $"Total Profit: {totalProfit}";
        totalChickenText.text = $"Total Chickens: {totalChickens}";
    }
}
