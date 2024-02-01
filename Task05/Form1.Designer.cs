namespace Task05
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnNew = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbName = new TextBox();
            tbSurname = new TextBox();
            tbGroup = new TextBox();
            tbNotes = new TextBox();
            lbErrorName = new Label();
            lbErrorSurname = new Label();
            lbErrorGroup = new Label();
            lbErrorNotes = new Label();
            lbPeople = new ListBox();
            SuspendLayout();
            // 
            // btnNew
            // 
            btnNew.Location = new Point(174, 415);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 0;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(93, 415);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(12, 415);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 20);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 44);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 4;
            label2.Text = "Surname:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 74);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 5;
            label3.Text = "Group:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 109);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 6;
            label4.Text = "Notes:";
            // 
            // tbName
            // 
            tbName.Location = new Point(93, 12);
            tbName.Name = "tbName";
            tbName.Size = new Size(284, 23);
            tbName.TabIndex = 8;
            // 
            // tbSurname
            // 
            tbSurname.Location = new Point(93, 41);
            tbSurname.Name = "tbSurname";
            tbSurname.Size = new Size(284, 23);
            tbSurname.TabIndex = 9;
            // 
            // tbGroup
            // 
            tbGroup.Location = new Point(93, 74);
            tbGroup.Name = "tbGroup";
            tbGroup.Size = new Size(284, 23);
            tbGroup.TabIndex = 10;
            // 
            // tbNotes
            // 
            tbNotes.Location = new Point(93, 109);
            tbNotes.Multiline = true;
            tbNotes.Name = "tbNotes";
            tbNotes.Size = new Size(284, 194);
            tbNotes.TabIndex = 11;
            // 
            // lbErrorName
            // 
            lbErrorName.AutoSize = true;
            lbErrorName.ForeColor = Color.Red;
            lbErrorName.Location = new Point(12, 20);
            lbErrorName.Name = "lbErrorName";
            lbErrorName.Size = new Size(14, 15);
            lbErrorName.TabIndex = 12;
            lbErrorName.Text = "X";
            // 
            // lbErrorSurname
            // 
            lbErrorSurname.AutoSize = true;
            lbErrorSurname.ForeColor = Color.Red;
            lbErrorSurname.Location = new Point(10, 44);
            lbErrorSurname.Name = "lbErrorSurname";
            lbErrorSurname.Size = new Size(14, 15);
            lbErrorSurname.TabIndex = 13;
            lbErrorSurname.Text = "X";
            // 
            // lbErrorGroup
            // 
            lbErrorGroup.AutoSize = true;
            lbErrorGroup.ForeColor = Color.Red;
            lbErrorGroup.Location = new Point(12, 74);
            lbErrorGroup.Name = "lbErrorGroup";
            lbErrorGroup.Size = new Size(14, 15);
            lbErrorGroup.TabIndex = 14;
            lbErrorGroup.Text = "X";
            // 
            // lbErrorNotes
            // 
            lbErrorNotes.AutoSize = true;
            lbErrorNotes.ForeColor = Color.Red;
            lbErrorNotes.Location = new Point(12, 109);
            lbErrorNotes.Name = "lbErrorNotes";
            lbErrorNotes.Size = new Size(14, 15);
            lbErrorNotes.TabIndex = 15;
            lbErrorNotes.Text = "X";
            // 
            // lbPeople
            // 
            lbPeople.FormattingEnabled = true;
            lbPeople.ItemHeight = 15;
            lbPeople.Location = new Point(383, 12);
            lbPeople.Name = "lbPeople";
            lbPeople.Size = new Size(287, 424);
            lbPeople.TabIndex = 16;
            lbPeople.SelectedValueChanged += lbPeople_SelectedValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 450);
            Controls.Add(lbPeople);
            Controls.Add(lbErrorNotes);
            Controls.Add(lbErrorGroup);
            Controls.Add(lbErrorSurname);
            Controls.Add(lbErrorName);
            Controls.Add(tbNotes);
            Controls.Add(tbGroup);
            Controls.Add(tbSurname);
            Controls.Add(tbName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnNew);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNew;
        private Button btnDelete;
        private Button btnUpdate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbName;
        private TextBox tbSurname;
        private TextBox tbGroup;
        private TextBox tbNotes;
        private Label lbErrorName;
        private Label lbErrorSurname;
        private Label lbErrorGroup;
        private Label lbErrorNotes;
        private ListBox lbPeople;
    }
}
