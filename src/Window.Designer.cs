namespace SDK {
    partial class Window {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Window ) );
            logoPic = new PictureBox( );
            sidePanel = new Panel( );
            topPanel = new Panel( );
            leftPanel = new Panel( );
            panel1 = new Panel( );
            label1 = new Label( );
            rightPanel = new Panel( );
            ( ( System.ComponentModel.ISupportInitialize )logoPic ).BeginInit( );
            sidePanel.SuspendLayout( );
            panel1.SuspendLayout( );
            SuspendLayout( );
            // 
            // logoPic
            // 
            logoPic.Image = ( Image )resources.GetObject( "logoPic.Image" );
            logoPic.Location = new Point( 38, 15 );
            logoPic.Margin = new Padding( 0 );
            logoPic.Name = "logoPic";
            logoPic.Size = new Size( 75, 75 );
            logoPic.TabIndex = 0;
            logoPic.TabStop = false;
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.FromArgb(     11,     0,     18 );
            sidePanel.Controls.Add( logoPic );
            sidePanel.Location = new Point( -11, 0 );
            sidePanel.Margin = new Padding( 0 );
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size( 143, 571 );
            sidePanel.TabIndex = 1;
            sidePanel.Paint +=  PanelBorder ;
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(     11,     0,     18 );
            topPanel.Location = new Point( 131, -8 );
            topPanel.Margin = new Padding( 0 );
            topPanel.Name = "topPanel";
            topPanel.Size = new Size( 677, 108 );
            topPanel.TabIndex = 2;
            topPanel.Paint +=  PanelBorder ;
            topPanel.MouseDown +=  DragHandle ;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(     11,     0,     18 );
            leftPanel.Location = new Point( 145, 110 );
            leftPanel.Margin = new Padding( 10 );
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size( 312, 426 );
            leftPanel.TabIndex = 3;
            leftPanel.Paint +=  PanelBorder ;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(     11,     0,     18 );
            panel1.Controls.Add( label1 );
            panel1.Location = new Point( 131, 546 );
            panel1.Margin = new Padding( 0 );
            panel1.Name = "panel1";
            panel1.Size = new Size( 693, 25 );
            panel1.TabIndex = 4;
            panel1.Paint +=  PanelBorder ;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point( 574, 5 );
            label1.Margin = new Padding( 0 );
            label1.Name = "label1";
            label1.Size = new Size( 91, 14 );
            label1.TabIndex = 0;
            label1.Text = "2024 - RyzeX";
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.FromArgb(     11,     0,     18 );
            rightPanel.Location = new Point( 477, 110 );
            rightPanel.Margin = new Padding( 10 );
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size( 312, 426 );
            rightPanel.TabIndex = 4;
            rightPanel.Paint +=  PanelBorder ;
            // 
            // Window
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(     12,     12,     12 );
            BackgroundImage = ( Image )resources.GetObject( "$this.BackgroundImage" );
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size( 806, 571 );
            Controls.Add( rightPanel );
            Controls.Add( panel1 );
            Controls.Add( leftPanel );
            Controls.Add( topPanel );
            Controls.Add( sidePanel );
            DoubleBuffered = true;
            Font = new Font( "Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point,   0 );
            ForeColor = Color.FromArgb(     212,     212,     212 );
            FormBorderStyle = FormBorderStyle.None;
            Name = "Window";
            Text = "Form1";
            Load +=  Init ;
            Paint +=  OnPaint ;
            ( ( System.ComponentModel.ISupportInitialize )logoPic ).EndInit( );
            sidePanel.ResumeLayout( false );
            panel1.ResumeLayout( false );
            panel1.PerformLayout( );
            ResumeLayout( false );
        }

        #endregion

        private PictureBox logoPic;
        private Panel sidePanel;
        private Panel topPanel;
        private Panel leftPanel;
        private Panel panel1;
        private Panel rightPanel;
        private Label label1;
    }
}
