/*using UnityEngine;
using UnityEngine.UI;

public class HighScorePanel : MonoBehaviour
{
    public Text playerNameTextPrefab;
    public Text scoreTextPrefab;
    public Transform scoreContainer;

    private void Start()
    {
        // Lấy danh sách điểm cao từ GameManager
        HighScoreList highScoreList = GameManager.Instance.GetHighScoreList();

        // Kiểm tra và hiển thị danh sách điểm cao
        if (highScoreList != null && highScoreList.highScores != null)
        {
            // Xóa các Text components cũ trong container
            foreach (Transform child in scoreContainer)
            {
                Destroy(child.gameObject);
            }

            // Hiển thị thông tin của tất cả điểm cao trên UI
            foreach (HighScore highScore in highScoreList.highScores)
            {
                // Tạo một thể hiện mới của PlayerName và Score Text components
                Text newPlayerNameText = Instantiate(playerNameTextPrefab, scoreContainer);
                Text newScoreText = Instantiate(scoreTextPrefab, scoreContainer);

                // Gán dữ liệu từ danh sách điểm cao vào Text components
                newPlayerNameText.text = highScore.playerName;
                newScoreText.text = highScore.score.ToString();
            }
        }
    }
}
*/