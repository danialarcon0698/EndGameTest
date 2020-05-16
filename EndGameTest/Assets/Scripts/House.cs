using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private GameObject roof = null;
    [SerializeField] private GameObject front = null;
    [SerializeField] private GameObject back = null;

    private bool haveKey = false;

    public void Enter() 
    {
        //TODO check if key exists
        roof.SetActive(false);
    }
}
