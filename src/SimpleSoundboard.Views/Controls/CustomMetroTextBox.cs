using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;

namespace SimpleSoundboard.Views.Controls
{

    //Decompiled MetroTextBox, Edited to make it Compatible with .Net 5
    public class CustomMetroTextBox : Control, IMetroControl
        {
            private MetroColorStyle metroStyle;
            private MetroThemeStyle metroTheme;
            private MetroStyleManager metroStyleManager;
            private bool useCustomBackColor;
            private bool useCustomForeColor;
            private bool useStyleColors;
            private CustomMetroTextBox.PromptedTextBox baseTextBox;
            private MetroTextBoxSize metroTextBoxSize;
            private MetroTextBoxWeight metroTextBoxWeight = MetroTextBoxWeight.Regular;
            private Image textBoxIcon;
            private bool textBoxIconRight;
            private bool displayIcon;
            private CustomMetroTextBox.MetroTextButton _button;
            private bool _showbutton;
            private MetroLink lnkClear;
            private bool _showclear;
            private bool _witherror;
            private bool _cleared;
            private bool _withtext;

            [Category("Metro Appearance")]
            public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;

            protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
            {
                if (!this.GetStyle(ControlStyles.UserPaint) || this.CustomPaintBackground == null)
                    return;
                this.CustomPaintBackground((object)this, e);
            }

            [Category("Metro Appearance")]
            public event EventHandler<MetroPaintEventArgs> CustomPaint;

            protected virtual void OnCustomPaint(MetroPaintEventArgs e)
            {
                if (!this.GetStyle(ControlStyles.UserPaint) || this.CustomPaint == null)
                    return;
                this.CustomPaint((object)this, e);
            }

            [Category("Metro Appearance")]
            public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;

            protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
            {
                if (!this.GetStyle(ControlStyles.UserPaint) || this.CustomPaintForeground == null)
                    return;
                this.CustomPaintForeground((object)this, e);
            }

            [DefaultValue(MetroColorStyle.Default)]
            [Category("Metro Appearance")]
            public MetroColorStyle Style
            {
                get
                {
                    if (this.DesignMode || this.metroStyle != MetroColorStyle.Default)
                        return this.metroStyle;
                    if (this.StyleManager != null && this.metroStyle == MetroColorStyle.Default)
                        return this.StyleManager.Style;
                    return this.StyleManager == null && this.metroStyle == MetroColorStyle.Default ? MetroColorStyle.Blue : this.metroStyle;
                }
                set => this.metroStyle = value;
            }

            [Category("Metro Appearance")]
            [DefaultValue(MetroThemeStyle.Default)]
            public MetroThemeStyle Theme
            {
                get
                {
                    if (this.DesignMode || this.metroTheme != MetroThemeStyle.Default)
                        return this.metroTheme;
                    if (this.StyleManager != null && this.metroTheme == MetroThemeStyle.Default)
                        return this.StyleManager.Theme;
                    return this.StyleManager == null && this.metroTheme == MetroThemeStyle.Default ? MetroThemeStyle.Light : this.metroTheme;
                }
                set => this.metroTheme = value;
            }

            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            [Browsable(false)]
            public MetroStyleManager StyleManager
            {
                get => this.metroStyleManager;
                set => this.metroStyleManager = value;
            }

            [DefaultValue(false)]
            [Category("Metro Appearance")]
            public bool UseCustomBackColor
            {
                get => this.useCustomBackColor;
                set => this.useCustomBackColor = value;
            }

            [Category("Metro Appearance")]
            [DefaultValue(false)]
            public bool UseCustomForeColor
            {
                get => this.useCustomForeColor;
                set => this.useCustomForeColor = value;
            }

            [DefaultValue(false)]
            [Category("Metro Appearance")]
            public bool UseStyleColors
            {
                get => this.useStyleColors;
                set => this.useStyleColors = value;
            }

            [DefaultValue(false)]
            [Browsable(false)]
            [Category("Metro Behaviour")]
            public bool UseSelectable
            {
                get => this.GetStyle(ControlStyles.Selectable);
                set => this.SetStyle(ControlStyles.Selectable, value);
            }

            [Category("Metro Appearance")]
            [DefaultValue(MetroTextBoxSize.Small)]
            public MetroTextBoxSize FontSize
            {
                get => this.metroTextBoxSize;
                set
                {
                    this.metroTextBoxSize = value;
                    this.UpdateBaseTextBox();
                }
            }

            [DefaultValue(MetroTextBoxWeight.Regular)]
            [Category("Metro Appearance")]
            public MetroTextBoxWeight FontWeight
            {
                get => this.metroTextBoxWeight;
                set
                {
                    this.metroTextBoxWeight = value;
                    this.UpdateBaseTextBox();
                }
            }

            [EditorBrowsable(EditorBrowsableState.Always)]
            [Browsable(true)]
            [Obsolete("Use watermark")]
            [DefaultValue("")]
            [Category("Metro Appearance")]
            public string PromptText
            {
                get => this.baseTextBox.WaterMark;
                set => this.baseTextBox.WaterMark = value;
            }

            [Category("Metro Appearance")]
            [Browsable(true)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [DefaultValue("")]
            public string WaterMark
            {
                get => this.baseTextBox.WaterMark;
                set => this.baseTextBox.WaterMark = value;
            }

            [DefaultValue(null)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [Category("Metro Appearance")]
            [Browsable(true)]
            public Image Icon
            {
                get => this.textBoxIcon;
                set
                {
                    this.textBoxIcon = value;
                    this.Refresh();
                }
            }

            [EditorBrowsable(EditorBrowsableState.Always)]
            [DefaultValue(false)]
            [Category("Metro Appearance")]
            [Browsable(true)]
            public bool IconRight
            {
                get => this.textBoxIconRight;
                set
                {
                    this.textBoxIconRight = value;
                    this.Refresh();
                }
            }

            [Browsable(true)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [DefaultValue(false)]
            [Category("Metro Appearance")]
            public bool DisplayIcon
            {
                get => this.displayIcon;
                set
                {
                    this.displayIcon = value;
                    this.Refresh();
                }
            }

            protected Size iconSize
            {
                get
                {
                    if (!this.displayIcon || this.textBoxIcon == null)
                        return new Size(-1, -1);
                    int num1 = this.textBoxIcon.Height > this.ClientRectangle.Height ? this.ClientRectangle.Height : this.textBoxIcon.Height;
                    Size size = this.textBoxIcon.Size;
                    double num2 = (double)num1 / (double)size.Height;
                    Point point = new Point(1, 1);
                    return new Size((int)((double)size.Width * num2), (int)((double)size.Height * num2));
                }
            }

            protected int ButtonWidth
            {
                get
                {
                    int num = 0;
                    if (this._button != null)
                        num = this._showbutton ? this._button.Width : 0;
                    return num;
                }
            }

            [Browsable(true)]
            [Category("Metro Appearance")]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [DefaultValue(false)]
            public bool ShowButton
            {
                get => this._showbutton;
                set
                {
                    this._showbutton = value;
                    this.Refresh();
                }
            }

            [EditorBrowsable(EditorBrowsableState.Always)]
            [Browsable(true)]
            [DefaultValue(false)]
            [Category("Metro Appearance")]
            public bool ShowClearButton
            {
                get => this._showclear;
                set
                {
                    this._showclear = value;
                    this.Refresh();
                }
            }

            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            [DefaultValue(false)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [Category("Metro Appearance")]
            public CustomMetroTextBox.MetroTextButton CustomButton
            {
                get => this._button;
                set
                {
                    this._button = value;
                    this.Refresh();
                }
            }

            [DefaultValue(false)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool WithError
            {
                get => this._witherror;
                set
                {
                    this._witherror = value;
                    this.Invalidate();
                }
            }

            public override ContextMenuStrip ContextMenuStrip
            {
                get => this.baseTextBox.ContextMenuStrip;
                set
                {
                    this.ContextMenuStrip = value;
                    this.baseTextBox.ContextMenuStrip = value;
                }
            }

            [DefaultValue(false)]
            public bool Multiline
            {
                get => this.baseTextBox.Multiline;
                set => this.baseTextBox.Multiline = value;
            }

            public override string Text
            {
                get => this.baseTextBox.Text;
                set => this.baseTextBox.Text = value;
            }

            [Category("Metro Appearance")]
            public Color WaterMarkColor
            {
                get => this.baseTextBox.WaterMarkColor;
                set => this.baseTextBox.WaterMarkColor = value;
            }

            [Category("Metro Appearance")]
            public Font WaterMarkFont
            {
                get => this.baseTextBox.WaterMarkFont;
                set => this.baseTextBox.WaterMarkFont = value;
            }

            public string[] Lines
            {
                get => this.baseTextBox.Lines;
                set => this.baseTextBox.Lines = value;
            }

            [Browsable(false)]
            public string SelectedText
            {
                get => this.baseTextBox.SelectedText;
                set => this.baseTextBox.Text = value;
            }

            [DefaultValue(false)]
            public bool ReadOnly
            {
                get => this.baseTextBox.ReadOnly;
                set => this.baseTextBox.ReadOnly = value;
            }

            public char PasswordChar
            {
                get => this.baseTextBox.PasswordChar;
                set => this.baseTextBox.PasswordChar = value;
            }

            [DefaultValue(false)]
            public bool UseSystemPasswordChar
            {
                get => this.baseTextBox.UseSystemPasswordChar;
                set => this.baseTextBox.UseSystemPasswordChar = value;
            }

            [DefaultValue(HorizontalAlignment.Left)]
            public HorizontalAlignment TextAlign
            {
                get => this.baseTextBox.TextAlign;
                set => this.baseTextBox.TextAlign = value;
            }

            public int SelectionStart
            {
                get => this.baseTextBox.SelectionStart;
                set => this.baseTextBox.SelectionStart = value;
            }

            public int SelectionLength
            {
                get => this.baseTextBox.SelectionLength;
                set => this.baseTextBox.SelectionLength = value;
            }

            [DefaultValue(true)]
            public new bool TabStop
            {
                get => this.baseTextBox.TabStop;
                set => this.baseTextBox.TabStop = value;
            }

            public int MaxLength
            {
                get => this.baseTextBox.MaxLength;
                set => this.baseTextBox.MaxLength = value;
            }

            public ScrollBars ScrollBars
            {
                get => this.baseTextBox.ScrollBars;
                set => this.baseTextBox.ScrollBars = value;
            }

            [DefaultValue(AutoCompleteMode.None)]
            public AutoCompleteMode AutoCompleteMode
            {
                get => this.baseTextBox.AutoCompleteMode;
                set => this.baseTextBox.AutoCompleteMode = value;
            }

            [DefaultValue(AutoCompleteSource.None)]
            public AutoCompleteSource AutoCompleteSource
            {
                get => this.baseTextBox.AutoCompleteSource;
                set => this.baseTextBox.AutoCompleteSource = value;
            }

            public AutoCompleteStringCollection AutoCompleteCustomSource
            {
                get => this.baseTextBox.AutoCompleteCustomSource;
                set => this.baseTextBox.AutoCompleteCustomSource = value;
            }

            public bool ShortcutsEnabled
            {
                get => this.baseTextBox.ShortcutsEnabled;
                set => this.baseTextBox.ShortcutsEnabled = value;
            }

            public CustomMetroTextBox()
            {
                this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
                this.GotFocus += new EventHandler(this.MetroTextBox_GotFocus);
                base.TabStop = false;
                this.CreateBaseTextBox();
                this.UpdateBaseTextBox();
                this.AddEventHandler();
            }

            public event EventHandler AcceptsTabChanged;

            private void BaseTextBoxAcceptsTabChanged(object sender, EventArgs e)
            {
                if (this.AcceptsTabChanged == null)
                    return;
                this.AcceptsTabChanged((object)this, e);
            }

            private void BaseTextBoxSizeChanged(object sender, EventArgs e) => this.OnSizeChanged(e);

            private void BaseTextBoxCursorChanged(object sender, EventArgs e) => this.OnCursorChanged(e);

            private void BaseTextBoxContextMenuStripChanged(object sender, EventArgs e) => this.OnContextMenuStripChanged(e);

            private void BaseTextBoxClientSizeChanged(object sender, EventArgs e) => this.OnClientSizeChanged(e);

            private void BaseTextBoxClick(object sender, EventArgs e) => this.OnClick(e);

            private void BaseTextBoxChangeUiCues(object sender, UICuesEventArgs e) => this.OnChangeUICues(e);

            private void BaseTextBoxCausesValidationChanged(object sender, EventArgs e) => this.OnCausesValidationChanged(e);

            private void BaseTextBoxKeyUp(object sender, KeyEventArgs e) => this.OnKeyUp(e);

            private void BaseTextBoxKeyPress(object sender, KeyPressEventArgs e) => this.OnKeyPress(e);

            private void BaseTextBoxKeyDown(object sender, KeyEventArgs e) => this.OnKeyDown(e);

            private void BaseTextBoxTextChanged(object sender, EventArgs e)
            {
                this.OnTextChanged(e);
                if (this.baseTextBox.Text != "" && !this._withtext)
                {
                    this._withtext = true;
                    this._cleared = false;
                    this.Invalidate();
                }
                if (!(this.baseTextBox.Text == "") || this._cleared)
                    return;
                this._withtext = false;
                this._cleared = true;
                this.Invalidate();
            }

            public void Select(int start, int length) => this.baseTextBox.Select(start, length);

            public void SelectAll() => this.baseTextBox.SelectAll();

            public void Clear() => this.baseTextBox.Clear();

            private void MetroTextBox_GotFocus(object sender, EventArgs e) => this.baseTextBox.Focus();

            public void AppendText(string text) => this.baseTextBox.AppendText(text);

            protected override void OnPaintBackground(PaintEventArgs e)
            {
                try
                {
                    Color color = this.BackColor;
                    this.baseTextBox.BackColor = color;
                    if (!this.useCustomBackColor)
                    {
                        color = MetroPaint.BackColor.Form(this.Theme);
                        this.baseTextBox.BackColor = color;
                    }
                    if (color.A == byte.MaxValue)
                    {
                        e.Graphics.Clear(color);
                    }
                    else
                    {
                        base.OnPaintBackground(e);
                        this.OnCustomPaintBackground(new MetroPaintEventArgs(color, Color.Empty, e.Graphics));
                    }
                }
                catch
                {
                    this.Invalidate();
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                try
                {
                    if (this.GetStyle(ControlStyles.AllPaintingInWmPaint))
                        this.OnPaintBackground(e);
                    this.OnCustomPaint(new MetroPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
                    this.OnPaintForeground(e);
                }
                catch
                {
                    this.Invalidate();
                }
            }

            protected virtual void OnPaintForeground(PaintEventArgs e)
            {
                if (this.useCustomForeColor)
                    this.baseTextBox.ForeColor = this.ForeColor;
                else
                    this.baseTextBox.ForeColor = MetroPaint.ForeColor.Button.Normal(this.Theme);
                Color color = MetroPaint.BorderColor.ComboBox.Normal(this.Theme);
                if (this.useStyleColors)
                    color = MetroPaint.GetStyleColor(this.Style);
                if (this._witherror)
                {
                    color = MetroColors.Red;
                    if (this.Style == MetroColorStyle.Red)
                        color = MetroColors.Orange;
                }
                using (Pen pen = new Pen(color))
                    e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 2, this.Height - 1));
                this.DrawIcon(e.Graphics);
            }

            private void DrawIcon(Graphics g)
            {
                if (this.displayIcon && this.textBoxIcon != null)
                {
                    Point location = new Point(5, 5);
                    if (this.textBoxIconRight)
                        location = new Point(this.ClientRectangle.Width - this.iconSize.Width - 1, 1);
                    g.DrawImage(this.textBoxIcon, new Rectangle(location, this.iconSize));
                    this.UpdateBaseTextBox();
                }
                else
                {
                    this._button.Visible = this._showbutton;
                    if (this._showbutton && this._button != null)
                        this.UpdateBaseTextBox();
                }
                this.OnCustomPaintForeground(new MetroPaintEventArgs(Color.Empty, this.baseTextBox.ForeColor, g));
            }

            public override void Refresh()
            {
                base.Refresh();
                this.UpdateBaseTextBox();
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                this.UpdateBaseTextBox();
            }

            [DefaultValue(CharacterCasing.Normal)]
            public CharacterCasing CharacterCasing
            {
                get => this.baseTextBox.CharacterCasing;
                set => this.baseTextBox.CharacterCasing = value;
            }

            private void CreateBaseTextBox()
            {
                if (this.baseTextBox != null)
                    return;
                this.baseTextBox = new CustomMetroTextBox.PromptedTextBox();
                this.baseTextBox.BorderStyle = BorderStyle.None;
                this.baseTextBox.Font = MetroFonts.TextBox(this.metroTextBoxSize, this.metroTextBoxWeight);
                this.baseTextBox.Location = new Point(3, 3);
                this.baseTextBox.Size = new Size(this.Width - 6, this.Height - 6);
                this.Size = new Size(this.baseTextBox.Width + 6, this.baseTextBox.Height + 6);
                this.baseTextBox.TabStop = true;
                this.Controls.Add((Control)this.baseTextBox);
                if (this._button != null)
                    return;
                this._button = new CustomMetroTextBox.MetroTextButton();
                this._button.Theme = this.Theme;
                this._button.Style = this.Style;
                this._button.Location = new Point(3, 1);
                this._button.Size = new Size(this.Height - 4, this.Height - 4);
                this._button.TextChanged += new EventHandler(this._button_TextChanged);
                this._button.MouseEnter += new EventHandler(this._button_MouseEnter);
                this._button.MouseLeave += new EventHandler(this._button_MouseLeave);
                this._button.Click += new EventHandler(this._button_Click);
                if (!this.Controls.Contains((Control)this._button))
                    this.Controls.Add((Control)this._button);
                if (this.lnkClear != null)
                    return;
                this.InitializeComponent();
            }

            public event CustomMetroTextBox.ButClick ButtonClick;

            protected override void OnCreateControl() => base.OnCreateControl();

            private void _button_Click(object sender, EventArgs e)
            {
                if (this.ButtonClick == null)
                    return;
                this.ButtonClick((object)this, e);
            }

            private void _button_MouseLeave(object sender, EventArgs e)
            {
                this.UseStyleColors = this.baseTextBox.Focused;
                this.Invalidate();
            }

            private void _button_MouseEnter(object sender, EventArgs e)
            {
                this.UseStyleColors = true;
                this.Invalidate();
            }

            private void _button_TextChanged(object sender, EventArgs e) => this._button.Invalidate();

            private void AddEventHandler()
            {
                this.baseTextBox.AcceptsTabChanged += new EventHandler(this.BaseTextBoxAcceptsTabChanged);
                this.baseTextBox.CausesValidationChanged += new EventHandler(this.BaseTextBoxCausesValidationChanged);
                this.baseTextBox.ChangeUICues += new UICuesEventHandler(this.BaseTextBoxChangeUiCues);
                this.baseTextBox.Click += new EventHandler(this.BaseTextBoxClick);
                this.baseTextBox.ClientSizeChanged += new EventHandler(this.BaseTextBoxClientSizeChanged);
                this.baseTextBox.ContextMenuStripChanged += new EventHandler(this.BaseTextBoxContextMenuStripChanged);
                this.baseTextBox.CursorChanged += new EventHandler(this.BaseTextBoxCursorChanged);
                this.baseTextBox.KeyDown += new KeyEventHandler(this.BaseTextBoxKeyDown);
                this.baseTextBox.KeyPress += new KeyPressEventHandler(this.BaseTextBoxKeyPress);
                this.baseTextBox.KeyUp += new KeyEventHandler(this.BaseTextBoxKeyUp);
                this.baseTextBox.SizeChanged += new EventHandler(this.BaseTextBoxSizeChanged);
                this.baseTextBox.TextChanged += new EventHandler(this.BaseTextBoxTextChanged);
                this.baseTextBox.GotFocus += new EventHandler(this.baseTextBox_GotFocus);
                this.baseTextBox.LostFocus += new EventHandler(this.baseTextBox_LostFocus);
            }

            private void baseTextBox_LostFocus(object sender, EventArgs e)
            {
                this.UseStyleColors = false;
                this.Invalidate();
                this.InvokeLostFocus((Control)this, e);
            }

            private void baseTextBox_GotFocus(object sender, EventArgs e)
            {
                this._witherror = false;
                this.UseStyleColors = true;
                this.Invalidate();
                this.InvokeGotFocus((Control)this, e);
            }

            private void UpdateBaseTextBox()
            {
                if (this._button != null)
                {
                    if (this.Height % 2 > 0)
                    {
                        this._button.Size = new Size(this.Height - 2, this.Height - 2);
                        this._button.Location = new Point(this.Width - (this._button.Width + 1), 1);
                    }
                    else
                    {
                        this._button.Size = new Size(this.Height - 5, this.Height - 5);
                        this._button.Location = new Point(this.Width - this._button.Width - 3, 2);
                    }
                    this._button.Visible = this._showbutton;
                }
                int num = 0;
                if (this.lnkClear != null)
                {
                    this.lnkClear.Visible = false;
                    if (this._showclear && this.Text != "" && (!this.ReadOnly && this.Enabled))
                    {
                        num = 16;
                        this.lnkClear.Location = new Point(this.Width - (this.ButtonWidth + 17), (this.Height - 14) / 2);
                        this.lnkClear.Visible = true;
                    }
                }
                if (this.baseTextBox == null)
                    return;
                this.baseTextBox.Font = MetroFonts.TextBox(this.metroTextBoxSize, this.metroTextBoxWeight);
                if (this.displayIcon)
                {
                    Point point = new Point(this.iconSize.Width + 10, 5);
                    if (this.textBoxIconRight)
                        point = new Point(3, 3);
                    this.baseTextBox.Location = point;
                    this.baseTextBox.Size = new Size(this.Width - (20 + this.ButtonWidth + num) - this.iconSize.Width, this.Height - 6);
                }
                else
                {
                    this.baseTextBox.Location = new Point(3, 3);
                    this.baseTextBox.Size = new Size(this.Width - (6 + this.ButtonWidth + num), this.Height - 6);
                }
            }

            private void InitializeComponent()
            {
                ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MetroTextBox));
                this.lnkClear = new MetroLink();
                this.SuspendLayout();
                this.lnkClear.FontSize = MetroLinkSize.Medium;
                this.lnkClear.FontWeight = MetroLinkWeight.Regular;
                //this.lnkClear.Image = (Image)componentResourceManager.GetObject("lnkClear.Image");
                this.lnkClear.ImageSize = 10;
                this.lnkClear.Location = new Point(654, 96);
                this.lnkClear.Name = "lnkClear";
                //this.lnkClear.NoFocusImage = (Image)componentResourceManager.GetObject("lnkClear.NoFocusImage");
                this.lnkClear.Size = new Size(12, 12);
                this.lnkClear.TabIndex = 2;
                this.lnkClear.UseSelectable = true;
                this.lnkClear.Click += new EventHandler(this.lnkClear_Click);
                this.ResumeLayout(false);
                this.Controls.Add((Control)this.lnkClear);
            }

            public event CustomMetroTextBox.LUClear ClearClicked;

            private void lnkClear_Click(object sender, EventArgs e)
            {
                this.Focus();
                this.Clear();
                this.baseTextBox.Focus();
                if (this.ClearClicked == null)
                    return;
                this.ClearClicked();
            }

            public delegate void ButClick(object sender, EventArgs e);

            private class PromptedTextBox : TextBox
            {
                private const int OCM_COMMAND = 8465;
                private const int WM_PAINT = 15;
                private bool drawPrompt;
                private string promptText = "";
                private Color _waterMarkColor = MetroPaint.ForeColor.Button.Disabled(MetroThemeStyle.Dark);
                private Font _waterMarkFont = MetroFonts.WaterMark(MetroLabelSize.Small, MetroWaterMarkWeight.Italic);

                [DefaultValue("")]
                [Browsable(true)]
                [EditorBrowsable(EditorBrowsableState.Always)]
                public string WaterMark
                {
                    get => this.promptText;
                    set
                    {
                        this.promptText = value.Trim();
                        this.Invalidate();
                    }
                }

                public Color WaterMarkColor
                {
                    get => this._waterMarkColor;
                    set
                    {
                        this._waterMarkColor = value;
                        this.Invalidate();
                    }
                }

                public Font WaterMarkFont
                {
                    get => this._waterMarkFont;
                    set => this._waterMarkFont = value;
                }

                public PromptedTextBox()
                {
                    this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
                    this.drawPrompt = this.Text.Trim().Length == 0;
                }

                private void DrawTextPrompt()
                {
                    using (Graphics graphics = this.CreateGraphics())
                        this.DrawTextPrompt(graphics);
                }

                private void DrawTextPrompt(Graphics g)
                {
                    TextFormatFlags flags = TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding;
                    Rectangle clientRectangle = this.ClientRectangle;
                    switch (this.TextAlign)
                    {
                        case HorizontalAlignment.Left:
                            clientRectangle.Offset(1, 0);
                            break;
                        case HorizontalAlignment.Right:
                            flags |= TextFormatFlags.Right;
                            clientRectangle.Offset(-2, 0);
                            break;
                        case HorizontalAlignment.Center:
                            flags |= TextFormatFlags.HorizontalCenter;
                            clientRectangle.Offset(1, 0);
                            break;
                    }
                    SolidBrush solidBrush = new SolidBrush(this.WaterMarkColor);
                    TextRenderer.DrawText((IDeviceContext)g, this.promptText, this._waterMarkFont, clientRectangle, this._waterMarkColor, this.BackColor, flags);
                }

                protected override void OnPaint(PaintEventArgs e)
                {
                    base.OnPaint(e);
                    if (!this.drawPrompt)
                        return;
                    this.DrawTextPrompt(e.Graphics);
                }

                protected override void OnCreateControl() => base.OnCreateControl();

                protected override void OnTextAlignChanged(EventArgs e)
                {
                    base.OnTextAlignChanged(e);
                    this.Invalidate();
                }

                protected override void OnTextChanged(EventArgs e)
                {
                    base.OnTextChanged(e);
                    this.drawPrompt = this.Text.Trim().Length == 0;
                    this.Invalidate();
                }

                protected override void WndProc(ref Message m)
                {
                    base.WndProc(ref m);
                    if (m.Msg != 15 && m.Msg != 8465 || (!this.drawPrompt || this.GetStyle(ControlStyles.UserPaint)))
                        return;
                    this.DrawTextPrompt();
                }

                protected override void OnLostFocus(EventArgs e) => base.OnLostFocus(e);
            }

            public delegate void LUClear();

            [ToolboxItem(false)]
            public class MetroTextButton : System.Windows.Forms.Button, IMetroControl
            {
                private MetroColorStyle metroStyle;
                private MetroThemeStyle metroTheme;
                private MetroStyleManager metroStyleManager;
                private bool useCustomBackColor;
                private bool useCustomForeColor;
                private bool useStyleColors;
                private bool isHovered;
                private bool isPressed;
                private Bitmap _image;

                [Category("Metro Appearance")]
                public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;

                protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
                {
                    if (!this.GetStyle(ControlStyles.UserPaint) || this.CustomPaintBackground == null)
                        return;
                    this.CustomPaintBackground((object)this, e);
                }

                [Category("Metro Appearance")]
                public event EventHandler<MetroPaintEventArgs> CustomPaint;

                protected virtual void OnCustomPaint(MetroPaintEventArgs e)
                {
                    if (!this.GetStyle(ControlStyles.UserPaint) || this.CustomPaint == null)
                        return;
                    this.CustomPaint((object)this, e);
                }

                [Category("Metro Appearance")]
                public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;

                protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
                {
                    if (!this.GetStyle(ControlStyles.UserPaint) || this.CustomPaintForeground == null)
                        return;
                    this.CustomPaintForeground((object)this, e);
                }

                [Category("Metro Appearance")]
                [DefaultValue(MetroColorStyle.Default)]
                public MetroColorStyle Style
                {
                    get
                    {
                        if (this.DesignMode || this.metroStyle != MetroColorStyle.Default)
                            return this.metroStyle;
                        if (this.StyleManager != null && this.metroStyle == MetroColorStyle.Default)
                            return this.StyleManager.Style;
                        return this.StyleManager == null && this.metroStyle == MetroColorStyle.Default ? MetroColorStyle.Blue : this.metroStyle;
                    }
                    set => this.metroStyle = value;
                }

                [Category("Metro Appearance")]
                [DefaultValue(MetroThemeStyle.Default)]
                public MetroThemeStyle Theme
                {
                    get
                    {
                        if (this.DesignMode || this.metroTheme != MetroThemeStyle.Default)
                            return this.metroTheme;
                        if (this.StyleManager != null && this.metroTheme == MetroThemeStyle.Default)
                            return this.StyleManager.Theme;
                        return this.StyleManager == null && this.metroTheme == MetroThemeStyle.Default ? MetroThemeStyle.Light : this.metroTheme;
                    }
                    set => this.metroTheme = value;
                }

                [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                [Browsable(false)]
                public MetroStyleManager StyleManager
                {
                    get => this.metroStyleManager;
                    set => this.metroStyleManager = value;
                }

                [DefaultValue(false)]
                [Category("Metro Appearance")]
                public bool UseCustomBackColor
                {
                    get => this.useCustomBackColor;
                    set => this.useCustomBackColor = value;
                }

                [DefaultValue(false)]
                [Category("Metro Appearance")]
                public bool UseCustomForeColor
                {
                    get => this.useCustomForeColor;
                    set => this.useCustomForeColor = value;
                }

                [DefaultValue(false)]
                [Category("Metro Appearance")]
                public bool UseStyleColors
                {
                    get => this.useStyleColors;
                    set => this.useStyleColors = value;
                }

                [Browsable(false)]
                [DefaultValue(false)]
                [Category("Metro Behaviour")]
                public bool UseSelectable
                {
                    get => this.GetStyle(ControlStyles.Selectable);
                    set => this.SetStyle(ControlStyles.Selectable, value);
                }

                protected override void OnCreateControl()
                {
                    base.OnCreateControl();
                    this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
                }

                protected override void OnPaint(PaintEventArgs e)
                {
                    MetroThemeStyle theme = this.Theme;
                    MetroColorStyle style = this.Style;
                    Color foreColor;
                    Color color;
                    if (this.Parent != null)
                    {
                        if (this.Parent is IMetroForm)
                        {
                            theme = ((IMetroForm)this.Parent).Theme;
                            style = ((IMetroForm)this.Parent).Style;
                            foreColor = MetroPaint.ForeColor.Button.Press(theme);
                            color = MetroPaint.GetStyleColor(style);
                        }
                        else if (this.Parent is IMetroControl)
                        {
                            theme = ((IMetroControl)this.Parent).Theme;
                            style = ((IMetroControl)this.Parent).Style;
                            foreColor = MetroPaint.ForeColor.Button.Press(theme);
                            color = MetroPaint.GetStyleColor(style);
                        }
                        else
                        {
                            foreColor = MetroPaint.ForeColor.Button.Press(theme);
                            color = MetroPaint.GetStyleColor(style);
                        }
                    }
                    else
                    {
                        foreColor = MetroPaint.ForeColor.Button.Press(theme);
                        color = MetroPaint.BackColor.Form(theme);
                    }
                    if (this.isHovered && !this.isPressed && this.Enabled)
                    {
                        int r = (int)color.R;
                        int g = (int)color.G;
                        int b = (int)color.B;
                        color = ControlPaint.Light(color, 0.25f);
                    }
                    else if (this.isHovered && this.isPressed && this.Enabled)
                    {
                        foreColor = MetroPaint.ForeColor.Button.Press(theme);
                        color = MetroPaint.GetStyleColor(style);
                    }
                    else if (!this.Enabled)
                    {
                        foreColor = MetroPaint.ForeColor.Button.Disabled(theme);
                        color = MetroPaint.BackColor.Button.Disabled(theme);
                    }
                    else
                        foreColor = MetroPaint.ForeColor.Button.Press(theme);
                    e.Graphics.Clear(color);
                    Font font = MetroFonts.Button(MetroButtonSize.Small, MetroButtonWeight.Bold);
                    TextRenderer.DrawText((IDeviceContext)e.Graphics, this.Text, font, this.ClientRectangle, foreColor, color, TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    this.DrawIcon(e.Graphics);
                }

                public new Image Image
                {
                    get => base.Image;
                    set
                    {
                        base.Image = value;
                        if (value == null)
                            return;
                        this._image = this.ApplyInvert(new Bitmap(value));
                    }
                }

                public Bitmap ApplyInvert(Bitmap bitmapImage)
                {
                    for (int y = 0; y < bitmapImage.Height; ++y)
                    {
                        for (int x = 0; x < bitmapImage.Width; ++x)
                        {
                            Color pixel = bitmapImage.GetPixel(x, y);
                            byte a = pixel.A;
                            byte num1 = (byte)((uint)byte.MaxValue - (uint)pixel.R);
                            byte num2 = (byte)((uint)byte.MaxValue - (uint)pixel.G);
                            byte num3 = (byte)((uint)byte.MaxValue - (uint)pixel.B);
                            bitmapImage.SetPixel(x, y, Color.FromArgb((int)a, (int)num1, (int)num2, (int)num3));
                        }
                    }
                    return bitmapImage;
                }

                protected Size iconSize
                {
                    get
                    {
                        if (this.Image == null)
                            return new Size(-1, -1);
                        Size size = this.Image.Size;
                        double num = 14.0 / (double)size.Height;
                        Point point = new Point(1, 1);
                        return new Size((int)((double)size.Width * num), (int)((double)size.Height * num));
                    }
                }

                private void DrawIcon(Graphics g)
                {
                    if (this.Image == null)
                        return;
                    Point location = new Point(2, (this.ClientRectangle.Height - this.iconSize.Height) / 2);
                    int num = 5;
                    switch (this.ImageAlign)
                    {
                        case ContentAlignment.TopLeft:
                            location = new Point(num, num);
                            break;
                        case ContentAlignment.TopCenter:
                            location = new Point((this.ClientRectangle.Width - this.iconSize.Width) / 2, num);
                            break;
                        case ContentAlignment.TopRight:
                            location = new Point(this.ClientRectangle.Width - this.iconSize.Width - num, num);
                            break;
                        case ContentAlignment.MiddleLeft:
                            location = new Point(num, (this.ClientRectangle.Height - this.iconSize.Height) / 2);
                            break;
                        case ContentAlignment.MiddleCenter:
                            location = new Point((this.ClientRectangle.Width - this.iconSize.Width) / 2, (this.ClientRectangle.Height - this.iconSize.Height) / 2);
                            break;
                        case ContentAlignment.MiddleRight:
                            location = new Point(this.ClientRectangle.Width - this.iconSize.Width - num, (this.ClientRectangle.Height - this.iconSize.Height) / 2);
                            break;
                        case ContentAlignment.BottomLeft:
                            location = new Point(num, this.ClientRectangle.Height - this.iconSize.Height - num);
                            break;
                        case ContentAlignment.BottomCenter:
                            location = new Point((this.ClientRectangle.Width - this.iconSize.Width) / 2, this.ClientRectangle.Height - this.iconSize.Height - num);
                            break;
                        case ContentAlignment.BottomRight:
                            location = new Point(this.ClientRectangle.Width - this.iconSize.Width - num, this.ClientRectangle.Height - this.iconSize.Height - num);
                            break;
                    }
                    g.DrawImage(this.Theme == MetroThemeStyle.Dark ? (this.isPressed ? (Image)this._image : this.Image) : (this.isPressed ? this.Image : (Image)this._image), new Rectangle(location, this.iconSize));
                }

                protected override void OnMouseEnter(EventArgs e)
                {
                    this.isHovered = true;
                    this.Invalidate();
                    base.OnMouseEnter(e);
                }

                protected override void OnMouseDown(MouseEventArgs e)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        this.isPressed = true;
                        this.Invalidate();
                    }
                    base.OnMouseDown(e);
                }

                protected override void OnMouseUp(MouseEventArgs e)
                {
                    this.isPressed = false;
                    this.Invalidate();
                    base.OnMouseUp(e);
                }

                protected override void OnMouseLeave(EventArgs e)
                {
                    this.isHovered = false;
                    this.Invalidate();
                    base.OnMouseLeave(e);
                }
            }
        }
    }


