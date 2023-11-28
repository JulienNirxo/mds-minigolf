[System.Serializable]
public class Player
{
    public int index;
    public string playerName;
    public int score;
    // Tu peux ajouter d'autres propriétés comme le niveau, l'expérience, etc.

    // Constructeur par défaut
    public Player()
    {
        index = 0;
        playerName = "Player";
        score = 0;
    }

    // Constructeur avec des paramètres
    public Player(string name, int initialScore)
    {
        index = 0;
        playerName = name;
        score = initialScore;
    }

    // Méthode pour afficher les détails du joueur
    public void DisplayPlayerInfo()
    {
        //Debug.Log("Player Name: " + playerName + ", Score: " + score);
    }
}
