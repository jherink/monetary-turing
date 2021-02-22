using System;
using System.Collections.Generic;
using System.Text;

namespace MonetaryTuring
{
    public class MonetaryTuring
    {
        private enum State
        {
            Start,
            InputDollars,
            InputCents,
            InputCentsFinal,
            Done
        }

        private State _activeState = State.Start;

        private StringBuilder _value = new StringBuilder();
        public string Value => _value.ToString();

        private bool Is1To9( char c )
        {
            return c >= '1' && c <= '9';
        }

        private bool Is0To9( char c )
        {
            return c >= '0' && c <= '9';
        }

        public void Update( char c )
        {
            switch ( _activeState )
            {
                case State.Start:
                    if ( Is1To9( c ) )
                    {
                        _activeState = State.InputDollars;
                        _value.Append( c );
                    }
                    break;
                case State.InputDollars:
                    if ( Is0To9( c ) )
                    {
                        _value.Append( c );
                    }
                    else if ( c == '.' )
                    {
                        _activeState = State.InputCents;
                        _value.Append( c );
                    }
                    break;
                case State.InputCents:
                    if ( Is0To9( c ) )
                    {
                        _activeState = State.InputCentsFinal;
                        _value.Append( c );
                    }
                    break;
                case State.InputCentsFinal:
                    if ( Is0To9( c ) )
                    {
                        _activeState = State.Done;
                        _value.Append( c );
                    }
                    break;
                case State.Done: // Do nothing in done state
                    break;
                default:
                    break;
            }
        }

        public void Delete()
        {
            switch ( _activeState )
            {
                case State.Start:
                    // Do nothing
                    break;
                case State.InputDollars:
                    if ( _value.Length > 0 )
                    {
                        RemoveLastCharacter();
                    }
                    if ( _value.Length == 0 )
                    {
                        _activeState = State.Start;
                    }
                    break;
                case State.InputCents:
                    RemoveLastCharacter();
                    _activeState = State.InputDollars;
                    break;
                case State.InputCentsFinal:
                    RemoveLastCharacter();
                    _activeState = State.InputCents;
                    break;
                case State.Done:
                    RemoveLastCharacter();
                    _activeState = State.InputCentsFinal;
                    break;
                default:
                    break;
            }
        }

        private void RemoveLastCharacter()
        {
            _value.Remove( _value.Length - 1, 1 );
        }

    }
}
