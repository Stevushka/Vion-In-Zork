using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Vion_Builder
{
    public partial class MainForm : Form
    {
        public Root StoredRoot = null;
        public string CurrentFile = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void New_File(object sender, EventArgs e)
        {
            //Create a new world in the form, but don't save or write it
            StoredRoot = null;
            CurrentFile = "";

            StoredRoot = new Root()
            {
                World = new World()
                {
                    StartingLocation = null,
                    WelcomeMessage = "Welcome to Zork!",
                    Locations = new List<Location>(),
                },
            };

            StoredRoot.World.Locations.Add(new Location()
            {
                Name = "Default Location",
                Description = "Default Location Description",
                Neighbors = new Neighbors()
                {
                    North = null,
                    South = null,
                    West = null,
                    East = null,
                },
            });

            ResetWorldLists();

            StartingLocationDropBox.Text = StoredRoot.World.StartingLocation = StoredRoot.World.Locations[0].Name;

            WelcomeMessageTextBox.Text = StoredRoot.World.WelcomeMessage;

            //Clear the Form
            ClearLocationForm();

            EnableSaveFileOptionsAndLocationButtons();
        }

        private void Open_File(object sender, EventArgs e)
        {
            //Open file dialog with settings
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Game Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "json",
                Filter = "Json files (*.json)|*.json",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get selected file and store it
                CurrentFile = openFileDialog.FileName;

                //Get the whole world from the file
                StoredRoot = JsonConvert.DeserializeObject<Root>(File.ReadAllText(@CurrentFile));
            }

            ResetWorldLists();

            StartingLocationDropBox.Text = StoredRoot.World.StartingLocation;

            WelcomeMessageTextBox.Text = StoredRoot.World.WelcomeMessage;

            //Clear the Form
            ClearLocationForm();

            EnableSaveFileOptionsAndLocationButtons();
        }

        private void Save_File(object sender, EventArgs e)
        {
            if (CurrentFile == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Json files|*.json|All files|*.*",
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CurrentFile = saveFileDialog.FileName;
                }
            }

            //convert to json
            string json = JsonConvert.SerializeObject(StoredRoot, Formatting.Indented);

            //write json to the current file
            File.WriteAllText(CurrentFile, json);

            MessageBox.Show(CurrentFile + " is saved");
        }

        private void Save_As_File(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Json files|*.json|All files|*.*",
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentFile = saveFileDialog.FileName;

                MessageBox.Show(CurrentFile + " is saved");

                //convert to json
                string json = JsonConvert.SerializeObject(StoredRoot, Formatting.Indented);

                //write json to the current file
                File.WriteAllText(CurrentFile, json);
            }
        }

        private void StartingLocationDropBox_Changed(object sender, EventArgs e)
        {
            StoredRoot.World.StartingLocation = StartingLocationDropBox.Text;
        }

        private void LocationsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Name and Description
                LocationNameTextBox.Text = (LocationsListBox.SelectedItem as Location).Name;
                LocationDescriptionTextBox.Text = (LocationsListBox.SelectedItem as Location).Description;

                UpdateNeighborDropDownBoxes((LocationsListBox.SelectedItem as Location).Neighbors.North,
                                            (LocationsListBox.SelectedItem as Location).Neighbors.South,
                                            (LocationsListBox.SelectedItem as Location).Neighbors.West,
                                            (LocationsListBox.SelectedItem as Location).Neighbors.East);
            }

            catch { }
        }

        private void LocationUpdateButton_Click(object sender, EventArgs e)
        {
            if (LocationsListBox.SelectedItem != null)
            {
                try
                {
                    int index = LocationsListBox.SelectedIndex;

                    string oldName = StoredRoot.World.Locations[index].Name;

                    StoredRoot.World.Locations[index].Name = LocationNameTextBox.Text;
                    StoredRoot.World.Locations[index].Description = LocationDescriptionTextBox.Text;

                    StoredRoot.World.Locations[index].Neighbors.North = NeighborNorthDropBox.Text;
                    StoredRoot.World.Locations[index].Neighbors.South = NeighborSouthDropBox.Text;
                    StoredRoot.World.Locations[index].Neighbors.West = NeighborWestDropBox.Text;
                    StoredRoot.World.Locations[index].Neighbors.East = NeighborEastDropBox.Text;

                    LocationsListBox.Items.RemoveAt(index);
                    LocationsListBox.Items.Insert(index, StoredRoot.World.Locations[index]);

                    StartingLocationDropBox.Items.RemoveAt(index);
                    StartingLocationDropBox.Items.Insert(index, StoredRoot.World.Locations[index]);
                    StartingLocationDropBox.Text = StoredRoot.World.StartingLocation;

                    UpdateNeighborsByName(oldName, StoredRoot.World.Locations[index].Name);

                    ClearLocationForm();
                }

                catch { }
            }
        }

        private void LocationAddButton_Click(object sender, EventArgs e)
        {
            StoredRoot.World.Locations.Add(new Location()
            {
                Name = "New Location",
                Description = "New Location Description",
                Neighbors = new Neighbors()
                {
                    North = null,
                    South = null,
                    West = null,
                    East = null,
                },
            });

            LocationsListBox.Items.Add(StoredRoot.World.Locations[StoredRoot.World.Locations.Count - 1]);
            StartingLocationDropBox.Items.Add(StoredRoot.World.Locations[StoredRoot.World.Locations.Count - 1]);
        }

        private void LocationRemoveButton_Click(object sender, EventArgs e)
        {
            if (LocationsListBox.SelectedItem != null)
            {
                try
                {
                    int index = LocationsListBox.SelectedIndex;

                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this location?", "Remove Location", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //Find and remove all links to current location
                        PurgeNeighborsByName((LocationsListBox.SelectedItem as Location).Name);

                        //Clear the Form
                        ClearLocationForm();

                        //Update Lists
                        StoredRoot.World.Locations.RemoveAt(index);
                        LocationsListBox.Items.RemoveAt(index);
                        StartingLocationDropBox.Items.RemoveAt(index);
                        MessageBox.Show("Location Removed!");
                    }

                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Location Unchanged!");
                    }
                }

                catch
                {
                    MessageBox.Show("No location selected!");
                }
            }
        }

        private List<Location> GetLocationsList()
        {
            return StoredRoot.World.Locations;
        }

        private void PurgeNeighborsByName(string name)
        {
            if (StartingLocationDropBox.Text == name)
            {
                StoredRoot.World.StartingLocation = null;
                StartingLocationDropBox.Text = null;
            }

            foreach (Location location in GetLocationsList())
            {
                if (location.Neighbors.North == name)
                    location.Neighbors.North = null;

                if (location.Neighbors.South == name)
                    location.Neighbors.South = null;

                if (location.Neighbors.West == name)
                    location.Neighbors.West = null;

                if (location.Neighbors.East == name)
                    location.Neighbors.East = null;
            }
        }

        private void UpdateNeighborsByName(string oldName, string newName)
        {
            if (oldName != newName)
            {
                if (StartingLocationDropBox.Text == oldName)
                {
                    StoredRoot.World.StartingLocation = newName;
                    StartingLocationDropBox.Text = newName;
                }

                foreach (Location location in GetLocationsList())
                {
                    if (location.Neighbors.North == oldName)
                        location.Neighbors.North = newName;

                    if (location.Neighbors.South == oldName)
                        location.Neighbors.South = newName;

                    if (location.Neighbors.West == oldName)
                        location.Neighbors.West = newName;

                    if (location.Neighbors.East == oldName)
                        location.Neighbors.East = newName;
                }
            }
        }

        private void ResetWorldLists()
        {
            LocationsListBox.Items.Clear();
            StartingLocationDropBox.Items.Clear();

            foreach (Location location in GetLocationsList())
            {
                LocationsListBox.Items.Add(location);
                StartingLocationDropBox.Items.Add(location);
            }

            LocationsListBox.DisplayMember = "Name";
            StartingLocationDropBox.DisplayMember = "Name";
        }

        private void ClearLocationForm()
        {
            //Clear Location Text
            LocationNameTextBox.Text = null;
            LocationDescriptionTextBox.Text = null;

            //Clear North Neighbor DropBox
            NeighborNorthDropBox.Text = null;
            NeighborNorthDropBox.Items.Clear();

            //Clear South Neighbor DropBox
            NeighborSouthDropBox.Text = null;
            NeighborSouthDropBox.Items.Clear();

            //Clear West Neighbor DropBox
            NeighborWestDropBox.Text = null;
            NeighborWestDropBox.Items.Clear();

            //Clear East Neighbor DropBox
            NeighborEastDropBox.Text = null;
            NeighborEastDropBox.Items.Clear();
        }

        private void UpdateNeighborDropDownBoxes(string north, string south, string west, string east)
        {
            //North Neighbor
            NeighborNorthDropBox.Items.Clear();
            NeighborNorthDropBox.Text = (LocationsListBox.SelectedItem as Location).Neighbors.North;
            foreach (Location room in GetLocationsList())
            {
                if (room.Name != (LocationsListBox.SelectedItem as Location).Name && room.Name != north && room.Name != south && room.Name != west && room.Name != east)
                    NeighborNorthDropBox.Items.Add(room);
            }
            NeighborNorthDropBox.DisplayMember = "Name";

            //South Neighbor
            NeighborSouthDropBox.Items.Clear();
            NeighborSouthDropBox.Text = (LocationsListBox.SelectedItem as Location).Neighbors.South;
            foreach (Location room in GetLocationsList())
            {
                if (room.Name != (LocationsListBox.SelectedItem as Location).Name && room.Name != north && room.Name != south && room.Name != west && room.Name != east)
                    NeighborSouthDropBox.Items.Add(room);
            }
            NeighborSouthDropBox.DisplayMember = "Name";

            //West Neighbor
            NeighborWestDropBox.Items.Clear();
            NeighborWestDropBox.Text = (LocationsListBox.SelectedItem as Location).Neighbors.West;
            foreach (Location room in GetLocationsList())
            {
                if (room.Name != (LocationsListBox.SelectedItem as Location).Name && room.Name != north && room.Name != south && room.Name != west && room.Name != east)
                    NeighborWestDropBox.Items.Add(room);
            }
            NeighborWestDropBox.DisplayMember = "Name";

            //East Neighbor
            NeighborEastDropBox.Items.Clear();
            NeighborEastDropBox.Text = (LocationsListBox.SelectedItem as Location).Neighbors.East;
            foreach (Location room in GetLocationsList())
            {
                if (room.Name != (LocationsListBox.SelectedItem as Location).Name && room.Name != north && room.Name != south && room.Name != west && room.Name != east)
                    NeighborEastDropBox.Items.Add(room);
            }
            NeighborEastDropBox.DisplayMember = "Name";
        }

        private void EnableSaveFileOptionsAndLocationButtons()
        {
            MenuFileSaveOption.Enabled = true;
            MenuFileSaveAsOption.Enabled = true;

            LocationAddButton.Enabled = true;
            LocationRemoveButton.Enabled = true;
            LocationUpdateButton.Enabled = true;

            StartingLocationDropBox.Enabled = true;
            LocationNameTextBox.Enabled = true;
            LocationDescriptionTextBox.Enabled = true;

            NeighborNorthDropBox.Enabled = true;
            NeighborWestDropBox.Enabled = true;
            NeighborSouthDropBox.Enabled = true;
            NeighborEastDropBox.Enabled = true;

            MessageConfirmButton.Enabled = true;
            MessageCancelButton.Enabled = true;
            WelcomeMessageTextBox.Enabled = true;
        }

        private void MessageConfirmButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(WelcomeMessageTextBox.Text) && WelcomeMessageTextBox.Text.Length > 0)
            {
                MessageBox.Show("The new welcome message has been saved!");
                StoredRoot.World.WelcomeMessage = WelcomeMessageTextBox.Text;
            }

            else if (string.IsNullOrWhiteSpace(WelcomeMessageTextBox.Text))
            {
                MessageBox.Show("The welcome message cannot be empty or contain only spaces!");
            }
        }

        private void MessageCancelButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You cancelled entering in a new welcome message!");
            WelcomeMessageTextBox.Text = StoredRoot.World.WelcomeMessage;
        }
    }
}
