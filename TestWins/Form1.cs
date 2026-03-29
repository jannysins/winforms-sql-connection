using System.Drawing.Text;
using TestWins.Controller;
using TestWins.Model;

namespace TestWins;

public partial class Form1 : Form
{
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

    private void ClearFields()
    {
        txtStudentId.Clear();
        txtName.Clear();
        txtAge.Clear();
        txtCourse.Clear();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            var student = new Student
            {
                studentId = txtStudentId.Text,
                Name = txtName.Text,
                age = int.Parse(txtAge.Text),
                course = txtCourse.Text
            };

            controller.createStudent(student);
            MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            loadData();
            ClearFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Please select a student to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = new Student
            {
                studentId = txtStudentId.Text,
                Name = txtName.Text,
                age = int.Parse(txtAge.Text),
                course = txtCourse.Text
            };

            controller.update(student);
            MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            loadData();
            ClearFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Please select a student to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                controller.delete(txtStudentId.Text);
                MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                loadData();
                ClearFields();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dataGridView1_CellClick(object sender, EventArgs e)
    {
        // Ensure the user clicked a valid row (not the headers)
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            
            txtStudentId.Text = row.Cells["studentId"].Value?.ToString();
            txtName.Text = row.Cells["Name"].Value?.ToString();
            txtAge.Text = row.Cells["age"].Value?.ToString();
            txtCourse.Text = row.Cells["course"].Value?.ToString();
        }
    }
}
