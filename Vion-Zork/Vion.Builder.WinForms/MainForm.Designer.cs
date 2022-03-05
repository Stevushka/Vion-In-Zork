
namespace Vion_Builder
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.WelcomeMessageContainer = new System.Windows.Forms.GroupBox();
            this.WelcomeMessageTextBox = new System.Windows.Forms.TextBox();
            this.MessageCancelButton = new System.Windows.Forms.Button();
            this.MessageConfirmButton = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MenuFile = new System.Windows.Forms.MenuItem();
            this.MenuFileNewOption = new System.Windows.Forms.MenuItem();
            this.MenuFileOpenOption = new System.Windows.Forms.MenuItem();
            this.MenuFileDivider = new System.Windows.Forms.MenuItem();
            this.MenuFileSaveOption = new System.Windows.Forms.MenuItem();
            this.MenuFileSaveAsOption = new System.Windows.Forms.MenuItem();
            this.GameTab = new System.Windows.Forms.TabPage();
            this.WorldTab = new System.Windows.Forms.TabPage();
            this.LocationsGroupBox = new System.Windows.Forms.GroupBox();
            this.LocationUpdateButton = new System.Windows.Forms.Button();
            this.LocationsListBox = new System.Windows.Forms.ListBox();
            this.LocationAddButton = new System.Windows.Forms.Button();
            this.LocationRemoveButton = new System.Windows.Forms.Button();
            this.LocationDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.LocationNameTextBox = new System.Windows.Forms.TextBox();
            this.LocationDescriptionLabel = new System.Windows.Forms.Label();
            this.LocationNameLabel = new System.Windows.Forms.Label();
            this.NeighborsGroupBox = new System.Windows.Forms.GroupBox();
            this.NeighborSouthDropBox = new System.Windows.Forms.ComboBox();
            this.NeighborWestDropBox = new System.Windows.Forms.ComboBox();
            this.NeighborEastDropBox = new System.Windows.Forms.ComboBox();
            this.NeighborSouthLabel = new System.Windows.Forms.Label();
            this.NeighborWestLabel = new System.Windows.Forms.Label();
            this.NeighborEastLabel = new System.Windows.Forms.Label();
            this.NeighborNorthLabel = new System.Windows.Forms.Label();
            this.NeighborNorthDropBox = new System.Windows.Forms.ComboBox();
            this.StartingLocationDropBox = new System.Windows.Forms.ComboBox();
            this.StartingLocationLabel = new System.Windows.Forms.Label();
            this.defaultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TabControl = new System.Windows.Forms.TabControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.WelcomeMessageContainer.SuspendLayout();
            this.GameTab.SuspendLayout();
            this.WorldTab.SuspendLayout();
            this.LocationsGroupBox.SuspendLayout();
            this.NeighborsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultBindingSource)).BeginInit();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // WelcomeMessageContainer
            // 
            this.WelcomeMessageContainer.Controls.Add(this.WelcomeMessageTextBox);
            this.WelcomeMessageContainer.Controls.Add(this.MessageCancelButton);
            this.WelcomeMessageContainer.Controls.Add(this.MessageConfirmButton);
            this.WelcomeMessageContainer.Location = new System.Drawing.Point(8, 6);
            this.WelcomeMessageContainer.Name = "WelcomeMessageContainer";
            this.WelcomeMessageContainer.Size = new System.Drawing.Size(524, 139);
            this.WelcomeMessageContainer.TabIndex = 4;
            this.WelcomeMessageContainer.TabStop = false;
            this.WelcomeMessageContainer.Text = "Welcome Message";
            // 
            // WelcomeMessageTextBox
            // 
            this.WelcomeMessageTextBox.Enabled = false;
            this.WelcomeMessageTextBox.Location = new System.Drawing.Point(6, 19);
            this.WelcomeMessageTextBox.Multiline = true;
            this.WelcomeMessageTextBox.Name = "WelcomeMessageTextBox";
            this.WelcomeMessageTextBox.Size = new System.Drawing.Size(512, 73);
            this.WelcomeMessageTextBox.TabIndex = 1;
            this.WelcomeMessageTextBox.Text = "Welcome to Zork!";
            // 
            // MessageCancelButton
            // 
            this.MessageCancelButton.Enabled = false;
            this.MessageCancelButton.Location = new System.Drawing.Point(311, 108);
            this.MessageCancelButton.Name = "MessageCancelButton";
            this.MessageCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MessageCancelButton.TabIndex = 3;
            this.MessageCancelButton.Text = "Cancel";
            this.MessageCancelButton.UseVisualStyleBackColor = true;
            this.MessageCancelButton.Click += new System.EventHandler(this.MessageCancelButton_Click);
            // 
            // MessageConfirmButton
            // 
            this.MessageConfirmButton.Enabled = false;
            this.MessageConfirmButton.Location = new System.Drawing.Point(113, 108);
            this.MessageConfirmButton.Name = "MessageConfirmButton";
            this.MessageConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.MessageConfirmButton.TabIndex = 2;
            this.MessageConfirmButton.Text = "Ok";
            this.MessageConfirmButton.UseVisualStyleBackColor = true;
            this.MessageConfirmButton.Click += new System.EventHandler(this.MessageConfirmButton_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuFile});
            // 
            // MenuFile
            // 
            this.MenuFile.Index = 0;
            this.MenuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuFileNewOption,
            this.MenuFileOpenOption,
            this.MenuFileDivider,
            this.MenuFileSaveOption,
            this.MenuFileSaveAsOption});
            this.MenuFile.Text = "&File";
            // 
            // MenuFileNewOption
            // 
            this.MenuFileNewOption.Index = 0;
            this.MenuFileNewOption.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.MenuFileNewOption.Text = "&New Game File";
            this.MenuFileNewOption.Click += new System.EventHandler(this.New_File);
            // 
            // MenuFileOpenOption
            // 
            this.MenuFileOpenOption.Index = 1;
            this.MenuFileOpenOption.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.MenuFileOpenOption.Text = "&Open Game File";
            this.MenuFileOpenOption.Click += new System.EventHandler(this.Open_File);
            // 
            // MenuFileDivider
            // 
            this.MenuFileDivider.Index = 2;
            this.MenuFileDivider.Text = "-";
            // 
            // MenuFileSaveOption
            // 
            this.MenuFileSaveOption.Enabled = false;
            this.MenuFileSaveOption.Index = 3;
            this.MenuFileSaveOption.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.MenuFileSaveOption.Text = "&Save Game File";
            this.MenuFileSaveOption.Click += new System.EventHandler(this.Save_File);
            // 
            // MenuFileSaveAsOption
            // 
            this.MenuFileSaveAsOption.Enabled = false;
            this.MenuFileSaveAsOption.Index = 4;
            this.MenuFileSaveAsOption.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.MenuFileSaveAsOption.Text = "&Save Game File As...";
            this.MenuFileSaveAsOption.Click += new System.EventHandler(this.Save_As_File);
            // 
            // GameTab
            // 
            this.GameTab.Controls.Add(this.WelcomeMessageContainer);
            this.GameTab.Location = new System.Drawing.Point(4, 22);
            this.GameTab.Name = "GameTab";
            this.GameTab.Padding = new System.Windows.Forms.Padding(3);
            this.GameTab.Size = new System.Drawing.Size(538, 347);
            this.GameTab.TabIndex = 2;
            this.GameTab.Text = "Game";
            this.GameTab.UseVisualStyleBackColor = true;
            // 
            // WorldTab
            // 
            this.WorldTab.Controls.Add(this.LocationsGroupBox);
            this.WorldTab.Controls.Add(this.LocationDescriptionTextBox);
            this.WorldTab.Controls.Add(this.LocationNameTextBox);
            this.WorldTab.Controls.Add(this.LocationDescriptionLabel);
            this.WorldTab.Controls.Add(this.LocationNameLabel);
            this.WorldTab.Controls.Add(this.NeighborsGroupBox);
            this.WorldTab.Controls.Add(this.StartingLocationDropBox);
            this.WorldTab.Controls.Add(this.StartingLocationLabel);
            this.WorldTab.Location = new System.Drawing.Point(4, 22);
            this.WorldTab.Name = "WorldTab";
            this.WorldTab.Padding = new System.Windows.Forms.Padding(3);
            this.WorldTab.Size = new System.Drawing.Size(538, 347);
            this.WorldTab.TabIndex = 0;
            this.WorldTab.Text = "World";
            this.WorldTab.UseVisualStyleBackColor = true;
            // 
            // LocationsGroupBox
            // 
            this.LocationsGroupBox.Controls.Add(this.LocationUpdateButton);
            this.LocationsGroupBox.Controls.Add(this.LocationsListBox);
            this.LocationsGroupBox.Controls.Add(this.LocationAddButton);
            this.LocationsGroupBox.Controls.Add(this.LocationRemoveButton);
            this.LocationsGroupBox.Location = new System.Drawing.Point(6, 56);
            this.LocationsGroupBox.Name = "LocationsGroupBox";
            this.LocationsGroupBox.Size = new System.Drawing.Size(204, 291);
            this.LocationsGroupBox.TabIndex = 2;
            this.LocationsGroupBox.TabStop = false;
            this.LocationsGroupBox.Text = "Rooms";
            // 
            // LocationUpdateButton
            // 
            this.LocationUpdateButton.Enabled = false;
            this.LocationUpdateButton.Location = new System.Drawing.Point(138, 260);
            this.LocationUpdateButton.Name = "LocationUpdateButton";
            this.LocationUpdateButton.Size = new System.Drawing.Size(60, 25);
            this.LocationUpdateButton.TabIndex = 5;
            this.LocationUpdateButton.Text = "Update";
            this.LocationUpdateButton.UseVisualStyleBackColor = true;
            this.LocationUpdateButton.Click += new System.EventHandler(this.LocationUpdateButton_Click);
            // 
            // LocationsListBox
            // 
            this.LocationsListBox.FormattingEnabled = true;
            this.LocationsListBox.Location = new System.Drawing.Point(5, 19);
            this.LocationsListBox.Name = "LocationsListBox";
            this.LocationsListBox.Size = new System.Drawing.Size(193, 225);
            this.LocationsListBox.TabIndex = 2;
            this.LocationsListBox.SelectedValueChanged += new System.EventHandler(this.LocationsListBox_SelectedValueChanged);
            // 
            // LocationAddButton
            // 
            this.LocationAddButton.Enabled = false;
            this.LocationAddButton.Location = new System.Drawing.Point(6, 260);
            this.LocationAddButton.Name = "LocationAddButton";
            this.LocationAddButton.Size = new System.Drawing.Size(60, 25);
            this.LocationAddButton.TabIndex = 3;
            this.LocationAddButton.Text = "Add";
            this.LocationAddButton.UseVisualStyleBackColor = true;
            this.LocationAddButton.Click += new System.EventHandler(this.LocationAddButton_Click);
            // 
            // LocationRemoveButton
            // 
            this.LocationRemoveButton.Enabled = false;
            this.LocationRemoveButton.Location = new System.Drawing.Point(72, 260);
            this.LocationRemoveButton.Name = "LocationRemoveButton";
            this.LocationRemoveButton.Size = new System.Drawing.Size(60, 25);
            this.LocationRemoveButton.TabIndex = 4;
            this.LocationRemoveButton.Text = "Remove";
            this.LocationRemoveButton.UseVisualStyleBackColor = true;
            this.LocationRemoveButton.Click += new System.EventHandler(this.LocationRemoveButton_Click);
            // 
            // LocationDescriptionTextBox
            // 
            this.LocationDescriptionTextBox.Enabled = false;
            this.LocationDescriptionTextBox.Location = new System.Drawing.Point(230, 72);
            this.LocationDescriptionTextBox.Multiline = true;
            this.LocationDescriptionTextBox.Name = "LocationDescriptionTextBox";
            this.LocationDescriptionTextBox.Size = new System.Drawing.Size(300, 100);
            this.LocationDescriptionTextBox.TabIndex = 7;
            // 
            // LocationNameTextBox
            // 
            this.LocationNameTextBox.Enabled = false;
            this.LocationNameTextBox.Location = new System.Drawing.Point(230, 25);
            this.LocationNameTextBox.Name = "LocationNameTextBox";
            this.LocationNameTextBox.Size = new System.Drawing.Size(300, 20);
            this.LocationNameTextBox.TabIndex = 6;
            // 
            // LocationDescriptionLabel
            // 
            this.LocationDescriptionLabel.AutoSize = true;
            this.LocationDescriptionLabel.Location = new System.Drawing.Point(227, 56);
            this.LocationDescriptionLabel.Name = "LocationDescriptionLabel";
            this.LocationDescriptionLabel.Size = new System.Drawing.Size(91, 13);
            this.LocationDescriptionLabel.TabIndex = 10;
            this.LocationDescriptionLabel.Text = "Room Description";
            // 
            // LocationNameLabel
            // 
            this.LocationNameLabel.AutoSize = true;
            this.LocationNameLabel.Location = new System.Drawing.Point(227, 8);
            this.LocationNameLabel.Name = "LocationNameLabel";
            this.LocationNameLabel.Size = new System.Drawing.Size(66, 13);
            this.LocationNameLabel.TabIndex = 8;
            this.LocationNameLabel.Text = "Room Name";
            // 
            // NeighborsGroupBox
            // 
            this.NeighborsGroupBox.Controls.Add(this.NeighborSouthDropBox);
            this.NeighborsGroupBox.Controls.Add(this.NeighborWestDropBox);
            this.NeighborsGroupBox.Controls.Add(this.NeighborEastDropBox);
            this.NeighborsGroupBox.Controls.Add(this.NeighborSouthLabel);
            this.NeighborsGroupBox.Controls.Add(this.NeighborWestLabel);
            this.NeighborsGroupBox.Controls.Add(this.NeighborEastLabel);
            this.NeighborsGroupBox.Controls.Add(this.NeighborNorthLabel);
            this.NeighborsGroupBox.Controls.Add(this.NeighborNorthDropBox);
            this.NeighborsGroupBox.Location = new System.Drawing.Point(230, 179);
            this.NeighborsGroupBox.Name = "NeighborsGroupBox";
            this.NeighborsGroupBox.Size = new System.Drawing.Size(300, 168);
            this.NeighborsGroupBox.TabIndex = 8;
            this.NeighborsGroupBox.TabStop = false;
            this.NeighborsGroupBox.Text = "Neighbors";
            // 
            // NeighborSouthDropBox
            // 
            this.NeighborSouthDropBox.Enabled = false;
            this.NeighborSouthDropBox.FormattingEnabled = true;
            this.NeighborSouthDropBox.Location = new System.Drawing.Point(100, 138);
            this.NeighborSouthDropBox.Margin = new System.Windows.Forms.Padding(1);
            this.NeighborSouthDropBox.MaxDropDownItems = 100;
            this.NeighborSouthDropBox.Name = "NeighborSouthDropBox";
            this.NeighborSouthDropBox.Size = new System.Drawing.Size(96, 21);
            this.NeighborSouthDropBox.TabIndex = 10;
            // 
            // NeighborWestDropBox
            // 
            this.NeighborWestDropBox.Enabled = false;
            this.NeighborWestDropBox.FormattingEnabled = true;
            this.NeighborWestDropBox.Location = new System.Drawing.Point(4, 79);
            this.NeighborWestDropBox.Margin = new System.Windows.Forms.Padding(1);
            this.NeighborWestDropBox.MaxDropDownItems = 100;
            this.NeighborWestDropBox.Name = "NeighborWestDropBox";
            this.NeighborWestDropBox.Size = new System.Drawing.Size(96, 21);
            this.NeighborWestDropBox.TabIndex = 11;
            // 
            // NeighborEastDropBox
            // 
            this.NeighborEastDropBox.Enabled = false;
            this.NeighborEastDropBox.FormattingEnabled = true;
            this.NeighborEastDropBox.Location = new System.Drawing.Point(196, 79);
            this.NeighborEastDropBox.Margin = new System.Windows.Forms.Padding(1);
            this.NeighborEastDropBox.MaxDropDownItems = 100;
            this.NeighborEastDropBox.Name = "NeighborEastDropBox";
            this.NeighborEastDropBox.Size = new System.Drawing.Size(96, 21);
            this.NeighborEastDropBox.TabIndex = 9;
            // 
            // NeighborSouthLabel
            // 
            this.NeighborSouthLabel.AutoSize = true;
            this.NeighborSouthLabel.Location = new System.Drawing.Point(132, 124);
            this.NeighborSouthLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.NeighborSouthLabel.Name = "NeighborSouthLabel";
            this.NeighborSouthLabel.Size = new System.Drawing.Size(35, 13);
            this.NeighborSouthLabel.TabIndex = 4;
            this.NeighborSouthLabel.Text = "South";
            // 
            // NeighborWestLabel
            // 
            this.NeighborWestLabel.AutoSize = true;
            this.NeighborWestLabel.Location = new System.Drawing.Point(31, 65);
            this.NeighborWestLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.NeighborWestLabel.Name = "NeighborWestLabel";
            this.NeighborWestLabel.Size = new System.Drawing.Size(32, 13);
            this.NeighborWestLabel.TabIndex = 3;
            this.NeighborWestLabel.Text = "West";
            // 
            // NeighborEastLabel
            // 
            this.NeighborEastLabel.AutoSize = true;
            this.NeighborEastLabel.Location = new System.Drawing.Point(232, 65);
            this.NeighborEastLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.NeighborEastLabel.Name = "NeighborEastLabel";
            this.NeighborEastLabel.Size = new System.Drawing.Size(28, 13);
            this.NeighborEastLabel.TabIndex = 2;
            this.NeighborEastLabel.Text = "East";
            // 
            // NeighborNorthLabel
            // 
            this.NeighborNorthLabel.AutoSize = true;
            this.NeighborNorthLabel.Location = new System.Drawing.Point(132, 16);
            this.NeighborNorthLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.NeighborNorthLabel.Name = "NeighborNorthLabel";
            this.NeighborNorthLabel.Size = new System.Drawing.Size(33, 13);
            this.NeighborNorthLabel.TabIndex = 1;
            this.NeighborNorthLabel.Text = "North";
            // 
            // NeighborNorthDropBox
            // 
            this.NeighborNorthDropBox.Enabled = false;
            this.NeighborNorthDropBox.FormattingEnabled = true;
            this.NeighborNorthDropBox.Location = new System.Drawing.Point(100, 30);
            this.NeighborNorthDropBox.Margin = new System.Windows.Forms.Padding(1);
            this.NeighborNorthDropBox.MaxDropDownItems = 100;
            this.NeighborNorthDropBox.Name = "NeighborNorthDropBox";
            this.NeighborNorthDropBox.Size = new System.Drawing.Size(96, 21);
            this.NeighborNorthDropBox.TabIndex = 8;
            // 
            // StartingLocationDropBox
            // 
            this.StartingLocationDropBox.Enabled = false;
            this.StartingLocationDropBox.FormattingEnabled = true;
            this.StartingLocationDropBox.Location = new System.Drawing.Point(6, 25);
            this.StartingLocationDropBox.MaxDropDownItems = 100;
            this.StartingLocationDropBox.Name = "StartingLocationDropBox";
            this.StartingLocationDropBox.Size = new System.Drawing.Size(204, 21);
            this.StartingLocationDropBox.TabIndex = 1;
            this.StartingLocationDropBox.TextChanged += new System.EventHandler(this.StartingLocationDropBox_Changed);
            // 
            // StartingLocationLabel
            // 
            this.StartingLocationLabel.AutoSize = true;
            this.StartingLocationLabel.Location = new System.Drawing.Point(4, 8);
            this.StartingLocationLabel.Name = "StartingLocationLabel";
            this.StartingLocationLabel.Size = new System.Drawing.Size(87, 13);
            this.StartingLocationLabel.TabIndex = 0;
            this.StartingLocationLabel.Text = "Starting Location";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.WorldTab);
            this.TabControl.Controls.Add(this.GameTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(546, 373);
            this.TabControl.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "json";
            this.openFileDialog.Filter = "Json files|*.json|All files|*.*";
            this.openFileDialog.FilterIndex = 2;
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Browse Game Files";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "json";
            this.saveFileDialog.Filter = "Json files|*.json|All files|*.*";
            this.saveFileDialog.FilterIndex = 2;
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.Title = "Save Game File As";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 373);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(562, 433);
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(562, 433);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zork Builder";
            this.WelcomeMessageContainer.ResumeLayout(false);
            this.WelcomeMessageContainer.PerformLayout();
            this.GameTab.ResumeLayout(false);
            this.WorldTab.ResumeLayout(false);
            this.WorldTab.PerformLayout();
            this.LocationsGroupBox.ResumeLayout(false);
            this.NeighborsGroupBox.ResumeLayout(false);
            this.NeighborsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultBindingSource)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.OpenFileDialog GetFileDialog
        {
            get => openFileDialog;
        }


        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem MenuFile;
        private System.Windows.Forms.MenuItem MenuFileNewOption;
        private System.Windows.Forms.MenuItem MenuFileOpenOption;
        private System.Windows.Forms.MenuItem MenuFileDivider;
        private System.Windows.Forms.MenuItem MenuFileSaveOption;
        private System.Windows.Forms.MenuItem MenuFileSaveAsOption;
        private System.Windows.Forms.TabPage GameTab;
        private System.Windows.Forms.TextBox WelcomeMessageTextBox;
        private System.Windows.Forms.TabPage WorldTab;
        private System.Windows.Forms.TextBox LocationDescriptionTextBox;
        private System.Windows.Forms.TextBox LocationNameTextBox;
        private System.Windows.Forms.Label LocationDescriptionLabel;
        private System.Windows.Forms.Label LocationNameLabel;
        private System.Windows.Forms.Button LocationRemoveButton;
        private System.Windows.Forms.Button LocationAddButton;
        private System.Windows.Forms.GroupBox NeighborsGroupBox;
        private System.Windows.Forms.ComboBox NeighborSouthDropBox;
        private System.Windows.Forms.ComboBox NeighborWestDropBox;
        private System.Windows.Forms.ComboBox NeighborEastDropBox;
        private System.Windows.Forms.Label NeighborSouthLabel;
        private System.Windows.Forms.Label NeighborWestLabel;
        private System.Windows.Forms.Label NeighborEastLabel;
        private System.Windows.Forms.Label NeighborNorthLabel;
        private System.Windows.Forms.ListBox LocationsListBox;
        private System.Windows.Forms.ComboBox StartingLocationDropBox;
        private System.Windows.Forms.Label StartingLocationLabel;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.GroupBox LocationsGroupBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.BindingSource defaultBindingSource;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button LocationUpdateButton;
        private System.Windows.Forms.ComboBox NeighborNorthDropBox;
        private System.Windows.Forms.Button MessageCancelButton;
        private System.Windows.Forms.Button MessageConfirmButton;
        private System.Windows.Forms.GroupBox WelcomeMessageContainer;
    }
}

