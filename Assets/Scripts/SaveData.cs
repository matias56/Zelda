using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public static SaveData _current;

    public List<ScriptableObject> objects = new List<ScriptableObject>();
    public static SaveData current
    {
        get
        {
            if(_current == null)
            {
                _current = new SaveData();
            }
            return _current;
        }
    }

    public PlayerProfile profile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if(_current== null)
        {
            _current = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
