﻿namespace SDK.src {
    partial class overlay {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
            panel1 = new Panel( );
            SuspendLayout( );
            // 
            // panel1
            // 
            panel1.Location = new Point( 512, 196 );
            panel1.Name = "panel1";
            panel1.Size = new Size( 131, 242 );
            panel1.TabIndex = 0;
            panel1.Paint +=  PanelBorder ;
            // 
            // overlay
            // 
            AutoScaleDimensions = new SizeF( 7F, 15F );
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size( 800, 450 );
            Controls.Add( panel1 );
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "overlay";
            Text = "overlay";
            ResumeLayout( false );
        }

        #endregion

        private Panel panel1;
    }
}