namespace StudentManager.UI;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvStudents;
    private TextBox txtFirstName;
    private TextBox txtLastName;
    private TextBox txtGroup;
    private TextBox txtGrades;
    private TextBox txtEmail;
    private DateTimePicker dtpBirthDate;
    
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnExport;
    
    private Label lblFirstName;
    private Label lblLastName;
    private Label lblGroup;
    private Label lblGrades;
    private Label lblEmail;
    private Label lblBirthDate;
    private GroupBox grpStudentInfo;
    
    private Label lblSearch;
    private TextBox txtSearch;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dgvStudents = new DataGridView();
        grpStudentInfo = new GroupBox();
        lblFirstName = new Label();
        txtFirstName = new TextBox();
        lblLastName = new Label();
        txtLastName = new TextBox();
        lblGroup = new Label();
        txtGroup = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblBirthDate = new Label();
        dtpBirthDate = new DateTimePicker();
        lblGrades = new Label();
        txtGrades = new TextBox();
        
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        btnExport = new Button();
        
        lblSearch = new Label();
        txtSearch = new TextBox();

        ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
        grpStudentInfo.SuspendLayout();
        SuspendLayout();

        int leftPanelWidth = 330;
        int gridX = leftPanelWidth + 20;
        
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(gridX, 20);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(50, 15);
        lblSearch.Text = "Cauta:";

        txtSearch.Location = new Point(gridX + 50, 17);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(300, 23);
        txtSearch.PlaceholderText = "Nume, Prenume sau Grupa...";

        dgvStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvStudents.Location = new Point(gridX, 50);
        dgvStudents.Name = "dgvStudents";
        dgvStudents.ReadOnly = true;
        dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvStudents.Size = new Size(620, 440);

        grpStudentInfo.Controls.Add(lblFirstName);
        grpStudentInfo.Controls.Add(txtFirstName);
        grpStudentInfo.Controls.Add(lblLastName);
        grpStudentInfo.Controls.Add(txtLastName);
        grpStudentInfo.Controls.Add(lblGroup);
        grpStudentInfo.Controls.Add(txtGroup);
        grpStudentInfo.Controls.Add(lblEmail);
        grpStudentInfo.Controls.Add(txtEmail);
        grpStudentInfo.Controls.Add(lblBirthDate);
        grpStudentInfo.Controls.Add(dtpBirthDate);
        grpStudentInfo.Controls.Add(lblGrades);
        grpStudentInfo.Controls.Add(txtGrades);
        grpStudentInfo.Location = new Point(12, 12);
        grpStudentInfo.Name = "grpStudentInfo";
        grpStudentInfo.Size = new Size(leftPanelWidth, 350);
        grpStudentInfo.Text = "Informatii Student";

        int startY = 40;
        int spacing = 40;
        int labelX = 10;
        int labelWidth = 90; // Latime fixa pentru etichete (mai ingusta)
        int inputX = 110;    // Casuta incepe dupa eticheta
        int inputWidth = 200;

        // Dezactivam AutoSize pentru a forta latimea
        lblFirstName.AutoSize = false;
        lblLastName.AutoSize = false;
        lblGroup.AutoSize = false;
        lblEmail.AutoSize = false;
        lblBirthDate.AutoSize = false;
        lblGrades.AutoSize = false;

        SetupControl(lblFirstName, "Prenume:", labelX, startY + 3, labelWidth);
        SetupControl(txtFirstName, "", inputX, startY, inputWidth);

        SetupControl(lblLastName, "Nume:", labelX, startY + spacing + 3, labelWidth);
        SetupControl(txtLastName, "", inputX, startY + spacing, inputWidth);

        SetupControl(lblGroup, "Grupa:", labelX, startY + spacing * 2 + 3, labelWidth);
        SetupControl(txtGroup, "", inputX, startY + spacing * 2, inputWidth);

        SetupControl(lblEmail, "Email:", labelX, startY + spacing * 3 + 3, labelWidth);
        SetupControl(txtEmail, "", inputX, startY + spacing * 3, inputWidth);

        SetupControl(lblBirthDate, "Data Nasterii:", labelX, startY + spacing * 4 + 3, labelWidth);
        dtpBirthDate.Location = new Point(inputX, startY + spacing * 4);
        dtpBirthDate.Size = new Size(inputWidth, 23);

        SetupControl(lblGrades, "Note:", labelX, startY + spacing * 5 + 3, labelWidth);
        SetupControl(txtGrades, "", inputX, startY + spacing * 5, inputWidth);
        txtGrades.PlaceholderText = "ex: 10, 8.5, 9";

        int btnWidth = (leftPanelWidth - 30) / 2;
        
        btnAdd.Location = new Point(12, 370);
        btnAdd.Size = new Size(btnWidth, 35);
        btnAdd.Text = "Adauga";

        btnEdit.Location = new Point(12 + btnWidth + 6, 370);
        btnEdit.Size = new Size(btnWidth, 35);
        btnEdit.Text = "Modifica";

        btnDelete.Location = new Point(12, 415);
        btnDelete.Size = new Size(leftPanelWidth, 35);
        btnDelete.Text = "Sterge Selectie";

        btnExport.Location = new Point(12, 460);
        btnExport.Size = new Size(leftPanelWidth, 35);
        btnExport.Text = "Exporta CSV (Raport)";

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(984, 511);
        Controls.Add(lblSearch);
        Controls.Add(txtSearch);
        Controls.Add(btnExport);
        Controls.Add(btnDelete);
        Controls.Add(btnEdit);
        Controls.Add(btnAdd);
        Controls.Add(grpStudentInfo);
        Controls.Add(dgvStudents);
        Name = "Form1";
        Text = "Student Grade Manager - v1.0";
        ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
        grpStudentInfo.ResumeLayout(false);
        grpStudentInfo.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private void SetupControl(Control ctrl, string text, int x, int y, int width = 0)
    {
        ctrl.Text = text;
        ctrl.Location = new Point(x, y);
        if (width > 0) ctrl.Width = width;
    }
}
