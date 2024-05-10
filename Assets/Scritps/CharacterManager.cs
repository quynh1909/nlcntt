using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Animator characterAnimator;
    public RuntimeAnimatorController playerAnimatorController;
    public RuntimeAnimatorController player1AnimatorController;

    void Start()
    {
        // Đăng ký sự kiện GameStart của GameManager để cập nhật Animator Controller khi playerId thay đổi
        GameManager.instance.OnGameStart += UpdateCharacterAnimator;
    }

    void OnDestroy()
    {
        // Huỷ đăng ký sự kiện khi script bị hủy
        GameManager.instance.OnGameStart -= UpdateCharacterAnimator;
    }

    // Phương thức để cập nhật Animator Controller của character
    void UpdateCharacterAnimator(int playerId)
    {
        // Kiểm tra playerId và gán Animator Controller tương ứng
        if (playerId == 0)
        {
            characterAnimator.runtimeAnimatorController = playerAnimatorController;
        }
        else
        {
            characterAnimator.runtimeAnimatorController = player1AnimatorController;
        }
    }
}
