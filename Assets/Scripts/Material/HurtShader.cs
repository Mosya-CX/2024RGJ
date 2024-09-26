using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtShader : SingletonWithMono<HurtShader>
{
    private SpriteRenderer sr;
    [Header("������Ч")]
    [SerializeField] private float flashDuration = 0.3f; // �������ʱ��
    [SerializeField] private Material hitMat; // �ܻ�ʱ�Ĳ���
    private Material originalMat; // ԭʼ�Ĳ���
    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material; // ��¼ԭʼ�Ĳ���
    }
    //ִ��������Ч
    public void PlayFlashFX()
    {
        StartCoroutine(FlashFX());
    }
    // ִ��������Ч��Э��
    private IEnumerator FlashFX()
    {
        sr.material = hitMat; // �л����ܻ�����
    yield return new WaitForSeconds(flashDuration); // �ȴ�ָ�����������ʱ��
    sr.material = originalMat; // �ָ�ԭʼ����
 }
}
