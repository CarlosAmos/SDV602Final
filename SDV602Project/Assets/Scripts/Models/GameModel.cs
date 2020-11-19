﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;



using System.Text;
using SQLite4Unity3d;

// Is this a factory?

public static class GameModel
{

	static String _username;

	public static string Username{
		get 
		{ 
			return _username;  
		}
		set{
			_username = value; 
		}

	}



    public static Player currentPlayer = null;
    public static Character currentCharacter = null;
    public static DataService ds = new DataService("OneManStanding.db");

    // enum type for value that is one of these.
    // Here enum is being used to determine 
    // Login Reg statuses.

    #region Offline
    public enum PasswdMode{
        NeedName,
        NeedPassword,
        OK,
        AllBad
    }

    public static PasswdMode CheckPassword(string pUsername, string pPassword)
    {
        PasswdMode result = GameModel.PasswdMode.AllBad;

        Player aPlayer = ds.getPlayer(pUsername);
        //Changes Here

        if( aPlayer != null)
        {
            if(aPlayer.Password == pPassword)
            {
                result = GameModel.PasswdMode.OK;
                GameModel.currentPlayer = aPlayer; // << WATCHOUT THIS IS A SIDE EFFECT


            }
            else
            {
                result = GameModel.PasswdMode.NeedPassword;
            }
        }
        else
            result = GameModel.PasswdMode.NeedName;

        return result;
    }

    public static void RegisterPlayer(string pUsername, string pPassword)
    {
       
        GameModel.currentPlayer = GameModel.ds.storeNewPlayer(pUsername, pPassword);
    }
    
    public enum PlayerMde
    {
        NotExists,
        Exists,
        AllBad
    }

    public static PlayerMde CheckPlayer(string pUsername)
    {
        PlayerMde result = GameModel.PlayerMde.AllBad;

        Player aPlayer = ds.getPlayer(pUsername);

        if (aPlayer == null)
        {
            result = GameModel.PlayerMde.NotExists;
        }
        else        
            result = GameModel.PlayerMde.Exists;
        
        return result;
    }

    public static void newLocation(int pPlayerID, string pLocation, int pScore)
    {
        GameModel.currentCharacter = GameModel.ds.storeNewCharacter(pPlayerID, pLocation, pScore);
    }

    public static void updateLocation(int pPlayerID, string pLocation, int pScore)
    {
        GameModel.currentCharacter = GameModel.ds.updateCharacter(pPlayerID, pLocation, pScore);
    }

    public enum CharacterMde
    {
        NotExists,
        Exists,
        AllBad
    }

    public static CharacterMde CheckLocation(int pPlayerID)
    {
        CharacterMde result = GameModel.CharacterMde.AllBad;

        Character character = ds.getCharacter(pPlayerID);

        if (character == null)
        {
            result = GameModel.CharacterMde.NotExists;
        }
        else
            result = GameModel.CharacterMde.Exists;
        return result;
    }

    public static void SetupGame()
    {


    }
    #endregion




}

