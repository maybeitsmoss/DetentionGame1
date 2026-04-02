using UnityEngine;

public class drawers : MonoBehaviour
{
    public void OnUnlock()
    {
        Debug.Log("unlocked!!");
        GetComponent<Animator>().SetTrigger("open");
    }
}
