using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Logic;

namespace TicTacToe.Winforms.Components
{
    public class BoardField : PictureBox
    {
        private Logic.BoardField logicBoardField;

        internal BoardField(Logic.BoardField boardField)
        {
            if (boardField == null) throw new ArgumentNullException();
            Dock = DockStyle.Fill;
            SizeMode = PictureBoxSizeMode.StretchImage;

            this.logicBoardField = boardField;

            boardField.OnFieldStatusChange += boardField_OnFieldStatusChange;
        }

        void boardField_OnFieldStatusChange(object sender, EventArgs e)
        {
            ChangeImage(logicBoardField.FieldStatus);
        }
        internal void ChangeImage(FieldSymbol symbol)
        {
            switch (symbol)
            {
                case FieldSymbol.Circle:
                    this.Image = Properties.Resources.rondje;
                    break;
                case FieldSymbol.Cross:
                    this.Image = Properties.Resources.kruisje;
                    break;
                case FieldSymbol.Empty:
                    this.Image = null;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
