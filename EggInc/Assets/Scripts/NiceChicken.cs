using UnityEngine;
using UnityEngine.Events;

public class NiceChicken : ChickenFactory
{
    public GameObject gameManager;

    UnityEvent ChickenDeath;

    private void Start()
    {
        gameManager = GameObject.Find("GameObject");
        gameManager.GetComponent<GameManager>().aliveChickens += 1;

        ChickenDeath.AddListener(OnDeath);
    }

    private void Update()
    {
        if(health_points <= 0)
        {
            Destroy(gameObject);
        }

        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.005f, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Shed")
        {
            setTotalChickens(1);
            ChickenDeath.Invoke(); // observer pattern wooo
        }
    }

    public override void setHealthPoints(float damage, GameObject affectedChicken)
    {
        health_points -= damage;
    }

    void OnDeath()
    {
        gameManager.GetComponent<GameManager>().aliveChickens -= 1;
        Destroy(gameObject);
    }
}
