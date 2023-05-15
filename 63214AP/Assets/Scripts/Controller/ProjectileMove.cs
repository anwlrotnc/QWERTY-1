using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;                  //Tween�� ���� ���� ����


public class ProjectileMove : MonoBehaviour
{

    public bool isPunch = false;                        //���ڰ� ��Ī ������ Ȯ���ϴ� ����

    public Vector3 launchDirection;

    public enum PROJECTILETYPE
    {
        PLAYER,
        ENEMY
    }

    public PROJECTILETYPE projectiletype = PROJECTILETYPE.PLAYER;

    private void OnCollisionEnter(Collision collision)
    {   //���� �浹�� �ı�
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        //���Ϳ��� �浹��
        if(collision.gameObject.tag == "Monster")
        {
            //���Ϳ��� �������� �ְ� �������
            collision.gameObject.GetComponent<MonsterController>().Damaged(1);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)     //Trigger �Լ�
    {   //���� �浹�� �ı�
        if (other.gameObject.tag == "Wall")         // Name -> Tag �� ��ȯ
        {
            Destroy(this.gameObject);
        }
        //���Ϳ��� �浹��
        if (other.gameObject.tag == "Monster" && projectiletype == PROJECTILETYPE.PLAYER)
        {
            //���Ϳ��� �������� �ְ� �������
            other.gameObject.GetComponent<MonsterController>().Damaged(1);
            Destroy(this.gameObject);
        }
        //�÷��̾�� �浹��
        if (other.gameObject.tag == "Player" && projectiletype == PROJECTILETYPE.ENEMY)
        {
            //�÷��̾�� �������� �ְ� �������
            other.gameObject.GetComponent<PlayerController>().Damaged(1);
            Destroy(this.gameObject);
        }
    }


    private void FixedUpdate()
    {
        //�ð���� �̵� �� float ������ ����
        float moveAmount = 3 * Time.fixedDeltaTime;
        //launchDirection �������� �߻�ü �̵� (Translate) �̵� ��Ű�� �Լ�
        transform.Translate(launchDirection * moveAmount);


    }
}

