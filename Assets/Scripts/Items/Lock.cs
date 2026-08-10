using UnityEngine;

public class Lock : MonoBehaviour
{

    private InteractObject _interactObject;

    private void Awake()
    {
        _interactObject = GetComponent<InteractObject>();
    }

    private void Start()
    {
        _interactObject.InteractSuccessAction += InteractObject_InteractSuccessAction;
    }

    private void InteractObject_InteractSuccessAction(object sender, System.EventArgs e)
    {
        Debug.Log("Unlock");
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (_interactObject != null)
        {
            _interactObject.InteractSuccessAction -= InteractObject_InteractSuccessAction;
        }
    }
}
