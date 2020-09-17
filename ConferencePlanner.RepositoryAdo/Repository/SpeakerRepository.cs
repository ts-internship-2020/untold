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
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly SqlConnection _sqlConnection;

        public SpeakerRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public BindingList<SpeakerModel> GetAllSpeakers()
        {
            string commandText = "select SpeakerId, FirstName, LastName, Nationality, Rating from Speaker " +
                "where SpeakerId <> 21";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            BindingList<SpeakerModel> speakers = new BindingList<SpeakerModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    speakers.Add(new SpeakerModel()
                    {
                        SpeakerId = sqlDataReader.GetInt32("SpeakerId"),
                        FirstName = sqlDataReader.GetString("FirstName"),
                        LastName = sqlDataReader.GetString("LastName"),
                        Nationality = sqlDataReader.GetString("Nationality"),
                        Rating = (float)sqlDataReader.GetDouble("Rating"),

                    }); ;

                }
            }

            return speakers;

        }


        public SpeakerModel GetSpeakerByName(string fname, string lname)
        {
            string commandText = "select Nationality, Rating, ImagePath from Speaker where FirstName =  @firstName and LastName = @lastName" ;

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@firstName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@firstName"].Value = fname;
            sqlCommand.Parameters.Add("@lastName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@lastName"].Value = lname;


            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            SpeakerModel speaker = new SpeakerModel();
            if (sqlDataReader.Read())
            {
                speaker.FirstName = fname;
                speaker.LastName = lname;
                speaker.Nationality = sqlDataReader.GetString("Nationality");
                speaker.Rating = (float)sqlDataReader.GetDouble("Rating");
                speaker.ImagePath = sqlDataReader.GetString("ImagePath");
            }


            sqlDataReader.Close();

            return speaker;
        }
        public SpeakerModel GetSpeakerById(int id)
        {
            string commandText = "select FisrName, LastName, Nationality, Rating, ImagePath from Speaker where SpeakerId = @Id";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = id;
           

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            SpeakerModel speaker = new SpeakerModel();

            if (sqlDataReader.Read())
            {
                speaker.FirstName = sqlDataReader.GetString("FirstName");
                speaker.LastName = sqlDataReader.GetString("LastName");
                speaker.Nationality = sqlDataReader.GetString("Nationality");
                speaker.Rating = (float)sqlDataReader.GetDouble("Rating");
                speaker.ImagePath = sqlDataReader.GetString("ImagePath");
            }

            

            sqlDataReader.Close();

            return speaker;
        }

        public void UpdateSpeaker(SpeakerModel speaker)
        {
            string commandText = "update Speaker " +
                "set FirstName = @FName, LastName = @LName, Nationality = @Nationality, Rating = @Rating " +
                "where SpeakerId = @Id";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@FName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FName"].Value = speaker.FirstName;
            sqlCommand.Parameters.Add("@LName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@LName"].Value = speaker.LastName;
            sqlCommand.Parameters.Add("@Nationality", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Nationality"].Value = speaker.Nationality;
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = speaker.SpeakerId;
            sqlCommand.Parameters.Add("@Rating", SqlDbType.Float);
            sqlCommand.Parameters["@Rating"].Value = speaker.Rating;

            sqlCommand.ExecuteNonQuery();
        }

        public void InsertSpeaker(SpeakerModel speaker)
        {
            string commandText = "insert into Speaker values(@FirstName, @LastName, @Nationality, @Rating, @Imagepath)";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@FirstName"].Value = speaker.FirstName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.NVarChar);
            sqlCommand.Parameters["@LastName"].Value = speaker.LastName;
            sqlCommand.Parameters.Add("@Nationality", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Nationality"].Value = speaker.Nationality;
            
            sqlCommand.Parameters.Add("@Rating", SqlDbType.Float);
            sqlCommand.Parameters["@Rating"].Value = speaker.Rating;
            sqlCommand.Parameters.Add("@Imagepath", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Imagepath"].Value = "../../../Resources/speakersPhotos/unknown_user.jpg";

            sqlCommand.ExecuteNonQuery();

        }
        public void DeleteSpeaker(int id)
        {
            string commandText = "delete from Speaker where SpeakerId = @Id";

            SqlCommand sqlCommand = new SqlCommand(commandText, _sqlConnection);
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int);
            sqlCommand.Parameters["@Id"].Value = id;
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string commandText2 = "update Conference " +
                "set MainSpeakerId = 21 " +
                "where MainSpeakerId = @Id " +
                "update ConferenceXSpeaker " +
                "set SpeakerId = 21 " +
                "where SpeakerId = @Id " +
                "delete from Speaker where SpeakerId = @Id";
                SqlCommand sqlCommand2 = new SqlCommand(commandText2, _sqlConnection);
                sqlCommand2.Parameters.Add("@Id", SqlDbType.Int);
                sqlCommand2.Parameters["@Id"].Value = id;
                sqlCommand2.ExecuteNonQuery();
            }
            
        }
    }
    }

