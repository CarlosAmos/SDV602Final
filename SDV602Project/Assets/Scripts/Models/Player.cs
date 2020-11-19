using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

public class Player 
{

    private string username;
    private string password;
    private string location;
    private int status;
    private int score;

    [PrimaryKey, AutoIncrement]
    public int ID { get ; set ; }
    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
    public int Status { get => status; set => status = value; }

}
