using UnityEngine;

public class Item_Hook : MonoBehaviour
{
    float force = 0f;

    // ������, ȸ�� 

    // ��ư �ٿ� ���� ��ư �� ������ 
    private void AimHook()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            force += Time.deltaTime;

        }
    }

    private void ThrowHook()
    {

    }

}
