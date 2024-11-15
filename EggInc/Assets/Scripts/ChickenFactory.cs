using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ChickenFactory : MonoBehaviour
{
    public float health_points = 2;

    [SerializeField] GameObject gameManager;

    public GameObject nice_chicken;
    public GameObject evil_chicken;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    public GameObject getChickenType()
    {
        GameObject chickenType = null;

        switch(Random.Range(1, 11))
        {
            case 10:
                chickenType = evil_chicken;
                break;
            default:
                chickenType = nice_chicken;
                break;
        }

        return chickenType;
    }

    public virtual void setHealthPoints(float damage, GameObject affectedChicken){}

    public void setTotalChickens(float newChickens)
    {
        gameManager.GetComponent<GameManager>().totalChickens += newChickens;
    }
}
