using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;                  //Tween�� ���� ���� ����

public class TweenTest : MonoBehaviour
{
    public bool isPunch = false;                        //���ڰ� ��Ī ������ Ȯ���ϴ� ����
    Sequence sequence;
    // Start is called before the first frame update
    void Start()
    {
        //transform.DOMoveX(5, 2);                //��ü�� X�������� 5��ŭ 2�� ���� ���ڴ�.
        //transform.DORotate(new Vector3(0, 0, 180), 2);        //180�� 2�� ȸ��
        //transform.DOScale(new Vector3(3, 3, 3), 2);           //2�ʵ��� 3�� ũ��

        //sequence = DOTween.Sequence();
        //sequence.Append(transform.DOMoveX(5, 2)).SetEase(Ease.OutBounce);       //SetEase �߰� �ɼ�
        //sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 2).OnComplete(SequenceEnd));  //�Ϸ�Ǹ� �Լ� ȣ��
        //sequence.Append(transform.DOScale(new Vector3(3, 3, 3), 2));
        //sequence.setLoops(-1, LoopType.Yoyo);                //������ ������
    }

    void SequenceEnd()
    {
        Debug.Log("ȸ�� �Ϸ�");
    }

    void EndPunch()
    {
        isPunch = false;                    //��Ī�� ������ �� ���°��� �ٽ� False�� ����
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isPunch == false)                //��Ī ���� �ƴҶ�
            {
                isPunch = true;                 //��Ī ���̴� ��� ���°� ����
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f, 10, 1).OnComplete(EndPunch);

                Color color = new Color(Random.value, Random.value, Random.value);          //�������� ���ؼ�
                Renderer renderer = GetComponent<Renderer>();                               //Renderer ������Ʈ���� 
                renderer.material.DOColor(color, 0.1f);
            }
        }
    }
}