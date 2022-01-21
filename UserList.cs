using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ユーザメンテナンス
{
    public partial class UserList : Form
    {
        public UserList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 閉じるボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        /// <summary>
        /// 新規ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create_Click(object sender, EventArgs e)
        {
            var usermaintenance = new UserMaintenance(string.Empty);
            usermaintenance.ShowDialog();
            this.Hide();
        }

        /// <summary>
        /// 画面表示時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>/
        private void UserList_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sql = "SELECT* FROM T_USER";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();

                            dataTable.Load(dataReader);
                            // DataGridViewに取得結果をセットする
                            this.dataGridView1.DataSource = dataTable;

                            dataReader.Close();
                        }
                    }

                    catch (SqlException ex)
                    {
                            MessageBox.Show("データの取得に失敗しました。システム管理者に連絡してください");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
        }

        /// <summary>
        /// DataGridViewのセルをダブルクリックしたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 何行目を選択されたかを取得する
            int rowIndex = e.RowIndex;
            // 選択行のユーザーIDを取得する
            string userId = dataGridView1[0, rowIndex].Value.ToString();

            // UserMaintenance画面を開く
            // ユーザーIDをUserMaintenanceに渡す
            var usermaintenance = new UserMaintenance(userId);
            usermaintenance.ShowDialog();
            this.Hide();
        }
    }
}
