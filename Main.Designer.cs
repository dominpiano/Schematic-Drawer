
namespace SchematicDrawer
{
    partial class Main
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.addComponentMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resistorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capacitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inductorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addComponentMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // addComponentMenu
            // 
            this.addComponentMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resistorToolStripMenuItem,
            this.capacitorToolStripMenuItem,
            this.inductorToolStripMenuItem});
            this.addComponentMenu.Name = "addComponentMenu";
            this.addComponentMenu.Size = new System.Drawing.Size(181, 92);
            // 
            // resistorToolStripMenuItem
            // 
            this.resistorToolStripMenuItem.Name = "resistorToolStripMenuItem";
            this.resistorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resistorToolStripMenuItem.Text = "Resistor";
            this.resistorToolStripMenuItem.Click += new System.EventHandler(this.resistorToolStripMenuItem_Click);
            // 
            // capacitorToolStripMenuItem
            // 
            this.capacitorToolStripMenuItem.Name = "capacitorToolStripMenuItem";
            this.capacitorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.capacitorToolStripMenuItem.Text = "Capacitor";
            this.capacitorToolStripMenuItem.Click += new System.EventHandler(this.capacitorToolStripMenuItem_Click);
            // 
            // inductorToolStripMenuItem
            // 
            this.inductorToolStripMenuItem.Name = "inductorToolStripMenuItem";
            this.inductorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inductorToolStripMenuItem.Text = "Inductor";
            this.inductorToolStripMenuItem.Click += new System.EventHandler(this.inductorToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SchematicDrawer.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schematic Drawer";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.formPaint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            this.addComponentMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip addComponentMenu;
        private System.Windows.Forms.ToolStripMenuItem resistorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capacitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inductorToolStripMenuItem;
    }
}

