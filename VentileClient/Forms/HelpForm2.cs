using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using VentileClient.JSON_Template_Classes;

namespace VentileClient.Forms
{
    public partial class HelpForm2 : Form
    {
        public HelpForm2(ThemeTemplate themeCS, string[] tempHelpParam)
        {
            var helpParam = new List<string>(tempHelpParam);
            InitializeComponent();


            TopMost = true;
            this.BackColor = ColorTranslator.FromHtml(themeCS.Background);
            Title.ForeColor = ColorTranslator.FromHtml(themeCS.Foreground);
            Title.BackColor = ColorTranslator.FromHtml(themeCS.Background);
            HelpLog.ForeColor = ColorTranslator.FromHtml(themeCS.Faded);
            HelplogScrollPanel.BackColor = ColorTranslator.FromHtml(themeCS.SecondBackground);
            CoverUpSliderPanel.BackColor = ColorTranslator.FromHtml(themeCS.Background);

            var categories = new List<Category>();

            for (int i = 0; i < helpParam.Count; i++) //Loop through all lines in the file
            {
                if (helpParam[i].Trim().StartsWith("."))
                {
                    Debug.WriteLine("Created New Category");
                    var category = new Category() { CategoryName = helpParam[i].Trim().Remove(0, 1), Dropdowns = new List<DropDown>() };

                    i++;
                    for (int _; i < helpParam.Count; i++) //Loop through all lines in the file
                    {
                        if (helpParam[i].Trim().StartsWith("> "))
                        {
                            Debug.WriteLine("New Dropdown");
                            var dropdown = new DropDown() { Name = helpParam[i].Trim().Remove(0, 2), CategoryName = category.CategoryName };

                            i++;
                            for (int __; i < helpParam.Count; i++) //Loop through all lines in the file
                            {
                                if (helpParam[i].Trim().StartsWith("- "))
                                {
                                    dropdown.DropdownText += helpParam[i].Trim().Remove(0, 2) + "\n";
                                    Debug.WriteLine("Added Text to Dropdown");
                                } else
                                {
                                    break;
                                }
                            }
                            category.Dropdowns.Add(dropdown);
                            Debug.WriteLine("Added Dropdown to category");
                        }
                        if (helpParam[i].Trim().StartsWith("."))
                        {
                            categories.Add(category);
                            Debug.WriteLine("Added Category!");
                            break;
                        }
                    }
                }
            }
            foreach (Category category in categories)
            {
                NewCategory(category.CategoryName, category.Dropdowns);
            }
            foreach (Control a in HelpLog.Controls)
                Debug.WriteLine(a);

            this.Refresh();
        }
        void NewCategory(string name, List<DropDown> dropdowns)
        {
            var label = new Label
            {
                Text = name
            };
            HelpLog.Controls.Add(label);
            foreach (DropDown dropDown in dropdowns)
            {
                NewDropdown(name, dropDown);
            }
        }

        void NewDropdown(string catName, DropDown dropdown)
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
            HelpLog.Controls.Add(button);
            HelpLog.Controls.Add(panel);
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            var dropdownData = ((DropDown)((((Button)sender)).Tag));
            if (dropdownData.MenuOpen)
                dropdownData.DropdownPanel.Height = dropdownData.DropdownPanel.MinimumSize.Height;
            else
                dropdownData.DropdownPanel.Height = dropdownData.DropdownPanel.MaximumSize.Height;

            dropdownData.MenuOpen = !dropdownData.MenuOpen;
        }
    }

    class Category
    {
        public string CategoryName;
        public List<DropDown> Dropdowns;
    }

    class DropDown
    {
        public string CategoryName;
        public string Name;
        public string DropdownText;
        public Panel DropdownPanel;
        public bool MenuOpen = false;
    }
}