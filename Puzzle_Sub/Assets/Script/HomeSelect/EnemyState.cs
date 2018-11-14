using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class a : ScriptableObject {
   
}

[System.Serializable]
public class b{

    [SerializeField]
    private int HP = 100, Atk = 5, Exp = 10;
    [SerializeField]
    private string Name = "WeakEnemy";
    [SerializeField]
    private bool _isBoss = false;
    public bool IsBoss{
        get { return _isBoss; }
#if UNITY_EDITOR
        set { _isBoss = value; }
#endif
    }
}
