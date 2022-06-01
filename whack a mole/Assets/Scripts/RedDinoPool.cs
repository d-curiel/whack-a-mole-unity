using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDinoPool : MonoBehaviour
{
   public static RedDinoPool instance;
    [SerializeField]
    private GameObject _molePrefab;
    [SerializeField]
    private int _poolSize = 10;
    [SerializeField]
    List<GameObject> _moleList;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        _moleList = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < _poolSize; i++)
        {
            tmp = Instantiate(_molePrefab);
            tmp.SetActive(false);
            _moleList.Add(tmp);
        }
    }
    public GameObject GetMole()
    {
        for(int i = 0; i < _poolSize; i++)
        {
            if(!_moleList[i].activeInHierarchy)
            {
                return _moleList[i];
            }
        }
        return null;
    }
}
