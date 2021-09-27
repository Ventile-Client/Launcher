using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VentileClient.Forms
{
    public partial class FlowLayout : Form
    {
        public FlowLayout()
        {
            InitializeComponent();

            
        }

        void NewCategory(string name, List<Drop2Thing> dropdowns)
        {
            var label = new Label
            {
                Text = name
            };
            flowLayoutPanel1.Controls.Add(label);
            foreach (Drop2Thing dropDown in dropdowns)
            {
                NewDropdown(name, dropDown);
            }
        }

        void NewDropdown(string catName, Drop2Thing dropdown)
        {
            dropdown.CategoryName = catName;
            var panel = new Panel
            {
                MaximumSize = new Size(100, TextRenderer.MeasureText(dropdown.DropdownText, new Font("Segoe UI", 8.25f)).Height),
                MinimumSize = new Size(100, 0),
                Size = MinimumSize
            };
            dropdown.DropdownPanel = panel;
            panel.Tag = dropdown;

            var textLbl = new Label
            {
                Text = dropdown.DropdownText,
                AutoSize = true
            };
            panel.Controls.Add(textLbl);

            var button = new Button
            {
                Text = dropdown.Name,
                Tag = dropdown
            };
            button.Click += Btn_Click;
            flowLayoutPanel1.Controls.Add(button);
            flowLayoutPanel1.Controls.Add(panel);
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            var dropdownData = ((Drop2Thing)((((Button)sender)).Tag));
            if (dropdownData.MenuOpen)
                dropdownData.DropdownPanel.Height = dropdownData.DropdownPanel.MinimumSize.Height;
            else
                dropdownData.DropdownPanel.Height = dropdownData.DropdownPanel.MaximumSize.Height;

            dropdownData.MenuOpen = !dropdownData.MenuOpen;
        }
    }

    class Drop2Thing
    {
        public string CategoryName;
        public string Name;
        public string DropdownText;
        public Panel DropdownPanel;
        public bool MenuOpen = false;
    }
}
