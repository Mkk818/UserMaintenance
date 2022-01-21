
namespace ユーザメンテナンス
{
    partial class UserList
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Create = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.USER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AUTHORITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(498, 44);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 23);
            this.Create.TabIndex = 2;
            this.Create.Text = "新規";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(598, 44);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 3;
            this.Close.Text = "閉じる";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.USER_ID,
            this.USER_NAME,
            this.DEPARTMENT,
            this.DIRECTOR,
            this.AUTHORITY,
            this.PASS});
            this.dataGridView1.Location = new System.Drawing.Point(43, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(629, 242);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // USER_ID
            // 
            this.USER_ID.DataPropertyName = "USER_ID";
            this.USER_ID.HeaderText = "ユーザID";
            this.USER_ID.Name = "USER_ID";
            this.USER_ID.ReadOnly = true;
            // 
            // USER_NAME
            // 
            this.USER_NAME.DataPropertyName = "USER_NAME";
            this.USER_NAME.HeaderText = "ユーザ名";
            this.USER_NAME.Name = "USER_NAME";
            this.USER_NAME.ReadOnly = true;
            // 
            // DEPARTMENT
            // 
            this.DEPARTMENT.DataPropertyName = "DEPARTMENT";
            this.DEPARTMENT.HeaderText = "部署";
            this.DEPARTMENT.Name = "DEPARTMENT";
            this.DEPARTMENT.ReadOnly = true;
            // 
            // DIRECTOR
            // 
            this.DIRECTOR.DataPropertyName = "DIRECTOR";
            this.DIRECTOR.HeaderText = "役職";
            this.DIRECTOR.Name = "DIRECTOR";
            this.DIRECTOR.ReadOnly = true;
            // 
            // AUTHORITY
            // 
            this.AUTHORITY.DataPropertyName = "AUTHORITY";
            this.AUTHORITY.HeaderText = "権限";
            this.AUTHORITY.Name = "AUTHORITY";
            this.AUTHORITY.ReadOnly = true;
            // 
            // PASS
            // 
            this.PASS.DataPropertyName = "PASS";
            this.PASS.HeaderText = "パスワード";
            this.PASS.Name = "PASS";
            this.PASS.ReadOnly = true;
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 321);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Create);
            this.Name = "UserList";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UserList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUTHORITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PASS;
    }
}

