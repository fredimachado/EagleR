namespace EagleR.Desktop;

partial class Main
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
        tableLayoutPanel = new TableLayoutPanel();
        logsLabel = new Label();
        logsText = new TextBox();
        statusStrip1 = new StatusStrip();
        lastFetchStatusLabel = new ToolStripStatusLabel();
        trayIcon = new NotifyIcon(components);
        contextMenu = new ContextMenuStrip(components);
        openEaglerMenu = new ToolStripMenuItem();
        quitEaglerMenu = new ToolStripMenuItem();
        tableLayoutPanel.SuspendLayout();
        statusStrip1.SuspendLayout();
        contextMenu.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel
        // 
        tableLayoutPanel.ColumnCount = 1;
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
        tableLayoutPanel.Controls.Add(logsLabel, 0, 0);
        tableLayoutPanel.Controls.Add(logsText, 0, 1);
        tableLayoutPanel.Controls.Add(statusStrip1, 0, 2);
        tableLayoutPanel.Dock = DockStyle.Fill;
        tableLayoutPanel.Location = new Point(0, 0);
        tableLayoutPanel.Name = "tableLayoutPanel";
        tableLayoutPanel.RowCount = 3;
        tableLayoutPanel.RowStyles.Add(new RowStyle());
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel.RowStyles.Add(new RowStyle());
        tableLayoutPanel.Size = new Size(1333, 749);
        tableLayoutPanel.TabIndex = 0;
        // 
        // logsLabel
        // 
        logsLabel.AutoSize = true;
        logsLabel.Location = new Point(3, 0);
        logsLabel.Name = "logsLabel";
        logsLabel.Size = new Size(61, 30);
        logsLabel.TabIndex = 0;
        logsLabel.Text = "Logs:";
        // 
        // logsText
        // 
        logsText.Dock = DockStyle.Fill;
        logsText.Location = new Point(3, 33);
        logsText.Multiline = true;
        logsText.Name = "logsText";
        logsText.ReadOnly = true;
        logsText.Size = new Size(1327, 674);
        logsText.TabIndex = 1;
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(28, 28);
        statusStrip1.Items.AddRange(new ToolStripItem[] { lastFetchStatusLabel });
        statusStrip1.Location = new Point(0, 710);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(1333, 39);
        statusStrip1.TabIndex = 2;
        statusStrip1.Text = "statusStrip1";
        // 
        // lastFetchStatusLabel
        // 
        lastFetchStatusLabel.Name = "lastFetchStatusLabel";
        lastFetchStatusLabel.Size = new Size(111, 30);
        lastFetchStatusLabel.Text = "Last Fetch:";
        // 
        // trayIcon
        // 
        trayIcon.ContextMenuStrip = contextMenu;
        trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
        trayIcon.Text = "EagleR";
        trayIcon.Visible = true;
        trayIcon.BalloonTipClicked += TrayIcon_BalloonTipClicked;
        trayIcon.DoubleClick += TrayIcon_DoubleClick;
        // 
        // contextMenu
        // 
        contextMenu.ImageScalingSize = new Size(28, 28);
        contextMenu.Items.AddRange(new ToolStripItem[] { openEaglerMenu, quitEaglerMenu });
        contextMenu.Name = "contextMenu";
        contextMenu.Size = new Size(138, 76);
        // 
        // openEaglerMenu
        // 
        openEaglerMenu.Name = "openEaglerMenu";
        openEaglerMenu.Size = new Size(137, 36);
        openEaglerMenu.Text = "Open";
        openEaglerMenu.Click += OpenEaglerMenu_Click;
        // 
        // quitEaglerMenu
        // 
        quitEaglerMenu.Name = "quitEaglerMenu";
        quitEaglerMenu.Size = new Size(137, 36);
        quitEaglerMenu.Text = "Quit";
        quitEaglerMenu.Click += QuitEaglerMenu_Click;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(12F, 30F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1333, 749);
        Controls.Add(tableLayoutPanel);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Main";
        ShowInTaskbar = false;
        Text = "EagleR";
        WindowState = FormWindowState.Minimized;
        FormClosing += Main_FormClosing;
        FormClosed += Main_FormClosed;
        Load += Main_Load;
        Shown += Main_Shown;
        tableLayoutPanel.ResumeLayout(false);
        tableLayoutPanel.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        contextMenu.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel;
    private Label logsLabel;
    private TextBox logsText;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lastFetchStatusLabel;
    private NotifyIcon trayIcon;
    private ContextMenuStrip contextMenu;
    private ToolStripMenuItem openEaglerMenu;
    private ToolStripMenuItem quitEaglerMenu;
}
