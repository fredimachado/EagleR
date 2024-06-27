namespace EagleR.Desktop;

partial class Settings
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        launchAutomaticallyCheck = new CheckBox();
        Cancel = new Button();
        Save = new Button();
        SuspendLayout();
        // 
        // launchAutomaticallyCheck
        // 
        launchAutomaticallyCheck.AutoSize = true;
        launchAutomaticallyCheck.Location = new Point(34, 36);
        launchAutomaticallyCheck.Name = "launchAutomaticallyCheck";
        launchAutomaticallyCheck.Size = new Size(318, 34);
        launchAutomaticallyCheck.TabIndex = 0;
        launchAutomaticallyCheck.Text = "Launch automatically on login";
        launchAutomaticallyCheck.UseVisualStyleBackColor = true;
        // 
        // Cancel
        // 
        Cancel.Location = new Point(428, 133);
        Cancel.Name = "Cancel";
        Cancel.Size = new Size(158, 53);
        Cancel.TabIndex = 1;
        Cancel.Text = "Cancel";
        Cancel.UseVisualStyleBackColor = true;
        Cancel.Click += Cancel_Click;
        // 
        // Save
        // 
        Save.Location = new Point(602, 133);
        Save.Name = "Save";
        Save.Size = new Size(158, 53);
        Save.TabIndex = 1;
        Save.Text = "Save";
        Save.UseVisualStyleBackColor = true;
        Save.Click += Save_Click;
        // 
        // Settings
        // 
        AcceptButton = Save;
        AutoScaleDimensions = new SizeF(12F, 30F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 210);
        Controls.Add(Save);
        Controls.Add(Cancel);
        Controls.Add(launchAutomaticallyCheck);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Settings";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Settings";
        Load += Settings_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private CheckBox launchAutomaticallyCheck;
    private Button Cancel;
    private Button Save;
}