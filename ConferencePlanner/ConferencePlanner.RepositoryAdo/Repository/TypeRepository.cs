using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class TypeRepository : ITypeRepository
    {
        private readonly SqlConnection _sqlConnection;

        public TypeRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public BindingList<TypeModel> GetConferenceType()
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select DictionaryConferenceTypeId,ConferenceTypeName from DictionaryConferenceType";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            BindingList<TypeModel> typelist = new BindingList<TypeModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    typelist.Add(new TypeModel()
                    {
                        TypeId = sqlDataReader.GetInt32("DictionaryConferenceTypeId"),
                        TypeName = sqlDataReader.GetString("ConferenceTypeName"),


                    });
                }
            }

            sqlDataReader.Close();
            return typelist;
        }

        public void UpdateType(TypeModel type)
        {
            string commandText = "update DictionaryConferenceType " +
                "set DictionaryConferenceTypeId = @Id, ConferenceTypeName = @Name " +
                "where DictionaryConferenceTypeId = @Id";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Name"].Value = type.TypeName;
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = type.TypeId;

            sqlCommand.ExecuteNonQuery();
        }

        public void InsertType(TypeModel type)
        {
            string commandText = "insert into DictionaryConferenceType values(@Id, @Name)";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Name"].Value = type.TypeName;
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = type.TypeId;


            sqlCommand.ExecuteNonQuery();

        }
        public void DeleteType(int id)
        {
            string commandText = "delete from DictionaryConferenceType where DictionaryConferenceTypeId = @Id";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = id;

            sqlCommand.ExecuteNonQuery();


        }


        public TypeModel GetTypeById(int id)
        {
            string commandText = "select DictionaryConferenceTypeId,ConferenceTypeName from DictionaryConferenceType where DictionaryConferenceTypeId = @Id";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = id;


            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            TypeModel type = new TypeModel();

            if (sqlDataReader.Read())
            {
                type.TypeId = sqlDataReader.GetInt32("DictionaryConferenceTypeId");

                type.TypeName = sqlDataReader.GetString("ConferenceTypeName");
              
            }



            sqlDataReader.Close();

            return type;
        }
    }
}
    

 
