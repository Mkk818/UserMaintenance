using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ユーザメンテナンス
{
    public partial class UserMaintenance : Form
    {
        // UserList画面から渡されたUSER_IDを退避する変数
        // 空文字の場合は"新規"、ユーザーIDが入っている場合は"更新"
        private string _userId;
        public UserMaintenance(string userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        /// <summary>
        /// 戻るボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, EventArgs e)
        {
            Form frm = new UserList();
            frm.Show();
            this.Close();
        }

        /// <summary>
        /// 更新ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpDate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text))
            {
                // エラーメッセージ
                MessageBox.Show("ユーザIDを入力してください");
                return;
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                // エラーメッセージ
                MessageBox.Show("ユーザ名を入力してください");
                return;
            }
            if (string.IsNullOrEmpty(txtDepartment.Text))
            {
                // エラーメッセージ
                MessageBox.Show("部署を入力してください");
                return;
            }
            if (string.IsNullOrEmpty(txtDirector.Text))
            {
                // エラーメッセージ
                MessageBox.Show("役職を入力してください");
                return;
            }
            if (string.IsNullOrEmpty(txtAuthority.Text))
            {
                // エラーメッセージ
                MessageBox.Show("権限を入力してください");
                return;
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                // エラーメッセージ
                MessageBox.Show("パスワードを入力してください");
                return;
            }


            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (_userId.Equals(string.Empty))
                {
                    //新規モード
                    const string sql = "INSERT INTO T_USER VALUES (@USER_ID, @USER_NAME, @DEPARTMENT, @DIRECTOR, @AUTHORITY, @PASS)";

                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@USER_ID"].Value = txtUserID.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@USER_NAME", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@USER_NAME"].Value = txtUserName.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@DEPARTMENT", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@DEPARTMENT"].Value = txtDepartment.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@DIRECTOR", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@DIRECTOR"].Value = txtDirector.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@AUTHORITY", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@AUTHORITY"].Value = txtAuthority.Text;

                        sqlCommand.Parameters.Add(new SqlParameter("@" +
                            "" +
                            "PASS", SqlDbType.NChar));
                        sqlCommand.Parameters["@PASS"].Value = txtPass.Text;

                            connection.Open();
                        try
                        {
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("新規登録しました。");
                        }
                        catch
                        {
                            MessageBox.Show("登録できませんでした。入力内容を確認してください。");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
                else
                {
                    // 更新モード
                    // updateの処理
                    const string sql = "UPDATE T_USER SET USER_NAME = @USER_NAME, DEPARTMENT = @DEPARTMENT, DIRECTOR = @DIRECTOR, AUTHORITY = @AUTHORITY, PASS = @PASS WHERE USER_ID = @USER_ID ";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@USER_ID"].Value = _userId;
                        sqlCommand.Parameters.Add(new SqlParameter("@USER_NAME", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@USER_NAME"].Value = txtUserName.Text;
                        sqlCommand.Parameters.Add(new SqlParameter("@DEPARTMENT", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@DEPARTMENT"].Value = txtDepartment.Text;
                        sqlCommand.Parameters.Add(new SqlParameter("@DIRECTOR", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@DIRECTOR"].Value = txtDirector.Text;
                        sqlCommand.Parameters.Add(new SqlParameter("@AUTHORITY", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@AUTHORITY"].Value = txtAuthority.Text;
                        sqlCommand.Parameters.Add(new SqlParameter("@PASS", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@PASS"].Value = txtPass.Text;


                        connection.Open();
                        SqlTransaction transaction;
                        transaction = connection.BeginTransaction("transaction");
                        sqlCommand.Transaction = transaction;

                        try
                        {
                            sqlCommand.ExecuteNonQuery();
                            transaction.Commit();
                            MessageBox.Show("更新しました。");

                        }
                        catch
                        {
                            transaction.Rollback();
                            MessageBox.Show("更新できませんでした。システム管理者に連絡してください");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 画面表示時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserMaintenance_Load(object sender, EventArgs e)
        {

            txtUserID.ReadOnly = false;

            // データ取得
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                const string sql = "SELECT * FROM T_USER WHERE USER_ID = @USER_ID";

                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.NVarChar));
                    sqlCommand.Parameters["@USER_ID"].Value = _userId;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();

                            dataTable.Load(dataReader);

                            // 取得結果件数が1件以上の場合
                            if (dataTable.Rows.Count > 0)
                            {
                                // 画面のテキストボックスに取得結果をセットする
                                this.txtUserID.Text = _userId;
                                this.txtUserName.Text = dataTable.Rows[0]["USER_NAME"].ToString();
                                this.txtDepartment.Text = dataTable.Rows[0]["DEPARTMENT"].ToString();
                                this.txtDirector.Text = dataTable.Rows[0]["DIRECTOR"].ToString();
                                this.txtAuthority.Text = dataTable.Rows[0]["AUTHORITY"].ToString();
                                this.txtPass.Text = dataTable.Rows[0]["PASS"].ToString();

                                this.txtUserID.ReadOnly = true;
                                // 更新モードのときにユーザー名の入力欄にカーソルを入れる
                                this.txtUserID.TabIndex = 10;

                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("データの取得に失敗しました。システム管理者に連絡してください");
                        this.Close();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
        }

        //削除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                    const string sql = "DELETE FROM T_USER WHERE USER_ID = @USER_ID";

                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.NVarChar));
                        sqlCommand.Parameters["@USER_ID"].Value = txtUserID.Text;


                        try
                        {
                            connection.Open();
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("削除しました。");

                        }
                        catch
                        {
                            MessageBox.Show("削除できませんでした。システム管理者に連絡してください");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

            }
        }
    }
}


