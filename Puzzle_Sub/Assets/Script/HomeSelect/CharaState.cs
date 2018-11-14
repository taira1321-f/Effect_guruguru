using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaState : MonoBehaviour {
    /******************************************************************
     *プレイヤーのステータス
     *ゆかり:  属性(炎)・  初期レベル(1)・初期経験値(0)・初期体力(10)・初期攻撃(1)
     *こいし:  属性(水)・  初期レベル(1)・初期経験値(0)・初期体力(10)・初期攻撃(1)
     *シノン:  属性(木)・  初期レベル(1)・初期経験値(0)・初期体力(10)・初期攻撃(1)
     *クローム:属性(支援)・初期レベル(1)・初期経験値(0)・初期体力(10)・初期攻撃(1)
     ********************************************************************/
    string[] Chara_Name = { "Yukari", "Koishi", "Sinon", "Chrome" };
    int[] Chara_Level = { 1, 1, 1, 1 };
    float[] Chara_HitPoint = { 10, 10, 10, 10 };
    string[] Chara_Attribute = { "Fire", "Water", "Leaf", "Support" };
    int[] Chara_Exp = { 0, 0, 0, 0 };
    float[] Chara_Attack = { 1.0f, 1.0f, 1.0f, 1.0f };
    
    void Awake() {
        string s = PlayerPrefs.GetString(Chara_Name[0]);
        if (s != Chara_Attribute[0]) D_CharaSet();
    }
    void Debug_SET() {
        
    }
    void D_CharaSet() {
        for (int i = 0; i < Chara_Name.Length; i++) {
            PlayerPrefs.SetInt(Chara_Name[i], Chara_Level[i]);
            PlayerPrefs.SetFloat(Chara_Name[i], Chara_HitPoint[i]);
            PlayerPrefs.SetString(Chara_Name[i], Chara_Attribute[i]);
            PlayerPrefs.SetInt(Chara_Attribute[i], Chara_Exp[i]);            
            PlayerPrefs.SetFloat(Chara_Attribute[i], Chara_Attack[i]);
            PlayerPrefs.Save();
        }
    }
	void Start () {
        
	}
    void Update () {
        
	}
    
}
