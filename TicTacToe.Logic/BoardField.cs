using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Logic
{
    public class BoardField
    {
        public event EventHandler OnFieldStatusChange;

        FieldSymbol fieldStatus = FieldSymbol.Empty;

        public FieldSymbol FieldStatus
        {
            get
            {
                return fieldStatus;
            }
            internal set
            {
                if (value == fieldStatus) return;
                fieldStatus = value;
                //is not thread safe on this way
                if (OnFieldStatusChange != null)
                    OnFieldStatusChange(this, EventArgs.Empty);
            }
        }
    }
}
