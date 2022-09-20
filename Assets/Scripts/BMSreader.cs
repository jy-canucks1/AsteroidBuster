using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BMSreader
{
    private string[] lines;     //"F:\my_folders\spring2022\project\beatmapmaker\sample\DJ_Okawari_Flower_Dance_[Normal].txt"
    
    public BMSreader(string address)
    {
        lines = System.IO.File.ReadAllLines(address);
    }
    public List<string> BasicInfo()
    {
        List<string> basicinfo = new List<string>();
        foreach (string line in lines)
        {
            for(int i=0; i<line.Length; i++)
            {
                if (line.Substring(0, i + 1) == "Title:")
                {
                    basicinfo.Add(line.Substring(i + 1));
                }
                if (line.Substring(0, i + 1) == "Artist:")
                {
                    basicinfo.Add(line.Substring(i + 1));
                }
                if (line.Substring(0, i + 1) == "Version:")
                {
                    basicinfo.Add(line.Substring(i + 1));
                }
            }
        }
        return basicinfo;
    }
    public List<List<string>> TimingInfo()
    {
        List<List<string>> timinginfo = new List<List<string>>();
        List<string> initinfo = new List<string>();
        initinfo.Add("0");
        timinginfo.Add(initinfo);
        int check = 0;
        foreach (string line in lines)
        {
            if (line == "[HitObjects]" && check == 1)
            {
                check = 0;
                break;
            }
            if (check == 1)
            {
                int count = 0;
                int tmp = 0;
                List<string> subinfo = new List<string>();
                for (int i = 0; i < line.Length; i++)
                {
                    if(line[i] == ',')
                    {
                        count++;
                        if (count == 1)
                        {
                            
                            subinfo.Add(line.Substring(0, i));
                            tmp = i+1;
                        } else if (count == 2)
                        {
                            
                            subinfo.Add(line.Substring(tmp, i - tmp));
                            tmp = 0;
                            count = 0;
                            timinginfo.Add(subinfo);
                            break;
                        }
                    }
                }
                
            }           
                if (line == "[TimingPoints]")
                {
                    check = 1;
                }
                
               
            
        }
        return timinginfo;
    }
    public List<string> BeatInfo1()
    {
        List<string> beatinfo = new List<string>();
        beatinfo.Add("0");
        int check = 0;
        foreach (string line in lines)
        {
            if (line == "\n" && check == 1)
            {
                check = 0;
                break;
            }
            if (check == 1)
            {
                int count = 0;
                int tmp = 0;
                for (int i = 0; i < line.Length; i++)
                {

                    if (line[i] == ',')
                    {
                        count++;
                        
                        if (count == 1 && (Convert.ToInt32(line.Substring(0, i)) / 128 != 0))
                        {
                            
                            break;

                        }else if(count == 1)
                        {
                            tmp = i+1;
                        }
                        if (count == 2)
                        {
                            tmp = i+1;
                            continue;
                        }


                        if (count == 3)
                        {
                            beatinfo.Add(line.Substring(tmp, i - tmp));
                            break;
                        }
                    }
                }

            }
            if (line == "[HitObjects]")
            {
                check = 1;
            }

        }

        return beatinfo;
    }
    public List<string> BeatInfo2()
    {
        List<string> beatinfo = new List<string>();
        beatinfo.Add("0");
        int check = 0;        
        foreach (string line in lines)
        {
            if (line == "\n" && check == 1)
            {
                check = 0;
                break;
            }
            if (check == 1)
            {
                int count = 0;
                int tmp = 0;                
                for (int i = 0; i < line.Length; i++)
                {

                    if (line[i] == ',')
                    {
                        count++;
                        if (count == 1 && (Convert.ToInt16(line.Substring(0, i)) / 128 != 1))
                        {

                            break;

                        }
                        else if (count == 1)
                        {
                            tmp = i + 1;
                        }
                        if (count == 2)
                        {
                            tmp = i + 1;
                            continue;
                        }

                        if (count == 3)
                        {
                            beatinfo.Add(line.Substring(tmp, i - tmp));
                            break;
                        }
                    }
                }
               
            }
            if (line == "[HitObjects]")
            {
                check = 1;
            }

        }
        return beatinfo;
    }
    public List<string> BeatInfo3()
    {
        List<string> beatinfo = new List<string>();
        beatinfo.Add("0");
        int check = 0;
        foreach (string line in lines)
        {
            if (line == "\n" && check == 1)
            {
                check = 0;
                break;
            }
            if (check == 1)
            {
                int count = 0;
                int tmp = 0;
                for (int i = 0; i < line.Length; i++)
                {

                    if (line[i] == ',')
                    {
                        count++;
                        if (count == 1 && (Convert.ToInt16(line.Substring(0, i)) / 128 != 2))
                        {

                            break;

                        }
                        else if (count == 1)
                        {
                            tmp = i + 1;
                        }
                        if (count == 2)
                        {
                            tmp = i + 1;
                            continue;
                        }

                        if (count == 3)
                        {
                            beatinfo.Add(line.Substring(tmp, i - tmp));
                            break;
                        }
                    }
                }

            }
            if (line == "[HitObjects]")
            {
                check = 1;
            }

        }
        return beatinfo;
    }
    public List<string> BeatInfo4()
    {
        List<string> beatinfo = new List<string>();
        beatinfo.Add("0");
        int check = 0;
        foreach (string line in lines)
        {
            if (line == "\n" && check == 1)
            {
                check = 0;
                break;
            }
            if (check == 1)
            {
                int count = 0;
                int tmp = 0;
                for (int i = 0; i < line.Length; i++)
                {

                    if (line[i] == ',')
                    {
                        count++;
                        if (count == 1 && (Convert.ToInt16(line.Substring(0, i)) / 128 != 3))
                        {

                            break;

                        }
                        else if (count == 1)
                        {
                            tmp = i + 1;
                        }
                        if (count == 2)
                        {
                            tmp = i + 1;
                            continue;
                        }


                        if (count == 3)
                        {
                            beatinfo.Add(line.Substring(tmp, i - tmp));
                            break;
                        }
                    }
                }

            }
            if (line == "[HitObjects]")
            {
                check = 1;
            }

        }
        return beatinfo;
    }
    public string Firstline()
    {
        string first;
        
        int check = 0;
        foreach (string line in lines)
        {
            if (line == "\n" && check == 1)
            {
                check = 0;
                break;
            }
            if (check == 1)
            {
                int count = 0;
                int tmp = 0;
                for (int i = 0; i < line.Length; i++)
                {

                    if (line[i] == ',')
                    {
                        Debug.Log("${i} found");
                        count++;
                         if (count == 1)
                        {
                            first = line.Substring(tmp, i - tmp);
                            Debug.Log(first);
                            return first;
                            
                        }
                        
                    }
                }

            }
            if (line == "[HitObjects]")
            {
                check = 1;
            }

        }
        return "error";
    }

}
