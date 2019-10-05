using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace QuickProfit.Common
{
    public class DataBaseConnectionRoot
    {
        private static string _connectingString;
        private static DataBaseConnectionRoot _instance;
        private static readonly object Lock = new object();
        private DataBaseConnectionRoot() { }
        public static DataBaseConnectionRoot Instance {
            get {
                lock (Lock) {
                    if (_instance == null) {
                        _instance = new DataBaseConnectionRoot();
                        _connectingString = ConfigurationManager.ConnectionStrings["quickProfitConnection"].ConnectionString;
                    }
                    return _instance;
                }
            }
        }
        /// <summary>
        /// This return DataTable for any query written
        /// </summary>
        /// <param name="selectQuery"></param>
        /// <returns></returns>
        public DataTable SelectQueryExecuter(string selectQuery)
        {
            try
            {
                using (var con = new SqlConnection(_connectingString))
                {
                    var cmd = new SqlCommand(selectQuery, con);
                    var sda = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                ExceptionLoggerToDataBase(ex);
                return new DataTable();
            }

        }

        /// <summary>
        /// Logging error to Database
        /// </summary>
        /// <param name="ex"></param>
        public void ExceptionLoggerToDataBase(Exception ex) {
            using (var con = new SqlConnection(_connectingString))
            {
                var cmd = new SqlCommand("ExceptionLoggingToDataBase", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var exepurl = HttpContext.Current.Request.Url.ToString();
                cmd.Parameters.AddWithValue("@ExceptionMsg", ex.Message);
                cmd.Parameters.AddWithValue("@ExceptionType", ex.GetType().Name);
                cmd.Parameters.AddWithValue("@ExceptionURL", exepurl);
                cmd.Parameters.AddWithValue("@ExceptionSource", ex.StackTrace);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public bool UserSignup(string name, string username, string password,string mobileNo, string emailId, UserTypes userTypes)
        {
            using (var con = new SqlConnection(_connectingString))
            {
                var cmd = new SqlCommand("userSignUp", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", Decrypt(password));
                cmd.Parameters.AddWithValue("@emailid", emailId);
                cmd.Parameters.AddWithValue("@mobileno", mobileNo);
                cmd.Parameters.AddWithValue("@userType", (int)userTypes);
                cmd.Parameters.AddWithValue("@referalId", DateTime.Now.ToString("yyyyMMddHHmmssffff"));
                con.Open();
                int returnvalue = cmd.ExecuteNonQuery();
                con.Close();
                if (returnvalue == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Password Decripter
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        private string Decrypt(string clearText)
        {
            const string encryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor != null)
                {
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
                            CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }

                        clearText = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return clearText;
        }
    }
}