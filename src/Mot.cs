// This file is part of the Pendu project
// Copyright 2021 Maël Coulmance


#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pendu
{
    public class Mot
    {
        private List<string>? _lettres;
        private List<int>? _foundedLetters;

        private List<string> _dico;
        private string? _previous;

        private int _vies;

        public Mot()
        {
            _dico = Util.ReadFile(Util.DEFAULT_PATH);
            _previous = null;
            _vies = -1;
            
            NewMot();
        }

        public void NewMot()
        {
            string mot = RandomMot();
            Init(mot);
            _previous = mot;
            _vies = 10;
        }

        private string RandomMot()
        {
            Random r = new Random();
            int pos = r.Next(0, _dico.Count - 1);
            string res = _dico[pos];

            if (_previous is not null)
            {
                while (res == _previous)
                {
                    pos = r.Next(0, _dico.Count);
                    res = _dico[pos];
                }
            }
            
            return res;
        }

        private void Init(string mot)
        {
            _lettres = new List<string>();
            _foundedLetters = new List<int>();

            foreach (char c in mot)
            {
                _lettres.Add(c.ToString());
                
                if (c == '-' || c == '_')
                    _foundedLetters.Add(1);
                else 
                    _foundedLetters.Add(0);
            }

            Debug.Assert(_lettres.Count == _foundedLetters.Count);
        }



        public bool IsLettre(string lettre)
        {
            if (_vies == -1 || _foundedLetters is null || _lettres is null)
                throw new InvalidOperationException("NewMot must be called first");

            bool res = false;
            for (int i = 0; i < _lettres.Count; i++)
            {
                if (_lettres[i] == lettre)
                {
                    _foundedLetters[i] = 1;
                    res = true;
                }
            }

            if (!res)
                pop_vie();

            return res;
        }

        public bool IsWin()
        {
            if (_foundedLetters is null)
                throw new InvalidOperationException("NewMot must be called first");
            
            foreach (int i in _foundedLetters)
            {
                if (i == 0)
                    return false;
            }

            return true;
        }

        public int GetVie() => _vies;

        public string GetMot()
        {
            if (_vies == -1 || _lettres is null || _foundedLetters is null)
                throw new InvalidOperationException("NewMot must be called first");

            string res = "";
            for (int i = 0; i < _lettres.Count; i++)
            {
                if (_foundedLetters[i] == 1)
                    res += _lettres[i];
                else
                    res += "_";

                res += " ";
            }

            return res;
        }

        public string GetFullMot()
        {
            if (_lettres is null)
                throw new InvalidOperationException("NewMot must be called first");

            string res = "";
            foreach (string s in _lettres)
            {
                res += s;
                res += " ";
            }

            return res;
        }

        private void pop_vie()
        {
            _vies--;
            if (_vies < 0)
                _vies = 0;
        }
    }
}