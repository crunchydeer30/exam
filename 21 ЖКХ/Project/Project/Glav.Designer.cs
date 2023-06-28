namespace Project
{
    partial class Glav
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
            this.refresh = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.KvitanziaGrid = new System.Windows.Forms.DataGridView();
            this.history = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KvitanziaGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.refresh.Location = new System.Drawing.Point(532, 290);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(130, 38);
            this.refresh.TabIndex = 9;
            this.refresh.Text = " Обновить";
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.delete.Location = new System.Drawing.Point(369, 290);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(130, 38);
            this.delete.TabIndex = 10;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.update.Location = new System.Drawing.Point(194, 290);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(130, 38);
            this.update.TabIndex = 8;
            this.update.Text = "Изменить";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.add.Location = new System.Drawing.Point(12, 290);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(130, 38);
            this.add.TabIndex = 7;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // KvitanziaGrid
            // 
            this.KvitanziaGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.KvitanziaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KvitanziaGrid.Location = new System.Drawing.Point(12, 12);
            this.KvitanziaGrid.Name = "KvitanziaGrid";
            this.KvitanziaGrid.Size = new System.Drawing.Size(813, 260);
            this.KvitanziaGrid.TabIndex = 6;
            // 
            // history
            // 
            this.history.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.history.Location = new System.Drawing.Point(695, 290);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(130, 38);
            this.history.TabIndex = 11;
            this.history.Text = "История";
            this.history.UseVisualStyleBackColor = false;
            this.history.Click += new System.EventHandler(this.history_Click);
            // 
            // Glav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 340);
            this.Controls.Add(this.history);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.update);
            this.Controls.Add(this.add);
            this.Controls.Add(this.KvitanziaGrid);
            this.Name = "Glav";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.Glav_Load);
            this.Click += new System.EventHandler(this.Glav_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KvitanziaGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.DataGridView KvitanziaGrid;
        private System.Windows.Forms.Button history;
    }
}

