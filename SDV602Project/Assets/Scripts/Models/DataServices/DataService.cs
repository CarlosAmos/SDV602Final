using SQLite4Unity3d;
using UnityEngine;
using System.Linq;
using System;

#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

    private SQLiteConnection _connection;
    public SQLiteConnection Connection
    {
        get
        {
            return _connection;
        }
    }

    public DataService(string DatabaseName){

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);     

	}

   
    public void CreateDB(Type[] pTableTypes)
    {
        var creaeList = pTableTypes.Where(x =>
        {
            _connection.CreateTable(x);
            return true;
        }
        ).ToList();
    }

    public void InsertIfDoesNotExist<Type>(Type Record)
    {
        try
        {
            _connection.Insert(Record);
        }
        catch (Exception)
        {

        }
    }
    // Player
    public Player storeNewPlayer(string pUsername, string pPassword)
    {
        Player player = new Player
        {
            Username = pUsername,
            Password = pPassword
        };
        _connection.Insert(player);
        return player;
    }

    public Player getPlayer(string pPlayerName)
    {
        return _connection.Table<Player>().Where(x => x.Username == pPlayerName).FirstOrDefault();
    }

    //Character. Used for ingame 
    #region Character
    
    //Used when starting or resuming game or finishing a game.
    public Character storeNewCharacter(int pPlayerID, string pLocation, int pScore)
    {
        Character character = new Character
        {
            PlayerID = pPlayerID,
            Location = pLocation,
            Score = pScore
        };
        _connection.InsertOrReplace(character);
        return character;
    }

    public Character updateCharacter(int pPlayerID, string pLocation, int pScore)
    {
        Character character = new Character
        {
            PlayerID = pPlayerID,
            Location = pLocation,
            Score = pScore
        };
        _connection.Insert(character);
        return character;
    }

    public Character getCharacter(int pPlayerID)
    {
        return _connection.Table<Character>().Where(x => x.PlayerID == pPlayerID).FirstOrDefault();
    }


    /*public Player updateLocation(string pUsername, string pLocation)
    {
        Player player = new Player
        {
            Username = pUsername,
            Location = pLocation
        };
        _connection.InsertOrReplace(player);
        return player;
    }*/

    #endregion
    //   Example 
    // public Person GetJohnny(){
    //	return _connection.Table<Person>().Where(x => x.Name == "Johnny").FirstOrDefault();
    //}

    //public Person CreatePerson(){
    //	var p = new Person{
    //			Name = "Johnny",
    //			Surname = "Mnemonic",
    //			Age = 21
    //	};
    //	_connection.Insert (p);
    //	return p;
    //}

    //public IEnumerable<Person> GetPersons(){
    //	return _connection.Table<Person>();
    //}

    //public IEnumerable<Person> GetPersonsNamedRoberto(){
    //	return _connection.Table<Person>().Where(x => x.Name == "Roberto");
    //}

}
