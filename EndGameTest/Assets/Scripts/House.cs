using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private SpriteRenderer roof = null;
    [SerializeField] private SpriteRenderer front = null;
    [SerializeField] private SpriteRenderer back = null;

    private bool haveKey = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        EnterHouse();
        if (other.gameObject.layer == LayerMask.GetMask("Player"))
        {
            Debug.Log("EEE");
            EnterHouse();
        }
    }

    public void EnterHouse() 
    {
        //TODO check if key exists
        roof.enabled = false;
        front.enabled = false;
    }
}
