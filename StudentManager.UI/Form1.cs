using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManager.Core.Models;
using StudentManager.Core.Services;

namespace StudentManager.UI;

public partial class Form1 : Form
{
    private readonly StudentService _studentService;
    private Guid? _editingId = null; // ID-ul studentului in curs de editare

    public Form1()
    {
        InitializeComponent();
        _studentService = new StudentService();
        
        // Configuram butoanele
        btnAdd.Click += btnAdd_Click;
        btnEdit.Click += btnEdit_Click;
        btnDelete.Click += btnDelete_Click;
        btnExport.Click += btnExport_Click;
        
        // Configuram cautarea
        txtSearch.TextChanged += txtSearch_TextChanged;

        RefreshGrid();
    }

    private void RefreshGrid()
    {
        string searchQuery = txtSearch.Text;
        dgvStudents.DataSource = null;
        dgvStudents.DataSource = _studentService.Search(searchQuery).ToList();
        
        if (dgvStudents.Columns["Id"] != null)
            dgvStudents.Columns["Id"]!.Visible = false;
        
        if (dgvStudents.Columns["FirstName"] != null) dgvStudents.Columns["FirstName"]!.HeaderText = "Prenume";
        if (dgvStudents.Columns["LastName"] != null) dgvStudents.Columns["LastName"]!.HeaderText = "Nume";
        if (dgvStudents.Columns["Group"] != null) dgvStudents.Columns["Group"]!.HeaderText = "Grupa";
        if (dgvStudents.Columns["AverageGrade"] != null) dgvStudents.Columns["AverageGrade"]!.HeaderText = "Media";
        if (dgvStudents.Columns["BirthDate"] != null) dgvStudents.Columns["BirthDate"]!.HeaderText = "Data Nasterii";
    }

    private void txtSearch_TextChanged(object? sender, EventArgs e)
    {
        RefreshGrid();
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Numele si prenumele sunt obligatorii!", "Validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var grades = txtGrades.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(s => double.TryParse(s.Trim(), out var val) ? val : -1.0)
                                      .ToList();

            if (grades.Any(g => g < 1 || g > 10))
            {
                MessageBox.Show("Notele trebuie sa fie intre 1 si 10!", "Validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = new Student
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Group = txtGroup.Text,
                Email = txtEmail.Text,
                BirthDate = dtpBirthDate.Value,
                Grades = grades
            };

            if (_editingId.HasValue)
            {
                // Mod Update
                student.Id = _editingId.Value;
                _studentService.Update(student);
                MessageBox.Show("Student modificat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Mod Adaugare
                _studentService.Add(student);
                MessageBox.Show("Student adaugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ClearFields();
            RefreshGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnEdit_Click(object? sender, EventArgs e)
    {
        if (dgvStudents.SelectedRows.Count > 0 && dgvStudents.SelectedRows[0].DataBoundItem is Student student)
        {
            // Populam campurile
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtGroup.Text = student.Group;
            txtEmail.Text = student.Email;
            dtpBirthDate.Value = student.BirthDate;
            txtGrades.Text = string.Join(", ", student.Grades);

            // Setam ID-ul pentru editare
            _editingId = student.Id;

            // Schimbam interfata pentru a indica modul de editare
            btnAdd.Text = "Salveaza";
            btnDelete.Enabled = false;
            grpStudentInfo.Text = $"Modificare: {student.FullName}";
        }
        else
        {
            MessageBox.Show("Selectati un student pentru a-l modifica.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        if (dgvStudents.SelectedRows.Count > 0 && dgvStudents.SelectedRows[0].DataBoundItem is Student student)
        {
            var result = MessageBox.Show($"Sigur doriti sa stergeti pe {student.FullName}?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                _studentService.Remove(student.Id);
                RefreshGrid();
                ClearFields(); // Curatam in caz ca stergeam ceva ce editam
            }
        }
        else
        {
            MessageBox.Show("Selectati un student din tabel pentru a-l sterge.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnExport_Click(object? sender, EventArgs e)
    {
        using SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = "CSV files (*.csv)|*.csv";
        sfd.FileName = "RaportStudenti.csv";

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _studentService.ExportToCsv(sfd.FileName);
                MessageBox.Show("Raportul a fost generat cu succes!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la export: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void ClearFields()
    {
        txtFirstName.Clear();
        txtLastName.Clear();
        txtGroup.Clear();
        txtEmail.Clear();
        txtGrades.Clear();
        dtpBirthDate.Value = DateTime.Now;

        // Resetam starea de editare
        _editingId = null;
        btnAdd.Text = "Adauga Student";
        btnDelete.Enabled = true;
        grpStudentInfo.Text = "Informatii Student";
    }
}