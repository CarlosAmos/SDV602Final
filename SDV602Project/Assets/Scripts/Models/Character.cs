using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;

public class Character 
{
    //Used for the data of the ingame character
    private int playerID;
    private string location;
    private int score;

    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public int PlayerID { get => playerID; set => playerID = value; }
    public string Location { get => location; set => location = value; }
    public int Score { get => score; set => score = value; }
}
