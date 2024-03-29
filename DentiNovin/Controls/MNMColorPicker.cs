﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DentiNovin.Controls
{
    public partial class MNMColorPicker : ComboBox
    {
        public class ColorInfo
        {
            public string Text { get; set; }
            public Color Color { get; set; }

            public ColorInfo(string text, Color color)
            {
                Text = text;
                Color = color;
            }
        }
        
        public MNMColorPicker()
        {
            InitializeComponent();
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += OnDrawItem;
        }
       
        public void AddStandardColors()
        {
            Items.Clear();
            Items.Add(new ColorInfo("Black", Color.Black));
            Items.Add(new ColorInfo("Maroon", Color.Maroon));
            Items.Add(new ColorInfo("Green", Color.Green));
            Items.Add(new ColorInfo("Olive", Color.Olive));
            Items.Add(new ColorInfo("Purple", Color.Purple));
            Items.Add(new ColorInfo("Red", Color.Red));
            Items.Add(new ColorInfo("Lime", Color.Lime));
            Items.Add(new ColorInfo("Yellow", Color.Yellow));
            Items.Add(new ColorInfo("Gold", Color.Gold));
            Items.Add(new ColorInfo("Orange", Color.Orange));
            Items.Add(new ColorInfo("Blue", Color.Blue));
        }

        protected void OnDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                // Get this color
                ColorInfo color = (ColorInfo)Items[e.Index];

                // Fill background
                e.DrawBackground();

                // Draw color box
                Rectangle rect = new Rectangle();
                rect.X = e.Bounds.X + 2;
                rect.Y = e.Bounds.Y + 2;
                rect.Width = 18;
                rect.Height = e.Bounds.Height - 5;
                e.Graphics.FillRectangle(new SolidBrush(color.Color), rect);
                e.Graphics.DrawRectangle(SystemPens.WindowText, rect);

                // Write color name
                Brush brush;
                if ((e.State & DrawItemState.Selected) != DrawItemState.None)
                    brush = SystemBrushes.HighlightText;
                else
                    brush = SystemBrushes.WindowText;
                e.Graphics.DrawString(color.Text, Font, brush,
                    e.Bounds.X + rect.X + rect.Width + 2,
                    e.Bounds.Y + ((e.Bounds.Height - Font.Height) / 2));

                // Draw the focus rectangle if appropriate
                if ((e.State & DrawItemState.NoFocusRect) == DrawItemState.None)
                    e.DrawFocusRectangle();
            }
        }

        public new ColorInfo SelectedItem

        {
            get
            {
                return (ColorInfo)base.SelectedItem;
            }
            set
            {
                base.SelectedItem = value;
            }
        }

        public new string SelectedText
        {
            get
            {
                if (SelectedIndex >= 0)
                    return SelectedItem.Text;
                return String.Empty;
            }
            set
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (((ColorInfo)Items[i]).Text == value)
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        public new Color SelectedValue
        {
            get
            {
                if (SelectedIndex >= 0)
                    return SelectedItem.Color;
                return Color.White;
            }
            set
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (((ColorInfo)Items[i]).Color == value)
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
        }


    }
}

