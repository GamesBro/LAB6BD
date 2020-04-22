namespace LAB6BDPrakt
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
            this.TableMain = new System.Windows.Forms.DataGridView();
            this.DeleteBut = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TableMain)).BeginInit();
            this.SuspendLayout();
            // 
            // TableMain
            // 
            this.TableMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableMain.Location = new System.Drawing.Point(13, 13);
            this.TableMain.Name = "TableMain";
            this.TableMain.RowHeadersWidth = 62;
            this.TableMain.RowTemplate.Height = 28;
            this.TableMain.Size = new System.Drawing.Size(895, 393);
            this.TableMain.TabIndex = 0;
            this.TableMain.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.TableMain_RowValidating);
            // 
            // DeleteBut
            // 
            this.DeleteBut.Location = new System.Drawing.Point(942, 13);
            this.DeleteBut.Name = "DeleteBut";
            this.DeleteBut.Size = new System.Drawing.Size(166, 49);
            this.DeleteBut.TabIndex = 2;
            this.DeleteBut.Text = "Delete";
            this.DeleteBut.UseVisualStyleBackColor = true;
            this.DeleteBut.Click += new System.EventHandler(this.DeleteBut_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(948, 87);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(0, 20);
            this.infoLabel.TabIndex = 3;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1120, 418);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.DeleteBut);
            this.Controls.Add(this.TableMain);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TableMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.DataGridView TableMain;
        private System.Windows.Forms.Button DeleteBut;
        private System.Windows.Forms.Label infoLabel;
    }
}

