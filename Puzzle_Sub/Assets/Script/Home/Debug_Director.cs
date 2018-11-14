using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Director : MonoBehaviour {
    [SerializeField]
    float _radius;
    enum ROLL { NONE, LEFT, RIGHT };
    ROLL r_mode;
    float count;
    const float cnt_max = 1.0f;
    int s_ix, old_ix;
    public GameObject target;
    Vector2 S_pos, E_pos;
    Vector3[] RollAngleZ = {
                               new Vector3(0,0,0),
                               new Vector3(0,0,120),
                               new Vector3(0,0,240),
                           };
    void Awake(){
        Deploy();
    }
    void Start(){
        r_mode = ROLL.NONE;
        count = 0;
        s_ix = old_ix = 0;
    }
    void Update(){
        if (r_mode == ROLL.NONE) KeyGET();
        else r_mode = Button_Change(r_mode);
    }
    ROLL Button_Change(ROLL roll) {
        if (count <= cnt_max) {
            count += cnt_max;
            Quaternion q1 = Quaternion.Euler(RollAngleZ[old_ix]);
            Quaternion q2 = Quaternion.Euler(RollAngleZ[s_ix]);
            target.transform.rotation = Quaternion.Lerp(q1, q2, count);
        }else{
            roll = ROLL.NONE;
            count = 0;
        }
        return roll;
    }
    void KeyGET(){
        if (Input.GetMouseButtonDown(0)){
            S_pos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
            count = 0;
        }
        if (Input.GetMouseButtonUp(0)){
            E_pos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
            GetDirection();
        }
    }
    //フリックかタッチかどうか取得
    void GetDirection(){
        float dirX = E_pos.x - S_pos.x;
        float dirY = E_pos.y - S_pos.y;
        string dir = "none";
        r_mode = ROLL.NONE;

        if (Mathf.Abs(dirY) < Mathf.Abs(dirX)){
            if (30 < dirX) dir = "right";
            else if (-30 > dirX) dir = "left";
        }else if (Mathf.Abs(dirX) < Mathf.Abs(dirY)){
            if (30 < dirY) dir = "up";
            else if (-30 > dirY) dir = "down";
        }else dir = "touch";

        switch (dir){
            case "right":
                //右フリックされた時の処理
                r_mode = ROLL.RIGHT;
                old_ix = s_ix;
                s_ix--;
                break;
            case "left":
                //左フリックされた時の処理
                r_mode = ROLL.LEFT;
                old_ix = s_ix;
                s_ix++;
                break;
            case "touch":
                break;
        }
        if (s_ix > 2) s_ix = 0;
        else if (s_ix < 0) s_ix = 2;
    }
    void OnValidate()
    {
        Deploy();
    }
    //子を円状に配置する(ContextMenuで鍵マークの所にメニュー追加)
    [ContextMenu("Deploy")]
    void Deploy()
    {

        //子を取得
        List<GameObject> childList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            childList.Add(child.gameObject);
        }

        //数値、アルファベット順にソート
        childList.Sort(
          (a, b) =>
          {
              return string.Compare(a.name, b.name);
          }
        );

        //オブジェクト間の角度差
        float angleDiff = 360f / (float)childList.Count;

        //各オブジェクトを円状に配置
        for (int i = 0; i < childList.Count; i++)
        {
            Vector3 childPostion = transform.position;

            float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
            childPostion.x += _radius * Mathf.Cos(angle);
            childPostion.y += _radius * Mathf.Sin(angle);

            childList[i].transform.position = childPostion;
        }

    }
}
