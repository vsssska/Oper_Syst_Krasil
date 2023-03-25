namespace KontrolnayaRabota
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileselecter = new System.Windows.Forms.Button();
            this.filepath = new System.Windows.Forms.TextBox();
            this.readcopyCount = new System.Windows.Forms.Label();
            this.writePathName = new System.Windows.Forms.Label();
            this.folderSelecter = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(17, 185);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 30);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(536, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Копировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileselecter
            // 
            this.fileselecter.Location = new System.Drawing.Point(17, 75);
            this.fileselecter.Name = "fileselecter";
            this.fileselecter.Size = new System.Drawing.Size(144, 23);
            this.fileselecter.TabIndex = 2;
            this.fileselecter.Text = "Выбрать файл";
            this.fileselecter.UseVisualStyleBackColor = true;
            this.fileselecter.Click += new System.EventHandler(this.fileselecter_Click);
            // 
            // filepath
            // 
            this.filepath.Location = new System.Drawing.Point(17, 49);
            this.filepath.Name = "filepath";
            this.filepath.Size = new System.Drawing.Size(556, 20);
            this.filepath.TabIndex = 3;
            // 
            // readcopyCount
            // 
            this.readcopyCount.AutoSize = true;
            this.readcopyCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.readcopyCount.Location = new System.Drawing.Point(12, 144);
            this.readcopyCount.Name = "readcopyCount";
            this.readcopyCount.Size = new System.Drawing.Size(305, 26);
            this.readcopyCount.TabIndex = 4;
            this.readcopyCount.Text = "Введите колличество копий:";
            // 
            // writePathName
            // 
            this.writePathName.AutoSize = true;
            this.writePathName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.writePathName.Location = new System.Drawing.Point(12, 9);
            this.writePathName.Name = "writePathName";
            this.writePathName.Size = new System.Drawing.Size(277, 26);
            this.writePathName.TabIndex = 5;
            this.writePathName.Text = "Путь копируемого файла:";
            // 
            // folderSelecter
            // 
            this.folderSelecter.Location = new System.Drawing.Point(209, 75);
            this.folderSelecter.Name = "folderSelecter";
            this.folderSelecter.Size = new System.Drawing.Size(144, 23);
            this.folderSelecter.TabIndex = 6;
            this.folderSelecter.Text = "Выбрать папку";
            this.folderSelecter.UseVisualStyleBackColor = true;
            this.folderSelecter.Click += new System.EventHandler(this.folderSelecter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 323);
            this.Controls.Add(this.folderSelecter);
            this.Controls.Add(this.writePathName);
            this.Controls.Add(this.readcopyCount);
            this.Controls.Add(this.filepath);
            this.Controls.Add(this.fileselecter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button fileselecter;
        private System.Windows.Forms.TextBox filepath;
        private System.Windows.Forms.Label readcopyCount;
        private System.Windows.Forms.Label writePathName;
        private System.Windows.Forms.Button folderSelecter;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

