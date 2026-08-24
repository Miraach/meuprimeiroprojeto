using UnityEngine;

public static class GameData {
    public static string PlayerName { get; set; }
    public static string EnemyName { get; set; }
    public static int HighScorePlayer { get; set; }
    public static int HighScoreEnemy { get; set; }
    public static Color PlayerColor { get; set; }

    public static void SaveNames() {
        PlayerPrefs.SetString("PlayerName", PlayerName);
        PlayerPrefs.SetString("EnemyName", EnemyName);
        PlayerPrefs.Save();
    }

    public static void LoadNames() {
        PlayerName = PlayerPrefs.GetString("PlayerName", "Jogador");
        EnemyName = PlayerPrefs.GetString("EnemyName", "Inimigo");
    }

    public static void SaveScores() {
        PlayerPrefs.SetInt("HighScorePlayer", HighScorePlayer);
        PlayerPrefs.SetInt("HighScoreEnemy", HighScoreEnemy);
        PlayerPrefs.Save();
    }

    public static void LoadScores() {
        HighScorePlayer = PlayerPrefs.GetInt("HighScorePlayer", 0);
        HighScoreEnemy = PlayerPrefs.GetInt("HighScoreEnemy", 0);
    }

    public static void SaveColor() {
        PlayerPrefs.SetFloat("PlayerColorR", PlayerColor.r);
        PlayerPrefs.SetFloat("PlayerColorG", PlayerColor.g);
        PlayerPrefs.SetFloat("PlayerColorB", PlayerColor.b);
        PlayerPrefs.SetFloat("PlayerColorA", PlayerColor.a);
        PlayerPrefs.Save();
    }

    public static void LoadColor() {
        float r = PlayerPrefs.GetFloat("PlayerColorR", 1f);
        float g = PlayerPrefs.GetFloat("PlayerColorG", 1f);
        float b = PlayerPrefs.GetFloat("PlayerColorB", 1f);
        float a = PlayerPrefs.GetFloat("PlayerColorA", 1f);
        PlayerColor = new Color(r, g, b, a);
    }
}
