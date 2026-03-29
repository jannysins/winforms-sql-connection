using System.Drawing.Text;
using System.Xml.Linq;
using TestWins.Controller;
using TestWins.Model;

namespace TestWins;

public partial class Form1 : Form
{
    //business

    private readonly StudentController controller = new StudentController();

    public Form1()
    {
        InitializeComponent();
        loadData();
    }

    private void loadData()
    {
        dataGridView1.DataSource = controller.getAll();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var student = new Student
        {
            Id = int.Parse(txtId.Text),
            Name = txtName.Text,
            Course = txtCourse.Text,
            Year = int.Parse(txtYear.Text)
        };

        controller.create(student);
        loadData();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        var student = new Student
        {
            Id = int.Parse(txtId.Text),
            Name = txtName.Text,
            Course = txtCourse.Text,
            Year = int.Parse(txtYear.Text)
        };

        controller.update(student);
        loadData();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse(txtId.Text);



        controller.delete(id);
        loadData();
    }

    private void dataGridView1_CellClick(object sender, EventArgs e)
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            txtId.Text = row.Cells["Id"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtCourse.Text = row.Cells["Course"].Value.ToString();
            txtYear.Text = row.Cells["Year"].Value.ToString();
        }
    }
}
