using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
public class LeaderBoard : MonoBehaviour
{

    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey = "733c8b0438b1eb7474e8e846367de4cd3d85e318e631d6ecf99f9b544f5203c8";

    private void Start()
    {
        getLeaderBoard();
    }
    public void getLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < names.Count; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void setLeaderBoard(string username, int score)
    {
       
            LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
            {
                // username.Substring(0, 4);
                getLeaderBoard();
            }));
     
       
    }
}
