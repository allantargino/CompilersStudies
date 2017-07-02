using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNumbers
{
    public class Lexical
    {
        private string _text;
        private int _index;
        private int _currentState;
        private Token _token;

        private const int S0 = 0;
        private const int S1 = 1;
        private const int S2 = 2;
        private const int S3 = 3;
        private const int SL = 4;
        
        public Lexical(string text)
        {
            _text = text + "\n";
            _index = 0;
            _currentState = S0;
        }

        private char GetNextChar()
        {
            return _text.ElementAt(_index++);
        }

        private void GoBack()
        {
            _index--;
        }

        public bool IsFinished()
        {
            if (_index < _text.Length)
                return false;
            else
                return true;
        }

        public Token GetToken()
        {
            while (true)
            {
                if (IsFinished())
                {
                    return new Token()
                    {
                        Code = TokenCode.EOF,
                        Symbol = string.Empty
                    };
                };

                var c = GetNextChar();
                switch (_currentState)
                {
                    case S0:
                        if (char.IsDigit(c))
                        {
                            _token = new Token();
                            _token.Symbol += c;
                            _currentState = S1;
                        }
                        else if (char.IsPunctuation(c))
                        {
                            _token = new Token();
                            _token.Symbol += c;
                            _currentState = S2;
                        }
                        else if (char.IsWhiteSpace(c))
                        {
                            _currentState = S0;
                        }
                        else
                        {
                            _currentState = SL;
                        }
                        break;
                    case S1:
                        if (char.IsDigit(c))
                        {
                            _token.Symbol += c;
                            _currentState = S1;
                        }
                        else if (char.IsPunctuation(c))
                        {
                            _token.Symbol += c;
                            _currentState = S2;
                        }
                        else
                        {
                            GoBack();
                            _currentState = S0;
                            _token.Code = TokenCode.NUMERO_INT;
                            return _token;
                        }
                        break;
                    case S2:
                        if (char.IsDigit(c))
                        {
                            _token.Symbol += c;
                            _currentState = S3;
                        }
                        else if (char.IsPunctuation(c))
                        {
                            _currentState = SL;
                        }
                        else
                        {
                            GoBack();
                            _currentState = S0;
                            _token.Code = TokenCode.NUMERO_INT;
                            return _token;
                        }
                        break;
                    case S3:
                        if (char.IsDigit(c))
                        {
                            _token.Symbol += c;
                            _currentState = S3;
                        }
                        else if (char.IsPunctuation(c))
                        {
                            _currentState = SL;
                        }
                        else
                        {
                            GoBack();
                            _currentState = S0;
                            _token.Code = TokenCode.NUMERO_PF;
                            return _token;
                        }
                        break;
                    case SL:
                        _token = null;
                        _currentState = S0;
                        break;
                }
            }
            return _token;
        }
    }
}
