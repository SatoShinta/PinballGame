using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField, Header("敵たち1")] List<GameObject> enemys1;
    [SerializeField, Header("敵たち2")] List<GameObject> enemys2;
    [SerializeField, Header("敵たち3")] List<GameObject> enemys3;
    [SerializeField, Header("1層出現位置")] List<GameObject> spownpos1;
    [SerializeField, Header("2層出現位置")] List<GameObject> spownpos2;
    [SerializeField, Header("3層出現位置")] List<GameObject> spownpos3;
    public bool enemy_3_spawn;
    public GameObject enemy3action;

    public void Start()
    {
        enemy_3_spawn = false;

        // スポーン位置を自動で設定
        SpawnPositions("spawn1", spownpos1);
        SpawnPositions("spawn2", spownpos2);
        SpawnPositions("spawn3", spownpos3);

        // 敵を生成
        EnemyInstantiate1();
        EnemyInstantiate2();
    }

    // enemy_3_spawnフラグがONになったら3種類目の敵を出現させる
    public void Update()
    {
        if(enemy3action != null)
        {
            if (enemy_3_spawn)
            {
                EnemyInstantiate3();
            }
        }
        
    }


    //  敵を生成する
    private void InstantiateEnemies(List<GameObject> enemies, List<GameObject> spawnPositions)
    {
        // 出現位置リストが空でない場合
        if (enemies.Count > 0 && spawnPositions.Count > 0)
        {
            foreach (var pos in spawnPositions)
            {
                // 敵リストの最初のオブジェクトを、出現位置の位置に生成する
                Instantiate(enemies[0], pos.transform);
            }
        }
    }

    // 1層の敵を生成する
    public void EnemyInstantiate1()
    {
        InstantiateEnemies(enemys1, spownpos1);
    }

    // 2層の敵を生成する
    public void EnemyInstantiate2()
    {
        InstantiateEnemies(enemys2, spownpos2);
    }

    //　3層の敵を生成する
    public void EnemyInstantiate3()
    {
        InstantiateEnemies(enemys3, spownpos3);
    }

    // 指定した名前で出現位置を初期化する
    private void SpawnPositions(string name, List<GameObject> list)
    {
        list.Clear(); // リストを初期化

        // 名前でオブジェクトを検索し、リストに追加
        GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag(name);
        foreach (var obj in spawnObjects)
        {
            list.Add(obj);
        }
    }
}
