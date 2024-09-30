using UnityEngine;

public class Item_Hook : MonoBehaviour
{
    float force = 0f;

    // 던지기, 회수 

    // 버튼 다운 조준 버튼 업 던지기 
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
