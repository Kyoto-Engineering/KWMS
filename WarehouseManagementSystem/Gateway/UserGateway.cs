using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.DAL;
using WarehouseManagementSystem.DbGateway;

namespace WarehouseManagementSystem.Gateway
{
  public   class UserGateway:ConnectionGateway
    {
        private SqlCommand cmd;

        //public int SaveUser(User nUser)
        //{
        //    connection.Open();
        //    string insertquery = " insert into Registration(UserName,UserType,Password,Name,Designation,Department,ContactNo) Values('" + nUser.UserName + "','" + nUser.UserType + "','" + nUser.Password + "','" + nUser.Name + "','" + nUser.Designation + "','" + nUser.Department + "','" + nUser.ContactNumber + "')";
        //    cmd = new SqlCommand(insertquery, connection);
        //    int affectedrows = cmd.ExecuteNonQuery();
        //    connection.Close();
        //    return affectedrows;
        //}
    }
}
