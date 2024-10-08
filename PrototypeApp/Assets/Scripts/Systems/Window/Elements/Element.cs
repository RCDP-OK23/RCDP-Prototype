using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Element : MonoBehaviour
{
    // �G�������g�̎�ނ�ݒ�
    [SerializeField] private string type = "";
    public string Type { get { return type; } }

    // �G�������g�̏������������L�q�B���������ɃG�������g�͔�\����Ԃɂ���
    abstract public void Init();

    // �G�������g�̕\���������L�q
    abstract public void Show();

    // �G�������g�̔�\���������L�q
    abstract public void Close();

    // �G�������g�̎��s�������L�q
    abstract public void Execute();

    // �G�������g�̈ړ��������L�q
    abstract public void Move(ref Vector2 vec);
}
