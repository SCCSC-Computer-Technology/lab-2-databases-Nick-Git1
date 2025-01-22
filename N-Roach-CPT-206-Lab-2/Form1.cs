using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_Roach_CPT_206_Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.populationDBDataSet1);

        }

        private void tableBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.populationDBDataSet1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'populationDBDataSet1.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.populationDBDataSet1.Table);

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate(); // Validate input
                this.tableBindingSource.EndEdit(); // End editing
                this.tableTableAdapter.Update(this.populationDBDataSet1.Table); // Save db changes
                MessageBox.Show("All changes saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message);
            }
        }

        private void sortPopulationAscBtn_Click(object sender, EventArgs e)
        {
            tableBindingSource.Sort = "Population ASC";
        }

        private void sortPopulationDescBtn_Click(object sender, EventArgs e)
        {
            tableBindingSource.Sort = "Population DESC";
        }

        private void sortCityNameBtn_Click(object sender, EventArgs e)
        {
            tableBindingSource.Sort = "City ASC";
        }

        private void calcTotalPopulationBtn_Click(object sender, EventArgs e)
        {
            if (populationDBDataSet1.Table.Rows.Count == 0) // Error handling if database contains no data
            {
                MessageBox.Show("No data to calculate average.");
                return;
            }
            // Validate population values and add them up
            double total = populationDBDataSet1.Table.AsEnumerable().Where(row => row["Population"] != DBNull.Value && double.TryParse(row["Population"].ToString(), out _)).Sum(row => Convert.ToDouble(row["Population"]));
            MessageBox.Show("Total population: " + total);
        }

        private void calcAveragePopulationBtn_Click(object sender, EventArgs e)
        {
            if (populationDBDataSet1.Table.Rows.Count == 0)
            {
                MessageBox.Show("No data to calculate average.");
                return;
            }
            // Validate population values and calculate average
            double average = populationDBDataSet1.Table.AsEnumerable().Where(row => row["Population"] != DBNull.Value && double.TryParse(row["Population"].ToString(), out _)).Average(row => Convert.ToDouble(row["Population"]));
            MessageBox.Show("Average population: " + average);
        }

        private void minMaxPopulationBtn_Click(object sender, EventArgs e)
        {
            {
                if (populationDBDataSet1.Table.Rows.Count == 0)
                {
                    MessageBox.Show("No data to calculate average.");
                    return;
                }
                // Validate population values and find min and max
                var validPopulations = populationDBDataSet1.Table.AsEnumerable().Where(row => row["Population"] != DBNull.Value && double.TryParse(row["Population"].ToString(), out _)).Select(row => Convert.ToDouble(row["Population"]));
                double minPopulation = validPopulations.Min();
                double maxPopulation = validPopulations.Max();
                MessageBox.Show($"Min population: {minPopulation}\nMax population: {maxPopulation}");
            }
            }
    }
}
