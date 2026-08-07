using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuildBrickPlatform : MonoBehaviour, IExcuteEditMode
{


    private bool _isDirty = false;

    [SerializeField, Range(1, 10)] private int count = 1;

    [SerializeField] private List<GameObject> _brickList;

    [SerializeField] private GameObject _brickPrefab;



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
    public void UpdateLayout()
    {
        for (int i = _brickList.Count; i < count; i++)
        {
            // instantiate new brick
            GameObject brick = Instantiate(_brickPrefab, transform);
            brick.transform.position = new Vector3(_brickList[i - 1].transform.position.x + 1, 0f, 0f);
            _brickList.Add(brick);
        }

        for (int i = _brickList.Count - 1; i >= count; i--)
        {
            GameObject brick = _brickList[i];

            _brickList.RemoveAt(i);

            DestroyImmediate(brick);
        }
    }
}
