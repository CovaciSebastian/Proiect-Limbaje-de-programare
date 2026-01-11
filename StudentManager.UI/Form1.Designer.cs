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
    private Button btnEdit; // Buton nou
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

        // 
        // Search Controls
        // 
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(320, 20);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(50, 15);
        lblSearch.TabIndex = 5;
        lblSearch.Text = "Cauta:";

        txtSearch.Location = new Point(370, 17);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(300, 23);
        txtSearch.TabIndex = 6;
        txtSearch.PlaceholderText = "Nume, Prenume sau Grupa...";

        // 
        // dgvStudents
        // 
        dgvStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvStudents.Location = new Point(320, 50);
        dgvStudents.Name = "dgvStudents";
        dgvStudents.ReadOnly = true;
        dgvStudents.RowTemplate.Height = 25;
        dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvStudents.Size = new Size(650, 440);
        dgvStudents.TabIndex = 0;

        // 
        // grpStudentInfo
        // 
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
        grpStudentInfo.Size = new Size(290, 350);
        grpStudentInfo.TabIndex = 1;
        grpStudentInfo.TabStop = false;
        grpStudentInfo.Text = "Informatii Student";

        // Fields setup
        int startY = 30;
        int spacing = 50;

        SetupControl(lblFirstName, "Prenume:", 15, startY);
        SetupControl(txtFirstName, "", 15, startY + 20, 250);

        SetupControl(lblLastName, "Nume:", 15, startY + spacing);
        SetupControl(txtLastName, "", 15, startY + spacing + 20, 250);

        SetupControl(lblGroup, "Grupa:", 15, startY + spacing * 2);
        SetupControl(txtGroup, "", 15, startY + spacing * 2 + 20, 250);

        SetupControl(lblEmail, "Email:", 15, startY + spacing * 3);
        SetupControl(txtEmail, "", 15, startY + spacing * 3 + 20, 250);

        SetupControl(lblBirthDate, "Data Nasterii:", 15, startY + spacing * 4);
        dtpBirthDate.Location = new Point(15, startY + spacing * 4 + 20);
        dtpBirthDate.Size = new Size(250, 23);

        SetupControl(lblGrades, "Note (separate prin virgula):", 15, startY + spacing * 5);
        SetupControl(txtGrades, "", 15, startY + spacing * 5 + 20, 250);

        // Buttons
        // Buton Adauga
        btnAdd.Location = new Point(12, 370);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(140, 35);
        btnAdd.TabIndex = 2;
        btnAdd.Text = "Adauga Student";
        btnAdd.UseVisualStyleBackColor = true;

        // Buton Modifica (Nou)
        btnEdit.Location = new Point(162, 370);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(140, 35);
        btnEdit.TabIndex = 3;
        btnEdit.Text = "Modifica";
        btnEdit.UseVisualStyleBackColor = true;

        // Buton Sterge
        btnDelete.Location = new Point(12, 415);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(290, 35);
        btnDelete.TabIndex = 4;
        btnDelete.Text = "Sterge Selectie";
        btnDelete.UseVisualStyleBackColor = true;

        // Buton Export
        btnExport.Location = new Point(12, 460);
        btnExport.Name = "btnExport";
        btnExport.Size = new Size(290, 35);
        btnExport.TabIndex = 5;
        btnExport.Text = "Exporta CSV (Raport)";
        btnExport.UseVisualStyleBackColor = true;

        // Form1
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