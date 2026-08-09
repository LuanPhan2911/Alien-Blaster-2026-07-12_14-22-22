using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuildBrickPlatform : MonoBehaviour, IExcuteEditMode
{


    private bool _isDirty = false;

    [SerializeField, Range(1, 10)] private int count = 1;
    [SerializeField] private GameObject _brickPrefab;
    [SerializeField] private List<GameObject> _brickList = new List<GameObject>();





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

        // destroy all brick
        foreach (Brick brick in GetComponentsInChildren<Brick>())
        {
            DestroyImmediate(brick.gameObject);
        }
        _brickList.Clear();
        if (_brickList.Count == 0)
        {
            GameObject brick = Instantiate(_brickPrefab, transform);
            _brickList.Add(brick);
        }
        for (int i = 1; i < count; i++)
        {
            GameObject brick = Instantiate(_brickPrefab, transform);
            brick.transform.position = new Vector3(_brickList[i - 1].transform.position.x + 1,
                brick.transform.position.y,
                brick.transform.position.z);

            _brickList.Add(brick);
        }



    }
}
