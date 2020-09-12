using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;

namespace SimpleSoundboard.Views.Controls
{
	//Decompiled MetroTextBox, Edited to make it Compatible with .Net 5
	public class CustomMetroTextBox : Control, IMetroControl
	{
		public delegate void ButClick(object sender, EventArgs e);

		public delegate void LUClear();

		private MetroTextButton _button;
		private bool _cleared;
		private bool _showbutton;
		private bool _showclear;
		private bool _witherror;
		private bool _withtext;
		private PromptedTextBox baseTextBox;
		private bool displayIcon;
		private MetroLink lnkClear;
		private MetroColorStyle metroStyle;
		private MetroTextBoxSize metroTextBoxSize;
		private MetroTextBoxWeight metroTextBoxWeight = MetroTextBoxWeight.Regular;
		private MetroThemeStyle metroTheme;
		private Image textBoxIcon;
		private bool textBoxIconRight;

		public CustomMetroTextBox()
		{
			SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			GotFocus += MetroTextBox_GotFocus;
			base.TabStop = false;
			CreateBaseTextBox();
			UpdateBaseTextBox();
			AddEventHandler();
		}

		[Category("Metro Appearance")]
		[DefaultValue(MetroTextBoxSize.Small)]
		public MetroTextBoxSize FontSize
		{
			get => metroTextBoxSize;
			set
			{
				metroTextBoxSize = value;
				UpdateBaseTextBox();
			}
		}

		[DefaultValue(MetroTextBoxWeight.Regular)]
		[Category("Metro Appearance")]
		public MetroTextBoxWeight FontWeight
		{
			get => metroTextBoxWeight;
			set
			{
				metroTextBoxWeight = value;
				UpdateBaseTextBox();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[Obsolete("Use watermark")]
		[DefaultValue("")]
		[Category("Metro Appearance")]
		public string PromptText
		{
			get => baseTextBox.WaterMark;
			set => baseTextBox.WaterMark = value;
		}

		[Category("Metro Appearance")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue("")]
		public string WaterMark
		{
			get => baseTextBox.WaterMark;
			set => baseTextBox.WaterMark = value;
		}

		[DefaultValue(null)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("Metro Appearance")]
		[Browsable(true)]
		public Image Icon
		{
			get => textBoxIcon;
			set
			{
				textBoxIcon = value;
				Refresh();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(false)]
		[Category("Metro Appearance")]
		[Browsable(true)]
		public bool IconRight
		{
			get => textBoxIconRight;
			set
			{
				textBoxIconRight = value;
				Refresh();
			}
		}

		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(false)]
		[Category("Metro Appearance")]
		public bool DisplayIcon
		{
			get => displayIcon;
			set
			{
				displayIcon = value;
				Refresh();
			}
		}

		protected Size iconSize
		{
			get
			{
				if (!displayIcon || textBoxIcon == null)
					return new Size(-1, -1);
				var num1 = textBoxIcon.Height > ClientRectangle.Height ? ClientRectangle.Height : textBoxIcon.Height;
				var size = textBoxIcon.Size;
				var num2 = num1 / (double) size.Height;
				var point = new Point(1, 1);
				return new Size((int) (size.Width * num2), (int) (size.Height * num2));
			}
		}

		protected int ButtonWidth
		{
			get
			{
				var num = 0;
				if (_button != null)
					num = _showbutton ? _button.Width : 0;
				return num;
			}
		}

		[Browsable(true)]
		[Category("Metro Appearance")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(false)]
		public bool ShowButton
		{
			get => _showbutton;
			set
			{
				_showbutton = value;
				Refresh();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DefaultValue(false)]
		[Category("Metro Appearance")]
		public bool ShowClearButton
		{
			get => _showclear;
			set
			{
				_showclear = value;
				Refresh();
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[DefaultValue(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("Metro Appearance")]
		public MetroTextButton CustomButton
		{
			get => _button;
			set
			{
				_button = value;
				Refresh();
			}
		}

		[DefaultValue(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool WithError
		{
			get => _witherror;
			set
			{
				_witherror = value;
				Invalidate();
			}
		}

		public override ContextMenuStrip ContextMenuStrip
		{
			get => baseTextBox.ContextMenuStrip;
			set
			{
				ContextMenuStrip = value;
				baseTextBox.ContextMenuStrip = value;
			}
		}

		[DefaultValue(false)]
		public bool Multiline
		{
			get => baseTextBox.Multiline;
			set => baseTextBox.Multiline = value;
		}

		public override string Text
		{
			get => baseTextBox.Text;
			set => baseTextBox.Text = value;
		}

		[Category("Metro Appearance")]
		public Color WaterMarkColor
		{
			get => baseTextBox.WaterMarkColor;
			set => baseTextBox.WaterMarkColor = value;
		}

		[Category("Metro Appearance")]
		public Font WaterMarkFont
		{
			get => baseTextBox.WaterMarkFont;
			set => baseTextBox.WaterMarkFont = value;
		}

		public string[] Lines
		{
			get => baseTextBox.Lines;
			set => baseTextBox.Lines = value;
		}

		[Browsable(false)]
		public string SelectedText
		{
			get => baseTextBox.SelectedText;
			set => baseTextBox.Text = value;
		}

		[DefaultValue(false)]
		public bool ReadOnly
		{
			get => baseTextBox.ReadOnly;
			set => baseTextBox.ReadOnly = value;
		}

		public char PasswordChar
		{
			get => baseTextBox.PasswordChar;
			set => baseTextBox.PasswordChar = value;
		}

		[DefaultValue(false)]
		public bool UseSystemPasswordChar
		{
			get => baseTextBox.UseSystemPasswordChar;
			set => baseTextBox.UseSystemPasswordChar = value;
		}

		[DefaultValue(HorizontalAlignment.Left)]
		public HorizontalAlignment TextAlign
		{
			get => baseTextBox.TextAlign;
			set => baseTextBox.TextAlign = value;
		}

		public int SelectionStart
		{
			get => baseTextBox.SelectionStart;
			set => baseTextBox.SelectionStart = value;
		}

		public int SelectionLength
		{
			get => baseTextBox.SelectionLength;
			set => baseTextBox.SelectionLength = value;
		}

		[DefaultValue(true)]
		public new bool TabStop
		{
			get => baseTextBox.TabStop;
			set => baseTextBox.TabStop = value;
		}

		public int MaxLength
		{
			get => baseTextBox.MaxLength;
			set => baseTextBox.MaxLength = value;
		}

		public ScrollBars ScrollBars
		{
			get => baseTextBox.ScrollBars;
			set => baseTextBox.ScrollBars = value;
		}

		[DefaultValue(AutoCompleteMode.None)]
		public AutoCompleteMode AutoCompleteMode
		{
			get => baseTextBox.AutoCompleteMode;
			set => baseTextBox.AutoCompleteMode = value;
		}

		[DefaultValue(AutoCompleteSource.None)]
		public AutoCompleteSource AutoCompleteSource
		{
			get => baseTextBox.AutoCompleteSource;
			set => baseTextBox.AutoCompleteSource = value;
		}

		public AutoCompleteStringCollection AutoCompleteCustomSource
		{
			get => baseTextBox.AutoCompleteCustomSource;
			set => baseTextBox.AutoCompleteCustomSource = value;
		}

		public bool ShortcutsEnabled
		{
			get => baseTextBox.ShortcutsEnabled;
			set => baseTextBox.ShortcutsEnabled = value;
		}

		[DefaultValue(CharacterCasing.Normal)]
		public CharacterCasing CharacterCasing
		{
			get => baseTextBox.CharacterCasing;
			set => baseTextBox.CharacterCasing = value;
		}

		[Category("Metro Appearance")] public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;

		[Category("Metro Appearance")] public event EventHandler<MetroPaintEventArgs> CustomPaint;

		[Category("Metro Appearance")] public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;

		[DefaultValue(MetroColorStyle.Default)]
		[Category("Metro Appearance")]
		public MetroColorStyle Style
		{
			get
			{
				if (DesignMode || metroStyle != MetroColorStyle.Default)
					return metroStyle;
				if (StyleManager != null && metroStyle == MetroColorStyle.Default)
					return StyleManager.Style;
				return StyleManager == null && metroStyle == MetroColorStyle.Default
					? MetroColorStyle.Blue
					: metroStyle;
			}
			set => metroStyle = value;
		}

		[Category("Metro Appearance")]
		[DefaultValue(MetroThemeStyle.Default)]
		public MetroThemeStyle Theme
		{
			get
			{
				if (DesignMode || metroTheme != MetroThemeStyle.Default)
					return metroTheme;
				if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
					return StyleManager.Theme;
				return StyleManager == null && metroTheme == MetroThemeStyle.Default
					? MetroThemeStyle.Light
					: metroTheme;
			}
			set => metroTheme = value;
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public MetroStyleManager StyleManager { get; set; }

		[DefaultValue(false)]
		[Category("Metro Appearance")]
		public bool UseCustomBackColor { get; set; }

		[Category("Metro Appearance")]
		[DefaultValue(false)]
		public bool UseCustomForeColor { get; set; }

		[DefaultValue(false)]
		[Category("Metro Appearance")]
		public bool UseStyleColors { get; set; }

		[DefaultValue(false)]
		[Browsable(false)]
		[Category("Metro Behaviour")]
		public bool UseSelectable
		{
			get => GetStyle(ControlStyles.Selectable);
			set => SetStyle(ControlStyles.Selectable, value);
		}

		protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
		{
			if (!GetStyle(ControlStyles.UserPaint) || CustomPaintBackground == null)
				return;
			CustomPaintBackground(this, e);
		}

		protected virtual void OnCustomPaint(MetroPaintEventArgs e)
		{
			if (!GetStyle(ControlStyles.UserPaint) || CustomPaint == null)
				return;
			CustomPaint(this, e);
		}

		protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
		{
			if (!GetStyle(ControlStyles.UserPaint) || CustomPaintForeground == null)
				return;
			CustomPaintForeground(this, e);
		}

		public event EventHandler AcceptsTabChanged;

		private void BaseTextBoxAcceptsTabChanged(object sender, EventArgs e)
		{
			if (AcceptsTabChanged == null)
				return;
			AcceptsTabChanged(this, e);
		}

		private void BaseTextBoxSizeChanged(object sender, EventArgs e)
		{
			OnSizeChanged(e);
		}

		private void BaseTextBoxCursorChanged(object sender, EventArgs e)
		{
			OnCursorChanged(e);
		}

		private void BaseTextBoxContextMenuStripChanged(object sender, EventArgs e)
		{
			OnContextMenuStripChanged(e);
		}

		private void BaseTextBoxClientSizeChanged(object sender, EventArgs e)
		{
			OnClientSizeChanged(e);
		}

		private void BaseTextBoxClick(object sender, EventArgs e)
		{
			OnClick(e);
		}

		private void BaseTextBoxChangeUiCues(object sender, UICuesEventArgs e)
		{
			OnChangeUICues(e);
		}

		private void BaseTextBoxCausesValidationChanged(object sender, EventArgs e)
		{
			OnCausesValidationChanged(e);
		}

		private void BaseTextBoxKeyUp(object sender, KeyEventArgs e)
		{
			OnKeyUp(e);
		}

		private void BaseTextBoxKeyPress(object sender, KeyPressEventArgs e)
		{
			OnKeyPress(e);
		}

		private void BaseTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			OnKeyDown(e);
		}

		private void BaseTextBoxTextChanged(object sender, EventArgs e)
		{
			OnTextChanged(e);
			if (baseTextBox.Text != "" && !_withtext)
			{
				_withtext = true;
				_cleared = false;
				Invalidate();
			}

			if (!(baseTextBox.Text == "") || _cleared)
				return;
			_withtext = false;
			_cleared = true;
			Invalidate();
		}

		public void Select(int start, int length)
		{
			baseTextBox.Select(start, length);
		}

		public void SelectAll()
		{
			baseTextBox.SelectAll();
		}

		public void Clear()
		{
			baseTextBox.Clear();
		}

		private void MetroTextBox_GotFocus(object sender, EventArgs e)
		{
			baseTextBox.Focus();
		}

		public void AppendText(string text)
		{
			baseTextBox.AppendText(text);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			try
			{
				var color = BackColor;
				baseTextBox.BackColor = color;
				if (!UseCustomBackColor)
				{
					color = MetroPaint.BackColor.Form(Theme);
					baseTextBox.BackColor = color;
				}

				if (color.A == byte.MaxValue)
				{
					e.Graphics.Clear(color);
				}
				else
				{
					base.OnPaintBackground(e);
					OnCustomPaintBackground(new MetroPaintEventArgs(color, Color.Empty, e.Graphics));
				}
			}
			catch
			{
				Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			try
			{
				if (GetStyle(ControlStyles.AllPaintingInWmPaint))
					OnPaintBackground(e);
				OnCustomPaint(new MetroPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
				OnPaintForeground(e);
			}
			catch
			{
				Invalidate();
			}
		}

		protected virtual void OnPaintForeground(PaintEventArgs e)
		{
			if (UseCustomForeColor)
				baseTextBox.ForeColor = ForeColor;
			else
				baseTextBox.ForeColor = MetroPaint.ForeColor.Button.Normal(Theme);
			var color = MetroPaint.BorderColor.ComboBox.Normal(Theme);
			if (UseStyleColors)
				color = MetroPaint.GetStyleColor(Style);
			if (_witherror)
			{
				color = MetroColors.Red;
				if (Style == MetroColorStyle.Red)
					color = MetroColors.Orange;
			}

			using (var pen = new Pen(color))
			{
				e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Width - 2, Height - 1));
			}

			DrawIcon(e.Graphics);
		}

		private void DrawIcon(Graphics g)
		{
			if (displayIcon && textBoxIcon != null)
			{
				var location = new Point(5, 5);
				if (textBoxIconRight)
					location = new Point(ClientRectangle.Width - iconSize.Width - 1, 1);
				g.DrawImage(textBoxIcon, new Rectangle(location, iconSize));
				UpdateBaseTextBox();
			}
			else
			{
				_button.Visible = _showbutton;
				if (_showbutton && _button != null)
					UpdateBaseTextBox();
			}

			OnCustomPaintForeground(new MetroPaintEventArgs(Color.Empty, baseTextBox.ForeColor, g));
		}

		public override void Refresh()
		{
			base.Refresh();
			UpdateBaseTextBox();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			UpdateBaseTextBox();
		}

		private void CreateBaseTextBox()
		{
			if (baseTextBox != null)
				return;
			baseTextBox = new PromptedTextBox();
			baseTextBox.BorderStyle = BorderStyle.None;
			baseTextBox.Font = MetroFonts.TextBox(metroTextBoxSize, metroTextBoxWeight);
			baseTextBox.Location = new Point(3, 3);
			baseTextBox.Size = new Size(Width - 6, Height - 6);
			Size = new Size(baseTextBox.Width + 6, baseTextBox.Height + 6);
			baseTextBox.TabStop = true;
			Controls.Add(baseTextBox);
			if (_button != null)
				return;
			_button = new MetroTextButton();
			_button.Theme = Theme;
			_button.Style = Style;
			_button.Location = new Point(3, 1);
			_button.Size = new Size(Height - 4, Height - 4);
			_button.TextChanged += _button_TextChanged;
			_button.MouseEnter += _button_MouseEnter;
			_button.MouseLeave += _button_MouseLeave;
			_button.Click += _button_Click;
			if (!Controls.Contains(_button))
				Controls.Add(_button);
			if (lnkClear != null)
				return;
			InitializeComponent();
		}

		public event ButClick ButtonClick;

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
		}

		private void _button_Click(object sender, EventArgs e)
		{
			if (ButtonClick == null)
				return;
			ButtonClick(this, e);
		}

		private void _button_MouseLeave(object sender, EventArgs e)
		{
			UseStyleColors = baseTextBox.Focused;
			Invalidate();
		}

		private void _button_MouseEnter(object sender, EventArgs e)
		{
			UseStyleColors = true;
			Invalidate();
		}

		private void _button_TextChanged(object sender, EventArgs e)
		{
			_button.Invalidate();
		}

		private void AddEventHandler()
		{
			baseTextBox.AcceptsTabChanged += BaseTextBoxAcceptsTabChanged;
			baseTextBox.CausesValidationChanged += BaseTextBoxCausesValidationChanged;
			baseTextBox.ChangeUICues += BaseTextBoxChangeUiCues;
			baseTextBox.Click += BaseTextBoxClick;
			baseTextBox.ClientSizeChanged += BaseTextBoxClientSizeChanged;
			baseTextBox.ContextMenuStripChanged += BaseTextBoxContextMenuStripChanged;
			baseTextBox.CursorChanged += BaseTextBoxCursorChanged;
			baseTextBox.KeyDown += BaseTextBoxKeyDown;
			baseTextBox.KeyPress += BaseTextBoxKeyPress;
			baseTextBox.KeyUp += BaseTextBoxKeyUp;
			baseTextBox.SizeChanged += BaseTextBoxSizeChanged;
			baseTextBox.TextChanged += BaseTextBoxTextChanged;
			baseTextBox.GotFocus += baseTextBox_GotFocus;
			baseTextBox.LostFocus += baseTextBox_LostFocus;
		}

		private void baseTextBox_LostFocus(object sender, EventArgs e)
		{
			UseStyleColors = false;
			Invalidate();
			InvokeLostFocus(this, e);
		}

		private void baseTextBox_GotFocus(object sender, EventArgs e)
		{
			_witherror = false;
			UseStyleColors = true;
			Invalidate();
			InvokeGotFocus(this, e);
		}

		private void UpdateBaseTextBox()
		{
			if (_button != null)
			{
				if (Height % 2 > 0)
				{
					_button.Size = new Size(Height - 2, Height - 2);
					_button.Location = new Point(Width - (_button.Width + 1), 1);
				}
				else
				{
					_button.Size = new Size(Height - 5, Height - 5);
					_button.Location = new Point(Width - _button.Width - 3, 2);
				}

				_button.Visible = _showbutton;
			}

			var num = 0;
			if (lnkClear != null)
			{
				lnkClear.Visible = false;
				if (_showclear && Text != "" && !ReadOnly && Enabled)
				{
					num = 16;
					lnkClear.Location = new Point(Width - (ButtonWidth + 17), (Height - 14) / 2);
					lnkClear.Visible = true;
				}
			}

			if (baseTextBox == null)
				return;
			baseTextBox.Font = MetroFonts.TextBox(metroTextBoxSize, metroTextBoxWeight);
			if (displayIcon)
			{
				var point = new Point(iconSize.Width + 10, 5);
				if (textBoxIconRight)
					point = new Point(3, 3);
				baseTextBox.Location = point;
				baseTextBox.Size = new Size(Width - (20 + ButtonWidth + num) - iconSize.Width, Height - 6);
			}
			else
			{
				baseTextBox.Location = new Point(3, 3);
				baseTextBox.Size = new Size(Width - (6 + ButtonWidth + num), Height - 6);
			}
		}

		private void InitializeComponent()
		{
			var componentResourceManager = new ComponentResourceManager(typeof(MetroTextBox));
			lnkClear = new MetroLink();
			SuspendLayout();
			lnkClear.FontSize = MetroLinkSize.Medium;
			lnkClear.FontWeight = MetroLinkWeight.Regular;
			//this.lnkClear.Image = (Image)componentResourceManager.GetObject("lnkClear.Image");
			lnkClear.ImageSize = 10;
			lnkClear.Location = new Point(654, 96);
			lnkClear.Name = "lnkClear";
			//this.lnkClear.NoFocusImage = (Image)componentResourceManager.GetObject("lnkClear.NoFocusImage");
			lnkClear.Size = new Size(12, 12);
			lnkClear.TabIndex = 2;
			lnkClear.UseSelectable = true;
			lnkClear.Click += lnkClear_Click;
			ResumeLayout(false);
			Controls.Add(lnkClear);
		}

		public event LUClear ClearClicked;

		private void lnkClear_Click(object sender, EventArgs e)
		{
			Focus();
			Clear();
			baseTextBox.Focus();
			if (ClearClicked == null)
				return;
			ClearClicked();
		}

		private class PromptedTextBox : TextBox
		{
			private const int OCM_COMMAND = 8465;
			private const int WM_PAINT = 15;
			private Color _waterMarkColor = MetroPaint.ForeColor.Button.Disabled(MetroThemeStyle.Dark);
			private bool drawPrompt;
			private string promptText = "";

			public PromptedTextBox()
			{
				SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
				drawPrompt = Text.Trim().Length == 0;
			}

			[DefaultValue("")]
			[Browsable(true)]
			[EditorBrowsable(EditorBrowsableState.Always)]
			public string WaterMark
			{
				get => promptText;
				set
				{
					promptText = value.Trim();
					Invalidate();
				}
			}

			public Color WaterMarkColor
			{
				get => _waterMarkColor;
				set
				{
					_waterMarkColor = value;
					Invalidate();
				}
			}

			public Font WaterMarkFont { get; set; } =
				MetroFonts.WaterMark(MetroLabelSize.Small, MetroWaterMarkWeight.Italic);

			private void DrawTextPrompt()
			{
				using (var graphics = CreateGraphics())
				{
					DrawTextPrompt(graphics);
				}
			}

			private void DrawTextPrompt(Graphics g)
			{
				var flags = TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding;
				var clientRectangle = ClientRectangle;
				switch (TextAlign)
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

				var solidBrush = new SolidBrush(WaterMarkColor);
				TextRenderer.DrawText(g, promptText, WaterMarkFont, clientRectangle, _waterMarkColor, BackColor, flags);
			}

			protected override void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);
				if (!drawPrompt)
					return;
				DrawTextPrompt(e.Graphics);
			}

			protected override void OnCreateControl()
			{
				base.OnCreateControl();
			}

			protected override void OnTextAlignChanged(EventArgs e)
			{
				base.OnTextAlignChanged(e);
				Invalidate();
			}

			protected override void OnTextChanged(EventArgs e)
			{
				base.OnTextChanged(e);
				drawPrompt = Text.Trim().Length == 0;
				Invalidate();
			}

			protected override void WndProc(ref Message m)
			{
				base.WndProc(ref m);
				if (m.Msg != 15 && m.Msg != 8465 || !drawPrompt || GetStyle(ControlStyles.UserPaint))
					return;
				DrawTextPrompt();
			}

			protected override void OnLostFocus(EventArgs e)
			{
				base.OnLostFocus(e);
			}
		}

		[ToolboxItem(false)]
		public class MetroTextButton : Button, IMetroControl
		{
			private Bitmap _image;
			private bool isHovered;
			private bool isPressed;
			private MetroColorStyle metroStyle;
			private MetroThemeStyle metroTheme;

			public new Image Image
			{
				get => base.Image;
				set
				{
					base.Image = value;
					if (value == null)
						return;
					_image = ApplyInvert(new Bitmap(value));
				}
			}

			protected Size iconSize
			{
				get
				{
					if (Image == null)
						return new Size(-1, -1);
					var size = Image.Size;
					var num = 14.0 / size.Height;
					var point = new Point(1, 1);
					return new Size((int) (size.Width * num), (int) (size.Height * num));
				}
			}

			[Category("Metro Appearance")] public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;

			[Category("Metro Appearance")] public event EventHandler<MetroPaintEventArgs> CustomPaint;

			[Category("Metro Appearance")] public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;

			[Category("Metro Appearance")]
			[DefaultValue(MetroColorStyle.Default)]
			public MetroColorStyle Style
			{
				get
				{
					if (DesignMode || metroStyle != MetroColorStyle.Default)
						return metroStyle;
					if (StyleManager != null && metroStyle == MetroColorStyle.Default)
						return StyleManager.Style;
					return StyleManager == null && metroStyle == MetroColorStyle.Default
						? MetroColorStyle.Blue
						: metroStyle;
				}
				set => metroStyle = value;
			}

			[Category("Metro Appearance")]
			[DefaultValue(MetroThemeStyle.Default)]
			public MetroThemeStyle Theme
			{
				get
				{
					if (DesignMode || metroTheme != MetroThemeStyle.Default)
						return metroTheme;
					if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
						return StyleManager.Theme;
					return StyleManager == null && metroTheme == MetroThemeStyle.Default
						? MetroThemeStyle.Light
						: metroTheme;
				}
				set => metroTheme = value;
			}

			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			[Browsable(false)]
			public MetroStyleManager StyleManager { get; set; }

			[DefaultValue(false)]
			[Category("Metro Appearance")]
			public bool UseCustomBackColor { get; set; }

			[DefaultValue(false)]
			[Category("Metro Appearance")]
			public bool UseCustomForeColor { get; set; }

			[DefaultValue(false)]
			[Category("Metro Appearance")]
			public bool UseStyleColors { get; set; }

			[Browsable(false)]
			[DefaultValue(false)]
			[Category("Metro Behaviour")]
			public bool UseSelectable
			{
				get => GetStyle(ControlStyles.Selectable);
				set => SetStyle(ControlStyles.Selectable, value);
			}

			protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
			{
				if (!GetStyle(ControlStyles.UserPaint) || CustomPaintBackground == null)
					return;
				CustomPaintBackground(this, e);
			}

			protected virtual void OnCustomPaint(MetroPaintEventArgs e)
			{
				if (!GetStyle(ControlStyles.UserPaint) || CustomPaint == null)
					return;
				CustomPaint(this, e);
			}

			protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
			{
				if (!GetStyle(ControlStyles.UserPaint) || CustomPaintForeground == null)
					return;
				CustomPaintForeground(this, e);
			}

			protected override void OnCreateControl()
			{
				base.OnCreateControl();
				SetStyle(
					ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint |
					ControlStyles.OptimizedDoubleBuffer, true);
			}

			protected override void OnPaint(PaintEventArgs e)
			{
				var theme = Theme;
				var style = Style;
				Color foreColor;
				Color color;
				if (Parent != null)
				{
					if (Parent is IMetroForm)
					{
						theme = ((IMetroForm) Parent).Theme;
						style = ((IMetroForm) Parent).Style;
						foreColor = MetroPaint.ForeColor.Button.Press(theme);
						color = MetroPaint.GetStyleColor(style);
					}
					else if (Parent is IMetroControl)
					{
						theme = ((IMetroControl) Parent).Theme;
						style = ((IMetroControl) Parent).Style;
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

				if (isHovered && !isPressed && Enabled)
				{
					int r = color.R;
					int g = color.G;
					int b = color.B;
					color = ControlPaint.Light(color, 0.25f);
				}
				else if (isHovered && isPressed && Enabled)
				{
					foreColor = MetroPaint.ForeColor.Button.Press(theme);
					color = MetroPaint.GetStyleColor(style);
				}
				else if (!Enabled)
				{
					foreColor = MetroPaint.ForeColor.Button.Disabled(theme);
					color = MetroPaint.BackColor.Button.Disabled(theme);
				}
				else
				{
					foreColor = MetroPaint.ForeColor.Button.Press(theme);
				}

				e.Graphics.Clear(color);
				var font = MetroFonts.Button(MetroButtonSize.Small, MetroButtonWeight.Bold);
				TextRenderer.DrawText(e.Graphics, Text, font, ClientRectangle, foreColor, color,
					TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
				DrawIcon(e.Graphics);
			}

			public Bitmap ApplyInvert(Bitmap bitmapImage)
			{
				for (var y = 0; y < bitmapImage.Height; ++y)
				for (var x = 0; x < bitmapImage.Width; ++x)
				{
					var pixel = bitmapImage.GetPixel(x, y);
					var a = pixel.A;
					var num1 = (byte) (byte.MaxValue - (uint) pixel.R);
					var num2 = (byte) (byte.MaxValue - (uint) pixel.G);
					var num3 = (byte) (byte.MaxValue - (uint) pixel.B);
					bitmapImage.SetPixel(x, y, Color.FromArgb(a, num1, num2, num3));
				}

				return bitmapImage;
			}

			private void DrawIcon(Graphics g)
			{
				if (Image == null)
					return;
				var location = new Point(2, (ClientRectangle.Height - iconSize.Height) / 2);
				var num = 5;
				switch (ImageAlign)
				{
					case ContentAlignment.TopLeft:
						location = new Point(num, num);
						break;
					case ContentAlignment.TopCenter:
						location = new Point((ClientRectangle.Width - iconSize.Width) / 2, num);
						break;
					case ContentAlignment.TopRight:
						location = new Point(ClientRectangle.Width - iconSize.Width - num, num);
						break;
					case ContentAlignment.MiddleLeft:
						location = new Point(num, (ClientRectangle.Height - iconSize.Height) / 2);
						break;
					case ContentAlignment.MiddleCenter:
						location = new Point((ClientRectangle.Width - iconSize.Width) / 2,
							(ClientRectangle.Height - iconSize.Height) / 2);
						break;
					case ContentAlignment.MiddleRight:
						location = new Point(ClientRectangle.Width - iconSize.Width - num,
							(ClientRectangle.Height - iconSize.Height) / 2);
						break;
					case ContentAlignment.BottomLeft:
						location = new Point(num, ClientRectangle.Height - iconSize.Height - num);
						break;
					case ContentAlignment.BottomCenter:
						location = new Point((ClientRectangle.Width - iconSize.Width) / 2,
							ClientRectangle.Height - iconSize.Height - num);
						break;
					case ContentAlignment.BottomRight:
						location = new Point(ClientRectangle.Width - iconSize.Width - num,
							ClientRectangle.Height - iconSize.Height - num);
						break;
				}

				g.DrawImage(Theme == MetroThemeStyle.Dark ? isPressed ? _image : Image : isPressed ? Image : _image,
					new Rectangle(location, iconSize));
			}

			protected override void OnMouseEnter(EventArgs e)
			{
				isHovered = true;
				Invalidate();
				base.OnMouseEnter(e);
			}

			protected override void OnMouseDown(MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Left)
				{
					isPressed = true;
					Invalidate();
				}

				base.OnMouseDown(e);
			}

			protected override void OnMouseUp(MouseEventArgs e)
			{
				isPressed = false;
				Invalidate();
				base.OnMouseUp(e);
			}

			protected override void OnMouseLeave(EventArgs e)
			{
				isHovered = false;
				Invalidate();
				base.OnMouseLeave(e);
			}
		}
	}
}