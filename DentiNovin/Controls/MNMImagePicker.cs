using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DentiNovin.Controls
{
    public partial class MNMImagePicker : ComboBox
    {
        private ImageList _imageList;
        public ImageList ImageList
        {
            get { return _imageList; }
            set
            {
                _imageList = value;
            }
        }


        public MNMImagePicker()
        {
            InitializeComponent();
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += OnDrawItem;
        }

        public void AddImageItems()
        {
            Items.Clear();
            for (int i = 0; i < ImageList.Images.Count; i++)
            {
                Items.Add(ImageList.Images[i]);
            }
        }

        protected void OnDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                // Get this Image
                Image imageSelected = (Image)Items[e.Index];

                // Fill background
                e.DrawBackground();

                // Draw Image box
                Rectangle rect = new Rectangle();
                rect.X = e.Bounds.X;
                rect.Y = e.Bounds.Y;
                rect.Width = e.Bounds.Width;
                rect.Height = e.Bounds.Height - 1;
                e.Graphics.DrawImage(imageSelected, rect);
                // Draw the focus rectangle if appropriate
                if ((e.State & DrawItemState.NoFocusRect) == DrawItemState.None)
                    e.DrawFocusRectangle();
            }
        }

        public new Image SelectedItem
        {
            get
            {
                return (Image)base.SelectedItem;
            }
        }

        public new string SelectedText
        {
            get
            {
                return String.Empty;
            }
            
        }

        public new Image SelectedValue
        {
            get
            {
                return (Image)base.SelectedItem;
            }
        }


    }
}

