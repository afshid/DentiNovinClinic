using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;
using DentiClinic.BaseClasses;
using DentiClinic.Common;

namespace DentiClinic.Controls
{
    public partial class ToothView : UserControl
    {

        #region Constants
        const int _ellipseOutX = 2;
        const int _ellipseOutY = 53;
        const int _ellipseOutWidth = 43;
        const int _ellipseOutHeight = 43;
        const int _ellipseInX = 14;
        const int _ellipseInY = 65;
        const int _ellipseInWidth = 19;
        const int _ellipseInHeight = 19;
        const int _lineOneX1 = 7;
        const int _lineOneY1 = 59;
        const int _lineOneX2 = 39;//39
        const int _lineOneY2 = 90;
        const int _lineTwoX1 = 40;
        const int _lineTwoY1 = 59;
        const int _lineTwoX2 = 8;//8
        const int _lineTwoY2 = 90;

        const int _rootOneX1 = 24;
        const int _rootOneY1 = 98;
        const int _rootOneX2 = 24;
        const int _rootOneY2 = 126;

        const int _rootTwoX1 = 17;
        const int _rootTwoY1 = 98;
        const int _rootTwoX2 = 24;
        const int _rootTwoY2 = 131;

        const int _rootThreeX1 = 34;
        const int _rootThreeY1 = 98;
        const int _rootThreeX2 = 37;
        const int _rootThreeY2 = 126;

        const int _impactedX1 = 4;
        const int _impactedY1 = 27;
        const int _impactedX2 = 43;
        const int _impactedY2 = 27;

        const int _abcessX = 1;
        const int _abcessY = 12;
        const int _abcessWidth = 43;
        const int _abcessHeight = 14;

        const int _crackedHlineX1 = 16;
        const int _crackedHlineY1 = 41;
        const int _crackedHlineX2 = 32;
        const int _crackedHlineY2 = 41;
        const int _crackedVlineX1 = 7;
        const int _crackedVlineY1 = 66;
        const int _crackedVlineX2 = 7;
        const int _crackedVlineY2 = 84;

        const int _denturelineTopY = 68;
        const int _denturelineDownY = 82;

        #endregion

        #region Fields
        private bool isPopupMode;
        private bool _drawFillEllipseIn;
        private ArrayList _pathsArray;
        private Tooth _currentTooth;
        private bool ToothHide = false;
        private int[,] _angelArray = { { 225, 90 }, { 319, 85 }, { 47, 86 }, { 136, 85 }, { 0, 360 } }; //up,right/down,left,center
        //private int[,] _angelArray = { { 222, 90 }, { 319, 85 }, { 47, 86 }, { 136, 85 }, { 0, 360 } }; //up,right/down,left,center
        private Point[] _openContactR = { new Point(47, 86), new Point(47 - 9, 95), new Point(47, 95) };
        private Point[] _openContactL = { new Point(0, 86), new Point(8, 95), new Point(0, 95) };
        private TreatmentSurface _selectedArea;
        private GraphicsPath _pathData;
        private GraphicsPath _pathUp;
        private GraphicsPath _pathDown;
        private int _activeIndex = -1;
        private ToolTip _toolTip;
        private Graphics _graphics;
        private Color _currentColor = Color.Red;
        public Color _conditionsColor;
        public Color _plannedColor;
        public Color _completedColor;
        private Color _numberingColor;
        private Bitmap _bitmap;
        private Bitmap _bitmapForMissing;
        private Graphics _graphic;
        private GraphicsPath path = new GraphicsPath();
        private Image _toothImage;
        private Image _toothAlternativeImage;
        private Pen activePen1 = new Pen(Color.Red, 1);
        private Pen activePen2 = new Pen(Color.Red, 2);
        private Pen activePen3 = new Pen(Color.Red, 3);
        private SolidBrush selectedBrush = new SolidBrush(Color.Red);
        private HatchBrush LHBrush;// = new HatchBrush(HatchStyle.LightHorizontal, Color.Red, Color.Transparent);
        private HatchBrush FDBrush;// = new HatchBrush(HatchStyle.ForwardDiagonal, Color.Red, Color.Transparent);
        private HatchBrush VBrush;// = new HatchBrush(HatchStyle.Vertical, Color.Red, Color.Transparent);
        private HatchBrush CBrush;// = new HatchBrush(HatchStyle.Cross, Color.Red, Color.Transparent);
        private ToothTreatment _currentToothTreatment;
        private ArrayList _toothTreatmentList;
        private List<TreatmentSurface> surfaceViewList = new List<TreatmentSurface>();
        private ActionMode _tActionMode;

        #endregion

        #region Events
        public event EventHandler ToothClicked;
        public event EventHandler ToothDarwingCompleted;
        public event ToothTypeChangingEventHandler ToothTypeChanging;
        #endregion

        #region Props

        /// <summary>
        /// Is control in popup mode?
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsPopupMode
        {
            get { return isPopupMode; }
            set { isPopupMode = value; }
        }

        public Color CurrentColor
        {
            get { return _currentColor; }
            set { _currentColor = value; }
        }

        public Color ConditionsColor
        {
            get { return _conditionsColor; }
            set { _conditionsColor = value; }
        }

        public Color PlannedColor
        {
            get { return _plannedColor; }
            set { _plannedColor = value; }
        }

        public Color CompletedColor
        {
            get { return _completedColor; }
            set { _completedColor = value; }
        }

        [Browsable(true)]
        public Image ToothImage
        {
            get
            {
                return _toothImage;
            }
            set
            {
                _toothImage = value;
                pictureBox1.Image = _toothImage;
            }
        }

        [Browsable(true)]
        public Image ToothAlternativeImage
        {
            get
            {
                return _toothAlternativeImage;
            }
            set
            {
                _toothAlternativeImage = value;
            }
        }

        public Tooth CurrentTooth
        {
            get { return _currentTooth; }
            set { _currentTooth = value; }
        }

        public ArrayList ToothTreatmentList
        {
            get
            {
                return _toothTreatmentList;
            }
            set
            {
                _toothTreatmentList = value;
            }
        }

        public ToothTreatment CurrentToothTreatment
        {
            get { return _currentToothTreatment; }
            set { _currentToothTreatment = value; }
        }

        public ActionMode TActionMode
        {
            get { return _tActionMode; }
            set { _tActionMode = value; }
        }

        public bool AllowContinue { get; set; }

        #endregion


        public ToothView(bool popupMode)
        {
            SolidBrush whiteBrush = new SolidBrush(Color.WhiteSmoke);
            Pen apen = new Pen(Color.Gray, 3);
            IsPopupMode = popupMode;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            base.Size = new Size(238, 200);
            base.Font = new Font("Tahoma", 8.25F);
            this._pathsArray = new ArrayList();
            this._pathData = new GraphicsPath();
            this._pathData.FillMode = FillMode.Winding;

            this._pathUp = new GraphicsPath();
            this._pathUp.FillMode = FillMode.Winding;
            this._pathDown = new GraphicsPath();
            this._pathDown.FillMode = FillMode.Winding;

            this.components = new Container();
            this._toolTip = new ToolTip(this.components);
            this._toolTip.AutoPopDelay = 5000;
            this._toolTip.InitialDelay = 1000;
            this._toolTip.ReshowDelay = 500;
            InitializeComponent();

            this._graphics = Graphics.FromHwnd(this.pictureBox1.Handle);

            this.AddPolygon("Up", new Point[] { new Point(16, 66), new Point(9, 60), new Point(23, 55), new Point(14, 55), new Point(39, 60), new Point(32, 66), new Point(23, 63), new Point(16, 66) });
            this.AddPolygon("Right", new Point[] { new Point(34, 67), new Point(40, 61), new Point(45, 74), new Point(40, 88), new Point(34, 82), new Point(35, 74), new Point(34, 67) });
            this.AddPolygon("Down", new Point[] { new Point(31, 84), new Point(38, 90), new Point(24, 95), new Point(10, 95), new Point(17, 84), new Point(24, 86), new Point(31, 84) });
            this.AddPolygon("Left", new Point[] { new Point(15, 82), new Point(8, 88), new Point(3, 75), new Point(8, 62), new Point(15, 67), new Point(13, 75), new Point(15, 82) });
            this.AddPolygon("Center", new Point[] { new Point(15, 75), new Point(17, 69), new Point(24, 66), new Point(31, 69), new Point(31, 71), new Point(32, 73), new Point(30, 71), new Point(24, 83), new Point(15, 75) });
            this.AddPolygon("UpTooth", new Point[] { new Point(9, 59), new Point(14, 54), new Point(23, 54), new Point(39, 59), new Point(23, 4), new Point(14, 4), new Point(9, 59) });
            this.AddPolygon("DownTooth", new Point[] { new Point(38, 91), new Point(24, 96), new Point(17, 96), new Point(10, 91), new Point(17, 140), new Point(24, 140), new Point(38, 90) });

            //this._pathUp.AddLines(new Point[] { new Point(13, 55), new Point(15, 54), new Point(23, 52), new Point(31, 54), new Point(33, 55), new Point(31, 45), new Point(23, 40), new Point(17, 45), new Point(13, 55) });
            //this._pathUp.AddArc(_ellipseOutX, _ellipseOutY - 1, _ellipseOutWidth, _ellipseOutHeight, 240, 60);
            this._pathUp.AddArc(_ellipseOutX + 7, _ellipseOutY - 11 ,_ellipseOutWidth - 15, _ellipseOutHeight + 15, 240, 60);
            this._pathUp.AddArc(_ellipseOutX + 7, _ellipseOutY - 11, _ellipseOutWidth - 15, _ellipseOutHeight + 15, 240, 60);
           // this._pathUp.AddArc(_ellipseOutX, _ellipseOutY - 1, _ellipseOutWidth, _ellipseOutHeight, 240, 60);

            this._pathDown.AddArc(_ellipseOutX + 7, _ellipseOutY -4, _ellipseOutWidth - 15, _ellipseOutHeight + 15, 60, 60);
            this._pathDown.AddArc(_ellipseOutX + 7, _ellipseOutY -4, _ellipseOutWidth - 15, _ellipseOutHeight + 15, 60, 60);
            
            //_bitmap = new Bitmap(_toothImage, pictureBox1.Size.Width, pictureBox1.Size.Height);
            //_graphic = Graphics.FromImage(_bitmap);

            //DrawToothArea(_graphic);
            // pictureBox1.Image = _bitmap;
        }

        /// <summary>
        /// Creates a new instance of ToothView for normal mode usage.
        /// </summary>
        public ToothView()
            : this(false)
        {
        }

        public void OnToothClicked()
        {
            if (ToothClicked != null)
                ToothClicked(this, null);
        }

        public void OnToothDarwingCompleted()
        {
            if (ToothDarwingCompleted != null)
                ToothDarwingCompleted(this, null);
        }

        private void OnToothTypeChanging(ToothTypeChangeMode tTCM)
        {
            if (ToothTypeChanging != null)
                ToothTypeChanging(this, tTCM);
        }

        private void ToothView_Load(object sender, EventArgs e)
        {
            _bitmapForMissing = new Bitmap(this.Size.Width, this.Size.Height);
            _bitmap = new Bitmap(ToothImage, pictureBox1.Size.Width, pictureBox1.Size.Height);
            _graphic = Graphics.FromImage(_bitmap);
            //DrawToothNumber();
            DrawToothArea(_graphic);
            pictureBox1.Image = _bitmap;
        }

        public int AddPolygon(string key, Point[] points)
        {
            if (this._pathsArray.Count > 0)
                this._pathData.SetMarkers();
            this._pathData.AddPolygon(points);
            return this._pathsArray.Add(key);
        }

        private int getActiveIndexAtPoint(Point point)
        {

            GraphicsPathIterator iterator = new GraphicsPathIterator(_pathData);
            iterator.Rewind();
            for (int current = 0; current < iterator.SubpathCount; current++)
            {
                iterator.NextMarker(path);
                if (path.IsVisible(point, this._graphics))
                    return current;
            }
            return -1;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int newIndex = this.getActiveIndexAtPoint(new Point(e.X, e.Y));

            if (newIndex > -1)
                // if(!ToothHide)
                pictureBox1.Cursor = Cursors.Hand;
                
            else
                pictureBox1.Cursor = Cursors.Default;
            this._activeIndex = newIndex;
        }

        public Point p;

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this._activeIndex = -1;
            this.Cursor = Cursors.Default;
        }

        private void DrawToothArea(Graphics graphic)
        {
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            _drawFillEllipseIn = true;
            graphic.FillEllipse(whiteBrush, _ellipseOutX, _ellipseOutY, _ellipseOutWidth, _ellipseOutHeight);
            graphic.DrawEllipse(new Pen(Color.Gray, 2), _ellipseOutX, _ellipseOutY, _ellipseOutWidth, _ellipseOutHeight);
            graphic.DrawLine(new Pen(Color.Black, 2), _lineOneX1, _lineOneY1, _lineOneX2, _lineOneY2);
            graphic.DrawLine(new Pen(Color.Black, 2), _lineTwoX1, _lineTwoY1, _lineTwoX2, _lineTwoY2);
            graphic.FillEllipse(whiteBrush, _ellipseInX, _ellipseInY, _ellipseInWidth, _ellipseInHeight);
            graphic.DrawEllipse(new Pen(Color.Gray, 2), _ellipseInX, _ellipseInY, _ellipseInWidth, _ellipseInHeight);

        }

        public void ApplySurfaceView(ToothTreatment selectedToothTreatment)
        {
            if (selectedToothTreatment.Tooth.Type != this.CurrentTooth.Type)
                return;
            SetCurrentColor(selectedToothTreatment.Status);
            DrawTreatmentSurface((TreatmentDrawType)selectedToothTreatment.Treatment.DrawType, (DrawingBrushType)selectedToothTreatment.Treatment.BruchType, selectedToothTreatment.Surface, _graphic, selectedToothTreatment.Tooth.Number, selectedToothTreatment.Tooth.Direction, CurrentColor);
        }

        private string GenerateSurfaceCode(int[] intSurface)
        {
            string Surface = string.Empty;
            return Surface;
        }

        private void DrawTreatmentSurface(TreatmentDrawType DrawType, DrawingBrushType BruchType, ArrayList surfaceViewList, Graphics UsedGraphic, int ToothNumber, int ToothDirection, Color SelectedColor)
        {

            activePen1.Color = SelectedColor;
            activePen2.Color = SelectedColor;
            activePen3.Color = SelectedColor;
            selectedBrush.Color = SelectedColor;
            activePen3.StartCap = LineCap.NoAnchor;
            activePen3.EndCap = LineCap.NoAnchor;


            Brush currentSelectedBrush = null;

            switch (BruchType)
            {
                case DrawingBrushType.Solid:
                    currentSelectedBrush = new SolidBrush(SelectedColor);
                    break;
                case DrawingBrushType.HorizontalLines:
                    currentSelectedBrush = new HatchBrush(HatchStyle.LightHorizontal, SelectedColor, Color.Transparent);
                    break;
                case DrawingBrushType.VerticalLines:
                    currentSelectedBrush = new HatchBrush(HatchStyle.Vertical, SelectedColor, Color.Transparent);
                    break;
                case DrawingBrushType.Diagonal:
                    currentSelectedBrush = new HatchBrush(HatchStyle.ForwardDiagonal, SelectedColor, Color.Transparent);
                    break;
                case DrawingBrushType.CrossLines:
                    currentSelectedBrush = new HatchBrush(HatchStyle.Cross, SelectedColor, Color.Transparent);
                    break;
                case DrawingBrushType.DiagonalCross:
                    currentSelectedBrush = new HatchBrush(HatchStyle.DiagonalCross, SelectedColor, Color.Transparent);
                    break;
                default:
                    currentSelectedBrush = new HatchBrush(HatchStyle.LightHorizontal, SelectedColor, Color.Transparent);
                    break;
            }

            int _areaNumber = 0;
            //DrawToothArea(Graphics graphic)
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            switch (DrawType)
            {
                case TreatmentDrawType.None:
                    break;
                case TreatmentDrawType.Fill:

                    foreach (TreatmentSurface ts in surfaceViewList)
                    {

                        _areaNumber = GetAreaNumber(ts, ToothNumber, ToothDirection);

                        switch (_areaNumber)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                                // UsedGraphic.FillPie(selectedBrush, _ellipseOutX, _ellipseOutY, _ellipseOutWidth, _ellipseOutHeight, _angelArray[_areaNumber - 1, 0], _angelArray[_areaNumber - 1, 1]);
                                UsedGraphic.DrawArc(new Pen(selectedBrush.Color, 11), _ellipseOutX + 6, _ellipseOutY + 6, _ellipseOutWidth - 12, _ellipseOutHeight - 12, _angelArray[_areaNumber - 1, 0], _angelArray[_areaNumber - 1, 1]);
                                //if (_drawFillEllipseIn)
                                //    UsedGraphic.FillEllipse(whiteBrush, _ellipseInX, _ellipseInY, _ellipseInWidth, _ellipseInHeight);
                                UsedGraphic.DrawEllipse(new Pen(Color.Gray, 2), _ellipseInX, _ellipseInY, _ellipseInWidth, _ellipseInHeight);
                                break;
                            case 5:

                                UsedGraphic.FillPie(selectedBrush, _ellipseInX, _ellipseInY, _ellipseInWidth, _ellipseInHeight, _angelArray[_areaNumber - 1, 0], _angelArray[_areaNumber - 1, 1]);

                                UsedGraphic.DrawEllipse(new Pen(Color.Gray, 2), _ellipseInX, _ellipseInY, _ellipseInWidth, _ellipseInHeight);
                                _drawFillEllipseIn = false;
                                break;
                            case 6:
                                //UsedGraphic.FillEllipse(selectedBrush, _ellipseInX, _ellipseOutY - 12, _ellipseInWidth, _ellipseInHeight + 5);
                                 //UsedGraphic.DrawArc(new Pen(selectedBrush.Color, 2), _ellipseOutX, _ellipseOutY-1, _ellipseOutWidth, _ellipseOutHeight, 240, 60);
                                 //UsedGraphic.DrawArc(new Pen(selectedBrush.Color, 2), _ellipseOutX+7, _ellipseOutY - 10, _ellipseOutWidth-15, _ellipseOutHeight+15, 240, 60);
                                //UsedGraphic.DrawEllipse(new Pen(Color.Gray, 2), _ellipseOutX, _ellipseOutY, _ellipseOutWidth, _ellipseOutHeight);
                                //UsedGraphic.DrawClosedCurve(new Pen(selectedBrush.Color, 2), new Point[] { new Point(9, 59), new Point(23, 54), new Point(14, 54), new Point(39, 59), new Point(15, 44), new Point(23, 44), new Point(9, 59) });
                                UsedGraphic.FillPath(selectedBrush, this._pathUp);
                                break;
                            case 7:
                                // UsedGraphic.FillEllipse(selectedBrush, _ellipseInX, _ellipseOutY + _ellipseInHeight + 12, _ellipseInWidth, _ellipseInHeight + 5);
                                UsedGraphic.FillPath(selectedBrush, this._pathDown);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case TreatmentDrawType.Implant:
                   // UsedGraphic.DrawImage(DentiClinic.Properties.Resources.Implant, 0, 0);
                    _bitmap = (Bitmap)DentiClinic.Properties.Resources.Implant;
                    _graphic = Graphics.FromImage(_bitmap);
                    DrawToothNumber();
                    DrawToothArea(_graphic);
                    pictureBox1.Image = _bitmap;
                    break;
                case TreatmentDrawType.RootCanal:
                    int addpos = 0;
                    int x1 = 0;
                    int x2 = 0;
                    int x3 = 0;
                    int x4 = 0;
                    bool flip = false;
                    switch (ToothDirection)
                    {
                        case 2:
                        case 3:
                        case 6:
                        case 8:
                            addpos = 2;
                            flip = true;

                            break;
                        default:
                            break;
                    }
                    switch ((int)this.CurrentTooth.RootType)
                    {
                        case 1:
                            UsedGraphic.DrawLine(activePen2, _rootOneX1, _rootOneY1, _rootOneX2, _rootOneY2);
                            UsedGraphic.FillRectangle(selectedBrush, _rootOneX2 - addpos, _rootOneY2, 2, 1);
                            break;
                        case 2:

                            if (flip == true)
                            {
                                x1 = (_rootOneX1 - (this.Width / 2)) * 2;
                                x2 = (_rootOneX2 - (this.Width / 2)) * 2 + 8;
                                x3 = (_rootTwoX1 - (this.Width / 2)) * 2;
                                x4 = (_rootTwoX2 - (this.Width / 2)) * 2;
                            }

                            //if ((ToothDirection == 2 && ToothNumber == 4) || (ToothDirection == 1 && ToothNumber == 4))
                            //{
                            if ((this.CurrentTooth.Code == 5) || (this.CurrentTooth.Code == 12))
                            {
                                UsedGraphic.DrawLine(activePen2, _rootOneX1 - x1, _rootOneY1, _rootOneX2 - x2 + 4, _rootOneY2);
                                UsedGraphic.FillRectangle(selectedBrush, _rootOneX2 - x2 + 4 - addpos, _rootOneY2, 2, 1);
                                UsedGraphic.DrawLine(activePen2, _rootTwoX1 - x3, _rootTwoY1, _rootTwoX2 - x4, _rootTwoY2);
                                UsedGraphic.FillRectangle(selectedBrush, _rootTwoX2 - x4 - addpos, _rootTwoY2, 2, 1);
                                return;
                            }
                            UsedGraphic.DrawLine(activePen2, _rootOneX1, _rootOneY1, _rootOneX2, _rootOneY2);
                            UsedGraphic.FillRectangle(selectedBrush, _rootOneX2 - addpos, _rootOneY2, 2, 1);


                            break;
                        case 3:
                            if (flip == true)
                            {
                                x1 = (_rootOneX1 - (this.Width / 2)) * 2;
                                x2 = (_rootOneX2 - (this.Width / 2)) * 2 + 8;
                                x3 = (_rootTwoX1 - (this.Width / 2)) * 2;
                                x4 = (_rootTwoX2 - (this.Width / 2)) * 2;
                            }
                            UsedGraphic.DrawLine(activePen2, _rootOneX1, _rootOneY1, _rootOneX2, _rootOneY2);
                            UsedGraphic.FillRectangle(selectedBrush, _rootOneX2 - addpos, _rootOneY2, 2, 1);
                            UsedGraphic.DrawLine(activePen2, _rootOneX1 - 10, _rootOneY1 - 4, _rootOneX2 - 10, _rootOneY2);
                            UsedGraphic.FillRectangle(selectedBrush, _rootOneX2 - 10 + addpos, _rootOneY2, 2, 1);
                            UsedGraphic.DrawLine(activePen2, _rootThreeX1, _rootThreeY1, _rootThreeX2, _rootThreeY2);
                            UsedGraphic.FillRectangle(selectedBrush, _rootThreeX2 + addpos, _rootThreeY2, 2, 1);

                            break;
                    }
                    break;
                case TreatmentDrawType.ArrowMesial:
                    activePen3.EndCap = LineCap.ArrowAnchor;
                    UsedGraphic.FillRectangle(selectedBrush, _impactedX1 - 1, _impactedY1 + 1, 2, 1);
                    UsedGraphic.DrawLine(activePen3, _impactedX1, _impactedY1, _impactedX2, _impactedY2);
                    break;
                case TreatmentDrawType.ArrowDistal:
                    activePen3.StartCap = LineCap.ArrowAnchor;
                    UsedGraphic.FillRectangle(selectedBrush, _impactedX2 + 1, _impactedY2 + 1, 2, 1);

                    UsedGraphic.DrawLine(activePen3, _impactedX1, _impactedY1, _impactedX2, _impactedY2);
                    break;
                case TreatmentDrawType.CircledRoot:
                    UsedGraphic.DrawEllipse(activePen1, _abcessX, _abcessY, _abcessWidth, _abcessHeight);
                    break;
                case TreatmentDrawType.HighlightNumber:
                    break;
                case TreatmentDrawType.HypersensitiveLine:
                    DrawHashourR(new Point(40, 54), new Point(45, 44), UsedGraphic, activePen1);
                    DrawHashourL(new Point(8, 54), new Point(2, 44), UsedGraphic, activePen1);
                    break;
                case TreatmentDrawType.Recession:
                    UsedGraphic.DrawLine(activePen2, _impactedX1, _crackedHlineY1, _impactedX2, _crackedHlineY2);
                    UsedGraphic.FillRectangle(selectedBrush, _impactedX1 - 1, _crackedHlineY1, 2, 1);

                    break;
                case TreatmentDrawType.Crack:
                    foreach (TreatmentSurface ts in surfaceViewList)
                    {
                        _areaNumber = GetAreaNumber(ts, ToothNumber, ToothDirection);

                        switch (_areaNumber)
                        {
                            case 1:
                                DrawWave(new Point(_crackedHlineX1, _crackedHlineY1 - ((_crackedHlineY1 - this.Height / 2) / 2)), new Point(_crackedHlineX2, _crackedHlineY2 - ((_crackedHlineY2 - this.Height / 2) / 2)), UsedGraphic, activePen2, true);
                                break;
                            case 2:
                                DrawWave(new Point(_crackedVlineX1 - ((_crackedVlineX1 - this.Width / 2) * 2), _crackedVlineY1), new Point(_crackedVlineX2 - ((_crackedVlineX2 - this.Width / 2) * 2), _crackedVlineY2), UsedGraphic, activePen2, false);
                                break;
                            case 3:
                                DrawWave(new Point(_crackedHlineX1, _crackedHlineY1 - (int)((_crackedHlineY1 - this.Height / 2) * 1.4)), new Point(_crackedHlineX2, _crackedHlineY2 - (int)((_crackedHlineY2 - this.Height / 2) * 1.4)), UsedGraphic, activePen2, true);
                                break;
                            case 4:
                                DrawWave(new Point(_crackedVlineX1, _crackedVlineY1), new Point(_crackedVlineX2, _crackedVlineY2), UsedGraphic, activePen2, false);
                                break;
                            case 5:
                                DrawWave(new Point(_crackedHlineX1, _crackedHlineY1-2 - (_crackedHlineY1 - this.Height / 2)), new Point(_crackedHlineX2, _crackedHlineY2 -2- (_crackedHlineY2 - this.Height / 2)), UsedGraphic, activePen2, true);
                                break;
                            case 6:
                                DrawWave(new Point(_crackedHlineX1, _crackedHlineY1), new Point(_crackedHlineX2, _crackedHlineY2), UsedGraphic, activePen2, true);
                                break;
                            case 7:
                                DrawWave(new Point(_crackedHlineX1, _crackedHlineY1 - ((_crackedHlineY1 - this.Height / 2) * 2)), new Point(_crackedHlineX2, _crackedHlineY2 - ((_crackedHlineY2 - this.Height / 2) * 2)), UsedGraphic, activePen2, true);
                                break;
                            default:
                                break;
                        }


                    }

                    break;
                case TreatmentDrawType.OpenContactMesial:
                    switch (ToothDirection)
                    {
                        case 2:
                        case 3:
                            UsedGraphic.FillPolygon(selectedBrush, _openContactR);
                            break;
                        case 1:
                        case 4:
                            UsedGraphic.FillPolygon(selectedBrush, _openContactL);
                            break;
                    }
                    break;
                case TreatmentDrawType.OpenContactDistal:
                    switch (ToothDirection)
                    {
                        case 2:
                        case 3:
                            UsedGraphic.FillPolygon(selectedBrush, _openContactL);
                            break;
                        case 1:
                        case 4:
                            UsedGraphic.FillPolygon(selectedBrush, _openContactR);
                            break;
                    }

                    break;
                case TreatmentDrawType.CircledOcclusal:
                    UsedGraphic.DrawEllipse(activePen2, _ellipseOutX, _ellipseOutY, _ellipseOutWidth, _ellipseOutHeight);
                    break;
                case TreatmentDrawType.VerticalLines:
                    break;
                case TreatmentDrawType.Crown:
                    UsedGraphic.FillEllipse(currentSelectedBrush, _ellipseOutX, _ellipseOutY, _ellipseOutWidth, _ellipseOutHeight);
                    break;
                case TreatmentDrawType.SurfaceOutline:
                    foreach (TreatmentSurface ts in surfaceViewList)
                    {
                        _areaNumber = GetAreaNumber(ts, ToothNumber, ToothDirection);

                        switch (_areaNumber)
                        {
                            case 5:
                                UsedGraphic.DrawArc(activePen2, _ellipseInX, _ellipseInY, _ellipseInWidth, _ellipseInHeight, _angelArray[_areaNumber - 1, 0], _angelArray[_areaNumber - 1, 1]);
                                break;
                            case 6:
                                UsedGraphic.DrawPath(new Pen(selectedBrush.Color, 2), this._pathUp);
                                break;
                            case 7:
                                UsedGraphic.DrawPath(new Pen(selectedBrush.Color, 2), this._pathDown);
                                break;

                            default:
                                UsedGraphic.DrawArc(activePen2, _ellipseOutX, _ellipseOutY, _ellipseOutWidth, _ellipseOutHeight, _angelArray[_areaNumber - 1, 0], _angelArray[_areaNumber - 1, 1]);
                                break;
                        }
                    }
                    break;
                case TreatmentDrawType.S:
                    UsedGraphic.DrawString("S", new Font("Tahoma", 20, FontStyle.Bold), selectedBrush, new PointF(_ellipseInX - 2, _ellipseInY - 8));
                    break;
                case TreatmentDrawType.HalfRootCanal:
                    break;
                case TreatmentDrawType.Denture:
                    UsedGraphic.DrawLine(activePen3, 0, _denturelineTopY, this.Width, _denturelineTopY);
                    UsedGraphic.DrawLine(activePen3, 0, _denturelineDownY, this.Width, _denturelineDownY);
                    break;
                case TreatmentDrawType.Bridge:
                    _bitmap = (Bitmap)_bitmapForMissing.Clone();
                    _graphic = Graphics.FromImage(_bitmap);
                    DrawToothNumber();
                    _graphic.FillEllipse(currentSelectedBrush, _ellipseOutX, _ellipseOutY, _ellipseOutWidth, _ellipseOutHeight);
                    _graphic.FillRectangle(currentSelectedBrush, 0, _lineOneY1, this.Width, _lineTwoY2 - _lineOneY1);
                    break;
                case TreatmentDrawType.X:
                    // UsedGraphic.FillEllipse(whiteBrush, _ellipseInX, _ellipseInY, _ellipseInWidth, _ellipseInHeight);
                    UsedGraphic.DrawLine(activePen2, pictureBox1.Top, pictureBox1.Left, pictureBox1.Size.Width, pictureBox1.Size.Height);
                    UsedGraphic.DrawLine(activePen2, pictureBox1.Top + pictureBox1.Size.Width, pictureBox1.Left, pictureBox1.Top, pictureBox1.Size.Height);

                    break;
                case TreatmentDrawType.HideTooth:
                    _bitmap = (Bitmap)_bitmapForMissing.Clone();
                    ToothHide = true;
                    _graphic = Graphics.FromImage(_bitmap);
                    DrawToothNumber();
                    pictureBox1.Image = _bitmap;
                    break;
                case TreatmentDrawType.Veneer:
                    UsedGraphic.DrawArc(activePen2, 2, _ellipseOutY - 5, _ellipseOutWidth, _ellipseOutHeight - 25, 185, 170);
                    break;
                default:
                    break;
            }


        }

        public void ApplyExistTreatmentList()
        {
            ResetSurfacesView();
            foreach (ToothTreatment currentTT in this.ToothTreatmentList)
            {
                if (currentTT.Treatment.DrawType != (int)TreatmentDrawType.None && (currentTT.Tooth.Equals(this.CurrentTooth) || (currentTT.Treatment.TreatmentArea == (int)TreatmentArea.Maxillary || currentTT.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular)) && currentTT.Status != TreatmentStatus.Declined)
                {
                    if ((currentTT.Treatment.TreatmentArea == (int)TreatmentArea.Maxillary && this.CurrentTooth.Code > 16) || (currentTT.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular && this.CurrentTooth.Code < 17))
                        continue;
                    ApplySurfaceView(currentTT);
                }
            }
            pictureBox1.Image = _bitmap;
        }

        public void ResetSurfacesView()
        {
            bool _showToothArea = true;
            if (_bitmap != null)
                _bitmap.Dispose();
            if (_graphic != null)
                _graphic.Dispose();
            if (this.CurrentTooth.Type == ToothType.Primary)
            {
                if (this.ToothAlternativeImage != null)
                    _bitmap = new Bitmap(this.ToothAlternativeImage, pictureBox1.Size.Width, pictureBox1.Size.Height);
                else
                {
                    _bitmap = (Bitmap)_bitmapForMissing.Clone();
                    _showToothArea = false;
                }
            }
            else
                _bitmap = new Bitmap(ToothImage, pictureBox1.Size.Width, pictureBox1.Size.Height);

            _graphic = Graphics.FromImage(_bitmap);
            if (_showToothArea)
                DrawToothArea(_graphic);
            DrawToothNumber();
            this.pictureBox1.Image = _bitmap;
        }

        private int GetAreaNumber(TreatmentSurface selectedSurface, int selectedTNumber, int selectedTDirection)
        {
            switch (selectedSurface)
            {
                case TreatmentSurface.B:
                case TreatmentSurface.F:
                    if (selectedTDirection == 1 || selectedTDirection == 2)
                        return 1;
                    else
                        return 3;
                case TreatmentSurface.L:
                    if (selectedTDirection == 1 || selectedTDirection == 2)
                        return 3;
                    else
                        return 1;
                case TreatmentSurface.D:
                    if (selectedTDirection == 1 || selectedTDirection == 4)
                        return 2;
                    else
                        return 4;
                case TreatmentSurface.M:
                    if (selectedTDirection == 1 || selectedTDirection == 4)
                        return 4;
                    else
                        return 2;
                case TreatmentSurface.O:
                case TreatmentSurface.I:
                    return 5;
                case TreatmentSurface.B5:
                case TreatmentSurface.F5:
                    if (selectedTDirection == 1 || selectedTDirection == 2)
                        return 6;
                    else
                        return 7;
                case TreatmentSurface.L5:
                    if (selectedTDirection == 1 || selectedTDirection == 2)
                        return 7;
                    else
                        return 6;
                default:
                    return 0;
            }
        }

        private string GetCustomToothNumber()
        {
            _numberingColor = Color.Black;
            if (this.CurrentTooth.Type == ToothType.Primary)
            {
                _numberingColor = Color.Red;
                return this.CurrentTooth.PrimaryNumber;
            }

            else
                return this.CurrentTooth.Number.ToString();
        }

        private TreatmentSurface GetAreaSurfaceCode(int areaNumber)
        {
            switch (areaNumber)
            {
                case 1:
                    if (this.CurrentTooth.Code> 16)
                        return TreatmentSurface.L;
                    else
                        if (this.CurrentTooth.RootType != ToothRootType.Anterior)
                            return TreatmentSurface.B;
                        else
                            return TreatmentSurface.F;
                case 2:
                    if (this.CurrentTooth.Code <=24 && this.CurrentTooth.Code>=9)
                        return TreatmentSurface.D;
                    else
                        return TreatmentSurface.M;
                case 3:
                    if (this.CurrentTooth.Code <=16)
                        return TreatmentSurface.L;
                    else
                        if (this.CurrentTooth.RootType != ToothRootType.Anterior)
                            return TreatmentSurface.B;
                        else
                            return TreatmentSurface.F;
                case 4:
                    if (this.CurrentTooth.Code <= 24 && this.CurrentTooth.Code >= 9)
                        return TreatmentSurface.M;
                    else
                        return TreatmentSurface.D;
                case 5:
                    if (this.CurrentTooth.RootType != ToothRootType.Anterior)
                        return TreatmentSurface.O;
                    else
                        return TreatmentSurface.I;
                case 6:
                    if (this.CurrentTooth.Code > 16)
                        return TreatmentSurface.L5;
                    else
                        if (this.CurrentTooth.RootType != ToothRootType.Anterior)
                            return TreatmentSurface.B5;
                        else
                            return TreatmentSurface.F5;
                case 7:
                    if (this.CurrentTooth.Code <= 16)
                        return TreatmentSurface.L5;
                    else
                        if (this.CurrentTooth.RootType != ToothRootType.Anterior)
                            return TreatmentSurface.B5;
                        else
                            return TreatmentSurface.F5;
                default:
                    return TreatmentSurface.OutOfArea;
                    break;
            }
        }

        private void DrawWave(Point start, Point end, Graphics usedGraphic, Pen selectedPen, bool horizontal)
        {
            ArrayList pl = new ArrayList();
            Point[] p = null;
            if (horizontal)
            {
                for (int i = start.X; i < end.X; i += 4)
                {
                    pl.Add(new Point(i, start.Y));
                    pl.Add(new Point(i + 2, start.Y + 2));
                }
                p = (Point[])pl.ToArray(typeof(Point));

            }
            else
            {
                for (int i = start.Y; i < end.Y; i += 4)
                {
                    pl.Add(new Point(start.X, i));
                    pl.Add(new Point(start.X + 2, i + 2));
                }
                p = (Point[])pl.ToArray(typeof(Point));
            }
            usedGraphic.DrawLines(selectedPen, p);

        }

        private void DrawHashourR(Point start, Point end, Graphics usedGraphic, Pen selectedPen)
        {
            int j = 0;
            for (int i = start.X; i < end.X; i += 2)
            {

                usedGraphic.DrawLine(selectedPen, new Point(i, start.Y - j), new Point(i + 4, start.Y + 4 - j));
                j += 2;
            }
        }

        private void DrawHashourL(Point start, Point end, Graphics usedGraphic, Pen selectedPen)
        {
            int j = 0;
            for (int i = start.X; i > end.X; i -= 2)
            {
                usedGraphic.DrawLine(selectedPen, new Point(i, start.Y - j), new Point(i - 4, start.Y + 4 - j));
                j += 2;
            }

        }

        public void DrawToothNumber()
        {
            _graphic.DrawString(GetCustomToothNumber(), new Font("Microsoft Sans Serif", 9, FontStyle.Regular), new SolidBrush(_numberingColor), new PointF(1, this.Height - 15));
        }

        private Point FlipHorizontalPoint(Point oldPoint)
        {
            //Point basePoint = new Point(this.Width / 2, this.Height / 2);
            Point newPoint = new Point(0, 0);
            //newPoint.X =(int) (Math.Cos(90) * (oldPoint.X - basePoint.X) - Math.Sign(90) * (oldPoint.Y - basePoint.Y) + basePoint.X);
            //newPoint.Y =(int) (Math.Sin(90) * (oldPoint.X - basePoint.X) - Math.Cos(90) * (oldPoint.Y - basePoint.Y) + basePoint.Y);

            //newPoint.X = (p.x * Math.Cos(theta)) - (p.y * Math.Sin(theta));
            //newPoint.Y = (p.y * Math.Cos(theta)) + (p.x * Math.Sin(theta));


            return newPoint;
        }

        private void SetCurrentColor(TreatmentStatus currentTreatmentStatus)
        {
            switch (currentTreatmentStatus)
            {
                case TreatmentStatus.None:
                    break;
                case TreatmentStatus.Completed:
                    this.CurrentColor = this.CompletedColor;
                    break;
                case TreatmentStatus.Planned:
                    this.CurrentColor = this.PlannedColor;
                    break;
                case TreatmentStatus.Condition:
                    this.CurrentColor = this.ConditionsColor;
                    break;
                case TreatmentStatus.Declined:
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    ToothClick(e.Location);
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:

                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }

        private void ToothClick(Point mouseClickPoint)
        {
            OnToothClicked();
            if (!AllowContinue)
                return;
            // p = this.PointToClient(Cursor.Position);
            if (this._activeIndex == -1)
                // this.getActiveIndexAtPoint(p);
                this.getActiveIndexAtPoint(mouseClickPoint);

            if (this._activeIndex > -1 || this.CurrentToothTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Maxillary || this.CurrentToothTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular)
            {
                if (this.CurrentToothTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Maxillary || this.CurrentToothTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Mandibular)
                {
                    OnToothDarwingCompleted();
                    return;
                }
                ToothTreatment _selectToothTreatment;
                _selectToothTreatment = new ToothTreatment();
                _selectToothTreatment.Tooth = this.CurrentToothTreatment.Tooth;
                _selectToothTreatment.Treatment = this.CurrentToothTreatment.Treatment;
                _selectToothTreatment.Status = this.CurrentToothTreatment.Status;

                if (this.ToothTreatmentList.Contains(this.CurrentToothTreatment))
                {
                    if (this.CurrentToothTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Surface)
                    {
                        foreach (ToothTreatment tt in this.ToothTreatmentList)
                        {
                            if (this.CurrentToothTreatment.Equals(tt))
                            {
                                _selectedArea = GetAreaSurfaceCode(_activeIndex + 1);
                                this.CurrentToothTreatment.PatientTreatmentID = tt.PatientTreatmentID;
                                TActionMode = ActionMode.update;
                                if (tt.Surface.Contains(_selectedArea))
                                {
                                    tt.Surface.Remove(_selectedArea);
                                    foreach (TreatmentSurface item in tt.Surface)
                                    {
                                        CurrentToothTreatment.Surface.Add(item);
                                    }
                                    if (tt.Surface.Count == 0)
                                    {
                                        this.ToothTreatmentList.Remove(tt);
                                        TActionMode = ActionMode.Remove;
                                    }
                                    if (this.CurrentToothTreatment.Treatment.DrawType != (int)TreatmentDrawType.None)
                                        ApplyExistTreatmentList();
                                }
                                else
                                {
                                    //this.CurrentToothTreatment.Surface.Add(_selectedArea);
                                    tt.Surface.Add(_selectedArea);
                                    this.CurrentToothTreatment.Surface.Clear();
                                    foreach (TreatmentSurface item in tt.Surface)
                                    {
                                        CurrentToothTreatment.Surface.Add(item);
                                    }
                                    if (this.CurrentToothTreatment.Treatment.DrawType != (int)TreatmentDrawType.None)
                                        // DrawTreatmentSurface((TreatmentDrawType)this.CurrentToothTreatment.Treatment.DrawType, (DrawingBrushType)this.CurrentToothTreatment.Treatment.BruchType, this.CurrentToothTreatment.Surface, _graphic, this.CurrentTooth.Number, this.CurrentTooth.Direction, CurrentColor);
                                        ApplySurfaceView(CurrentToothTreatment);
                                }

                                break;
                            }
                        }
                    }
                    else
                    {
                        //if (this.CurrentToothTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Root)
                        //{
                        //    RootCanalForm aRootCanalForm = new RootCanalForm();
                        //    aRootCanalForm.TopMost = true;
                        //    aRootCanalForm.ShowDialog();
                        //}
                        foreach (ToothTreatment tt in this.ToothTreatmentList)
                        {
                            if (this.CurrentToothTreatment.Equals(tt))
                            {
                                this.CurrentToothTreatment.PatientTreatmentID = tt.PatientTreatmentID;
                                break;
                            }
                        }
                        this.ToothTreatmentList.Remove(_selectToothTreatment);
                        TActionMode = ActionMode.Remove;
                        if (this.CurrentToothTreatment.Treatment.DrawType != (int)TreatmentDrawType.None)
                            ApplyExistTreatmentList();
                    }
                }
                else
                {
                    if (this.CurrentToothTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Surface)
                    {
                        _selectedArea = GetAreaSurfaceCode(_activeIndex + 1);
                        this.CurrentToothTreatment.Surface.Add(_selectedArea);
                        _selectToothTreatment.Surface.Add(_selectedArea);
                        this.ToothTreatmentList.Add(_selectToothTreatment);
                        if (this.CurrentToothTreatment.Treatment.DrawType != (int)TreatmentDrawType.None)
                            //DrawTreatmentSurface((TreatmentDrawType)this.CurrentToothTreatment.Treatment.DrawType, (DrawingBrushType)this.CurrentToothTreatment.Treatment.BruchType, this.CurrentToothTreatment.Surface, _graphic, this.CurrentTooth.Number, this.CurrentTooth.Direction, CurrentColor);
                            ApplySurfaceView(_selectToothTreatment);
                    }
                    else
                    {
                        if (this.CurrentToothTreatment.Treatment.TreatmentArea == (int)TreatmentArea.Root)
                        {
                            RootCanalForm aRootCanalForm = new RootCanalForm();
                            aRootCanalForm.CurrentToothTreatment = this.CurrentToothTreatment;
                            aRootCanalForm.TopMost = true;
                            aRootCanalForm.ShowDialog();
                            if (!aRootCanalForm.AllowContinue)
                                return;
                        }

                        this.ToothTreatmentList.Add(_selectToothTreatment);
                        if (this.CurrentToothTreatment.Treatment.DrawType != (int)TreatmentDrawType.None)
                            //DrawTreatmentSurface((TreatmentDrawType)this.CurrentToothTreatment.Treatment.DrawType, (DrawingBrushType)this.CurrentToothTreatment.Treatment.BruchType, this.CurrentToothTreatment.Surface, _graphic, this.CurrentTooth.Number, this.CurrentTooth.Direction, CurrentColor);
                            ApplySurfaceView(_selectToothTreatment);
                    }
                    TActionMode = ActionMode.Add;
                }
                OnToothDarwingCompleted();
            }
            pictureBox1.Image = _bitmap;
        }

        private void tsmiPrimaryTooth_Click(object sender, EventArgs e)
        {
            if (this.CurrentTooth.Type != ToothType.Primary)
            {
                OnToothTypeChanging(ToothTypeChangeMode.Single2Primary);
            }
        }

        private void tsmiPermanetTooth_Click(object sender, EventArgs e)
        {
            if (this.CurrentTooth.Type == ToothType.Primary)
            {
                OnToothTypeChanging(ToothTypeChangeMode.Single2Permanent);
            }
        }

        private void tsmiChangeAllToPrimary_Click(object sender, EventArgs e)
        {
            OnToothTypeChanging(ToothTypeChangeMode.All2Primary);
        }

        private void tsmiChangeAllToPermanent_Click(object sender, EventArgs e)
        {
            OnToothTypeChanging(ToothTypeChangeMode.All2Permanent);
        }

        public void ChangeToothType(ToothType newToothType)
        {
            this.CurrentTooth.Type = ToothType.Permanent;
            if (newToothType == ToothType.Primary)
                this.CurrentTooth.Type = ToothType.Primary;
            ApplyExistTreatmentList();
        }

        public void SelectTooth()
        {
            this.BackColor = Color.Red;
        }

        public void DeselectTooth()
        {
            this.BackColor = System.Drawing.SystemColors.Control;
        }
    }
}
