using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DentiNovin.BaseClasses
{
    public class DataGridViewComplexCell : DataGridViewTextBoxCell
    {
        private Icon _icon;
        public Icon Icon { get { return _icon; } set { _icon = value; } }

        private bool _showEnteredSymbol = false;
        public bool ShowEnteredSymbol { get { return _showEnteredSymbol; } set { _showEnteredSymbol = value; } }

        private bool _showSelectSymbol=false;
        public bool ShowSelectSymbol { get { return _showSelectSymbol; } set { _showSelectSymbol = value; } }

        private bool _showPlusSymbol = false;
        public bool ShowPlusSymbol { get { return _showPlusSymbol; } set { _showPlusSymbol = value; } }

        private bool _showRectangle = false;
        public bool ShowRectangle { get { return _showRectangle; } set { _showRectangle = value; } }

        private Int16 _count = 0;
        public Int16 Count { get { return _count; } set { _count = value; } }

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            //var cellValue = Convert.IsDBNull(value) ? 0 : Convert.ToDecimal(value);

            const int horizontaloffset = 2;

            var parent = (DataGridViewComplexColumn)this.OwningColumn;

            var fnt = parent.InheritedStyle.Font;
            var textColor = parent.InheritedStyle.ForeColor;

            const int vertoffset = 0;

            if (_icon != null)
                graphics.DrawIcon(_icon, cellBounds.X + horizontaloffset,cellBounds.Y + vertoffset);
            
            if (ShowEnteredSymbol)
                    graphics.DrawString("√", fnt, new SolidBrush(Color.White), cellBounds.X + horizontaloffset, cellBounds.Y + vertoffset);

            if (ShowPlusSymbol)
                graphics.DrawString("+ " + Count.ToString(), fnt, new SolidBrush(Color.White), cellBounds.X + cellBounds.Width - 24, cellBounds.Y + (cellBounds.Height/2)-7);

            if (ShowSelectSymbol)
                DrawArrow(graphics, cellBounds, false, false, 4);

            if (ShowRectangle)
            {
                Rectangle tempRectangle = cellBounds;
                tempRectangle.Inflate(-2, -1);
                graphics.DrawRectangle(new Pen(new SolidBrush(Color.Red), 2), tempRectangle);
            }
            //if (_icon != null)
            //    graphics.DrawIcon(_icon, cellBounds.X ,
            //         cellBounds.Y );

            var cellText = formattedValue.ToString();
            var textSize =
                graphics.MeasureString(cellText, fnt);

            //  Calculate the correct color:

            if ((cellState &
                 DataGridViewElementStates.Selected) ==
                DataGridViewElementStates.Selected)
            {
                textColor = parent.InheritedStyle.
                    SelectionForeColor;
            }

            // Draw the text:
            //using (var brush = new SolidBrush(textColor))
            //{
            //    if (_icon != null)
            //        graphics.DrawString(cellText, fnt, brush,
            //                            cellBounds.X + _icon.Width + 2,
            //                            cellBounds.Y + 0);
            //    else
            //        graphics.DrawString(cellText, fnt, brush,
            //                        cellBounds.X,
            //                        cellBounds.Y + 0);
            //}

        }

        public void DrawArrow(Graphics g, Rectangle rc, bool isLeft, bool isDisabled, int arrowSize)
        {
            int xLeft, xRight, yTop, yMidd, yBott;

            xLeft = rc.Left+rc.Width- arrowSize-4;
            xRight = xLeft + arrowSize;
            yMidd = rc.Top + (rc.Height / 2);
            yTop = yMidd - arrowSize;
            yBott = yMidd + arrowSize;

            Point[] array;

            if (isLeft)
            {
                array = new Point[]
					{
						new Point(new Size(xLeft, yMidd)),
						new Point(new Size(xRight, yTop)),
						new Point(new Size(xRight, yBott))
					};
            }
            else
            {
                array = new Point[]
					{
						new Point(new Size(xLeft, yTop)),
						new Point(new Size(xLeft, yBott)),
						new Point(new Size(xRight, yMidd))
					};
            }

            g.DrawPolygon((isDisabled ? SystemPens.GrayText : SystemPens.WindowText), array);
            g.FillPolygon((isDisabled ? SystemBrushes.GrayText : SystemBrushes.WindowText), array);
        }

    }

    public class DataGridViewComplexColumn : DataGridViewColumn
    {
        public DataGridViewComplexColumn()
        {
            CellTemplate =
                new DataGridViewComplexCell();
            ReadOnly = true;
        }
    }

    public class DataGridViewComplexRow : DataGridViewRow
    {
        public override DataGridViewAdvancedBorderStyle AdjustRowHeaderBorderStyle(DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyleInput, DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStylePlaceholder, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedRow, bool isLastVisibleRow)
        {
            dataGridViewAdvancedBorderStylePlaceholder.Top = isFirstDisplayedRow ?
                DataGridViewAdvancedCellBorderStyle.InsetDouble :
                DataGridViewAdvancedCellBorderStyle.None;
            dataGridViewAdvancedBorderStylePlaceholder.Right =
                DataGridViewAdvancedCellBorderStyle.OutsetDouble;

            dataGridViewAdvancedBorderStylePlaceholder.Left =
                dataGridViewAdvancedBorderStyleInput.Left;
            dataGridViewAdvancedBorderStylePlaceholder.Bottom =
                dataGridViewAdvancedBorderStyleInput.Bottom;

            return dataGridViewAdvancedBorderStylePlaceholder;
        }


    }
}
