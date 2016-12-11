using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasCalc
{
    public partial class LookupVehicle : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GasCalc;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public LookupVehicle()
        {
            InitializeComponent();
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            // Reload the data from the database.
            GetData(dataAdapter.SelectCommand.CommandText);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            // Update the database with the user's changes.
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }

        private void GetData(string selectCommand)
        {
            try
            {
                dataAdapter = new SqlDataAdapter(selectCommand, ConnectionString);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;
               
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException)
            {
                MessageBox.Show("Unable to retrieve from the database.");
            }
        }

        private void LookupVehicle_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            GetData("SELECT VehicleNo, Model, LicensePlate, FuelType, FuelRemainder FROM Vehicle");
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex + "<");         
            Close();
        }
    }
}
