using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class CategoryReposity: ICategoryRepository
    {
        private readonly SqlConnection _sqlConnection;

        public CategoryReposity(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public BindingList<CategoryModel> GetConferenceCategories()
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select DictionaryConferenceCategoryId, ConferenceCategoryName from DictionaryConferenceCategory";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            
            BindingList<CategoryModel> CategoryList = new BindingList<CategoryModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    CategoryList.Add(new CategoryModel()
                    {
                        ConferenceCategoryId = sqlDataReader.GetInt32("DictionaryConferenceCategoryId"),
                        ConferenceCategoryName = sqlDataReader.GetString("ConferenceCategoryName")
                    });
                }
            }
            sqlDataReader.Close();
            return CategoryList;
        }

        public void UpdateCategory(CategoryModel category)
        {
            string commandText = "update DictionaryConferenceCategory " +
                "set ConferenceCategoryName = @Name " +
                "where DictionaryConferenceCategoryId = @Id";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Name"].Value = category.ConferenceCategoryName;
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = category.ConferenceCategoryId;

            sqlCommand.ExecuteNonQuery();
        }


        public void InsertCategory(CategoryModel category)
        {
            string commandText = "insert into DictionaryConferenceCategory values(@CategoryId, @CategoryName)";
            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@CategoryId", SqlDbType.Int);
            sqlCommand.Parameters["@CategoryId"].Value = category.ConferenceCategoryId;
            sqlCommand.Parameters.Add("@CategoryName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@CategoryName"].Value = category.ConferenceCategoryName;


            sqlCommand.ExecuteNonQuery();

        }

        public void DeleteCategory(int CategoryId)
        {
            string commantText = "delete from DictionaryConferenceCategory " +
                "where DictionaryConferenceCategoryId = @CategoryId";
            SqlCommand sqlCommand = new SqlCommand(commantText, _sqlConnection);
            sqlCommand.Parameters.Add("@CategoryId", SqlDbType.Int);
            sqlCommand.Parameters["@CategoryId"].Value = CategoryId;


            sqlCommand.ExecuteNonQuery();
        }
    }
}
