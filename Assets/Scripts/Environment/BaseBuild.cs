using UnityEngine;


[ExecuteInEditMode]
public abstract class BaseBuild : MonoBehaviour
{

    private bool _isDirty = false;

    private void OnValidate()
    {
        _isDirty = true;
    }

    private void Update()
    {
        if (_isDirty)
        {
            UpdateLayout();
            _isDirty = false;
        }
    }
    public abstract void UpdateLayout();



}
