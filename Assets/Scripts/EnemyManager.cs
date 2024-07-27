using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField, Header("�G����1")] List<GameObject> enemys1;
    [SerializeField, Header("�G����2")] List<GameObject> enemys2;
    [SerializeField, Header("1�w�o���ʒu")] List<GameObject> spownpos1;
    [SerializeField, Header("2�w�o���ʒu")] List<GameObject> spownpos2;

    public void Start()
    {
        // �X�|�[���ʒu�������Őݒ�
        SpawnPositions("spawn1", spownpos1);

        // �G�𐶐�
        EnemyInstantiate1();
    }


    // �ėp���\�b�h: �G�𐶐�����
    private void InstantiateEnemies(List<GameObject> enemies, List<GameObject> spawnPositions)
    {
        // �o���ʒu���X�g����łȂ��ꍇ
        if (enemies.Count > 0 && spawnPositions.Count > 0)
        {
            foreach (var pos in spawnPositions)
            {
                // �G���X�g�̍ŏ��̃I�u�W�F�N�g���A�o���ʒu�̈ʒu�ɐ�������
                Instantiate(enemies[0], pos.transform);
            }
        }
    }

    // 1�w�̓G�𐶐�����
    public void EnemyInstantiate1()
    {
        InstantiateEnemies(enemys1, spownpos1);
    }

    // 2�w�̓G�𐶐�����
    public void EnemyInstantiate2()
    {
        InstantiateEnemies(enemys2, spownpos2);
    }

    // �w�肵�����O�ŏo���ʒu������������
    private void SpawnPositions(string name, List<GameObject> list)
    {
        list.Clear(); // ���X�g��������

        // ���O�ŃI�u�W�F�N�g���������A���X�g�ɒǉ�
        GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag(name);
        foreach (var obj in spawnObjects)
        {
            list.Add(obj);
        }
    }
}
