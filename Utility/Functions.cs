using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace Students_Evaluation_System.Utility
{
    class Functions
    {
        public static string Select_Condition(int i, string str)
        {
            string condition = "";
            switch (i)
            {
                case 0:
                    condition = "WHERE FirstName LIKE '" + char_condition(str) + "'";
                    break;

                case 1:
                    condition = "WHERE LastName LIKE '" + char_condition(str) + "'";
                    break;

                case 2:
                    condition = "WHERE Contact LIKE '" + char_condition(str) + "'";
                    break;

                case 3:
                    condition = "WHERE Email LIKE '" + char_condition(str) + "'";
                    break;

                case 4:
                    condition = "WHERE RegistrationNumber LIKE '" + char_condition(str) + "'";
                    break;

                case 5:
                    condition = "WHERE L.Name = '" + str + "'";
                    break;

                default:
                    break;
            }
            return condition;
        }

        public static string char_condition(string var)
        {
            string cond = "";
            for (int i = 0; i < var.Length; i++)
            {
                cond += "%" + var[i];
            }
            cond += "%";
            return cond;
        }

        public static int Get_Actual_Index_From_DataSource(DataTable dataTable,
            string column_name, string value)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                if (row[column_name].ToString() == value)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
