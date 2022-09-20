using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class FileManager
{
    public static string dirpath = Application.persistentDataPath + "\\SongList";
    

    public List<string> folderList()
    {
        try 
        { 
            return Directory.GetDirectories(dirpath).ToList(); 
        }
        catch (UnauthorizedAccessException)
        { 
            return new List<string>(); 
        } 
    }

    public string GetBms(int index)
    {
        var directories = folderList();
        if(directories.Count == 0)
        {
            return "error";
        }
        else
        {
            string[] filepath = Directory.GetFiles(directories[index],@"*.txt");
            return filepath[0];
        } 
    }

    public string GetAudio(int index)
    {
        var directories = folderList();
        if (directories.Count == 0)
        {
            return "error";
        }
        else
        {
            string[] filepath = Directory.GetFiles(directories[index], @"*.mp3");
            return filepath[0];
        }
    }
    public string GetImg(int index)
    {
        var directories = folderList();
        if (directories.Count == 0)
        {
            return "error";
        }
        else
        {
            string[] filepath = Directory.GetFiles(directories[index], @"*.png");
            return filepath[0];
        }
    }

}
