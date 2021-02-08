// This file is part of the Pendu project
// Copyright 2021 Maël Coulmance

#nullable enable

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;

namespace Pendu
{
    public static class Util
    {
        public const string DEFAULT_PATH = "./assets/lib.txt";
        
        
        public static List<string> ReadFile(string path)
        {
            List<string> res = new List<string>();

            try
            {
                StreamReader file = new StreamReader(path);
                string? line = file.ReadLine();

                while (line != null)
                {
                    res.Add(line);
                    line = file.ReadLine();
                }

                file.Close();
            }
            catch (Exception)
            {
                //ignored
            }
            finally
            {
                res = CleanHeader(res);
                res = CleanEmpty(res);
            }

            return res;
        }

        public static List<string> CleanHeader(List<string> arg)
        {
            int firstPos = 0;
            bool isHeader = false;
            if (arg[firstPos] == "#")
            {
                firstPos++;
                isHeader = true;
            }

            if (firstPos != arg.Count)
            {
                while (isHeader  && arg[firstPos] != "#")
                {
                    firstPos++;
                    if (firstPos == arg.Count)
                        throw new Exception("Fichier d'en tête corrompus.");
                }
                
                if (isHeader)
                    arg.RemoveRange(0, firstPos + 1);
            }

            return arg;
        }

        public static List<string> CleanEmpty(List<string> arg)
        {
            for (int i = 0; i < arg.Count; i++)
            {
                if (arg[i] == "")
                {
                    arg.RemoveAt(i);
                    i--;
                }
            }

            return arg;
        }
    }
}