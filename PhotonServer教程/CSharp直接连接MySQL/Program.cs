using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CSharp直接连接MySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read();
            //Insert();
            //Update();
            //Delete();
            //ReadUsersCount();
            //ExcuteScalar();
            Console.WriteLine(VerifyUser("siki", "123"));
            Console.WriteLine(VerifyUser("sikiedu2", "123"));
            Console.ReadKey();
        }

        static bool VerifyUser(string username,string password)
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有去跟数据库建立连接
            try
            {
                conn.Open();
                //string sql = "select * from users where username = '"+username+"' and password='"+password+"'";//我们自己按照查询条件去组拼sql
                string sql = "select * from users where username =@para1 and password = @para2 ";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("para1", username);
                cmd.Parameters.AddWithValue("para2", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }

                //  Console.WriteLine("已经建立连接");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        
        static void Read()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有去跟数据库建立连接
            try
            {
                conn.Open();
                string sql = "select * from users";
                //string sql = "select id,username,registerdate from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //cmd.ExecuteReader();//执行一些查询
                //cmd.ExecuteNonQuery();//插入 删除
                //cmd.ExecuteScalar();//执行一些查询，返回一个单个的值
                MySqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();//读取下一页数据，如果读取成功，返回true，如果没有下一页了，读取失败的话，返回false
                //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                //reader.Read();
                //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                while (reader.Read())
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2));
                    Console.WriteLine(reader.GetInt32("id") + " " + reader.GetString("username") + " " + reader.GetString("password"));
                }

                //  Console.WriteLine("已经建立连接");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        static void ReadUsersCount()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有去跟数据库建立连接
            try
            {
                conn.Open();
                string sql = "select count(*) from users";
                //string sql = "select id,username,registerdate from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                int count = Convert.ToInt32(reader[0].ToString());
                Console.WriteLine(count);

                //  Console.WriteLine("已经建立连接");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        static void ExcuteScalar()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有去跟数据库建立连接
            try
            {
                conn.Open();
                string sql = "select count(*) from users";
                //string sql = "select id,username,registerdate from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();

                //int count = Convert.ToInt32(reader[0].ToString());
                object o = cmd.ExecuteScalar();
                int count = Convert.ToInt32(o.ToString());
                Console.WriteLine(count);

                //  Console.WriteLine("已经建立连接");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        static void Insert()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有去跟数据库建立连接
            try
            {
                conn.Open();
                // string sql = "insert into users(username,password) values('cxlvkee','234')";
                //string sql = "insert into users(username,password,registerdate) values('cweKu','234','2014-01-09')";
                string sql = "insert into users(username,password,registerdate) values('csdFu','234','" + DateTime.Now + "')";
                Console.WriteLine(sql);
                //string sql = "select id,username,registerdate from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//返回值是数据库中受影响的数据的行数

                //  Console.WriteLine("已经建立连接");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        static void Update()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有去跟数据库建立连接
            try
            {
                conn.Open();
                // string sql = "insert into users(username,password) values('cxlvkee','234')";
                //string sql = "insert into users(username,password,registerdate) values('cweKu','234','2014-01-09')";
                string sql = "update users set username='sdfsedfwer',password='23242342432' where id = 4";
                Console.WriteLine(sql);
                //string sql = "select id,username,registerdate from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//返回值是数据库中受影响的数据的行数

                //  Console.WriteLine("已经建立连接");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        static void Delete()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有去跟数据库建立连接
            try
            {
                conn.Open();
                // string sql = "insert into users(username,password) values('cxlvkee','234')";
                //string sql = "insert into users(username,password,registerdate) values('cweKu','234','2014-01-09')";
                string sql = "delete from users where id = 4";
                Console.WriteLine(sql);
                //string sql = "select id,username,registerdate from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//返回值是数据库中受影响的数据的行数

                //  Console.WriteLine("已经建立连接");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
