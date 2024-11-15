using UnityEngine;

public class EvilChicken : ChickenFactory
{
    public GameObject chickenTouching;
    public GameObject gameManager;

    // LOGIC WORKS THEY JUST SPAWN BEHIND THE BARN BECAUSE I DIDNT HAVE TIME TO HAVE THEM MOVE TOWARDS CHICKENS

    private void Start()
    {
        gameObject.transform.position = new Vector3(20, 1, 0);
        gameManager = GameObject.Find("GameObject");
    }

    private void Update()
    {
        if(gameManager.GetComponent<GameManager>().aliveChickens <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Nice")
        {
            chickenTouching = collider.gameObject;
            setHealthPoints(1, chickenTouching);
        }
    }

    public override void setHealthPoints(float damage, GameObject affectedChicken)
    {
        affectedChicken.GetComponent<NiceChicken>().setHealthPoints(damage, affectedChicken);
    }
}
