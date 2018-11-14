using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStatusData : ScriptableObject {
    public List<EnemyState> EnemyStateList = new List<EnemyState>();
}

[System.Serializable]
public class EnemyState {
    [SerializeField]
    private string Name;
    [SerializeField]
    private int HP, ATK, EXP;
    [SerializeField]
    private bool[] Atk_AI;
    [SerializeField]
    private bool _isBoss = false;
    public bool IsBoss{
        get { return _isBoss; }
#if UNITY_EDITOR
        set { _isBoss = value; }
#endif
    }
}