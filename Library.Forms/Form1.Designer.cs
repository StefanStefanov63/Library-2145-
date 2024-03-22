namespace Library.Forms
{
    partial class LibaryForm
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
            labelCommands = new Label();
            comboBoxCommands = new ComboBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            buttonCommit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelCommands
            // 
            labelCommands.AutoSize = true;
            labelCommands.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelCommands.Location = new Point(13, 379);
            labelCommands.Margin = new Padding(4, 0, 4, 0);
            labelCommands.Name = "labelCommands";
            labelCommands.Size = new Size(128, 30);
            labelCommands.TabIndex = 0;
            labelCommands.Text = "Commands:";
            // 
            // comboBoxCommands
            // 
            comboBoxCommands.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxCommands.FormattingEnabled = true;
            comboBoxCommands.Items.AddRange(new object[] { "[1] Register new Library Card", "[2] Delete Librery Card by Name", "[3] Update Library Card's Name", "[4] Get all Librery Cards", "[5] Take Book", "[6] Return Book", "[7] Get all Logs", "[8] Get all Logs for Book", "[9] Get all Logs for Library Card", "[10] Register new Book", "[11] Delete Book", "[12] Update Book's Title", "[13] Update Book's Author", "[14] Update Book's Description", "[15] Update Book's Quantity", "[16] Update Whole Book", "[17] Get all Books", "[18] Get Book by Title", "[19] Get all Books by Author", "[20] Register new Author", "[21] Delete Author", "[22] Update Author's Name", "[23] Get all Authors", "[24] Exit" });
            comboBoxCommands.Location = new Point(13, 29);
            comboBoxCommands.Margin = new Padding(4);
            comboBoxCommands.Name = "comboBoxCommands";
            comboBoxCommands.Size = new Size(533, 38);
            comboBoxCommands.TabIndex = 1;
            comboBoxCommands.Text = "Commands";
            comboBoxCommands.SelectedIndexChanged += comboBoxCommands_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(13, 107);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(128, 30);
            label1.TabIndex = 2;
            label1.Text = "Commands:";
            label1.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeight = 31;
            dataGridView1.Location = new Point(553, 29);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 56;
            dataGridView1.Size = new Size(673, 495);
            dataGridView1.TabIndex = 3;
            dataGridView1.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(282, 100);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(264, 37);
            textBox1.TabIndex = 4;
            textBox1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(13, 150);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(128, 30);
            label2.TabIndex = 5;
            label2.Text = "Commands:";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(13, 193);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(128, 30);
            label3.TabIndex = 6;
            label3.Text = "Commands:";
            label3.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(282, 143);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(264, 37);
            textBox2.TabIndex = 7;
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(282, 186);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(264, 37);
            textBox3.TabIndex = 8;
            textBox3.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(282, 229);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(264, 37);
            textBox4.TabIndex = 9;
            textBox4.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(282, 272);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(264, 37);
            textBox5.TabIndex = 10;
            textBox5.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(13, 236);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(128, 30);
            label4.TabIndex = 11;
            label4.Text = "Commands:";
            label4.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(13, 279);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(128, 30);
            label5.TabIndex = 12;
            label5.Text = "Commands:";
            label5.Visible = false;
            // 
            // buttonCommit
            // 
            buttonCommit.Location = new Point(418, 315);
            buttonCommit.Name = "buttonCommit";
            buttonCommit.Size = new Size(128, 48);
            buttonCommit.TabIndex = 13;
            buttonCommit.Text = "Commit";
            buttonCommit.UseVisualStyleBackColor = true;
            buttonCommit.Click += buttonCommit_Click;
            // 
            // LibaryForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(1238, 536);
            Controls.Add(buttonCommit);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(comboBoxCommands);
            Controls.Add(labelCommands);
            Font = new Font("Segoe UI", 12.1846151F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "LibaryForm";
            Text = "LibaryForm";
            Load += LibaryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCommands;
        private ComboBox comboBoxCommands;
        private Label label1;
        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label4;
        private Label label5;
        private Button buttonCommit;
    }
}
